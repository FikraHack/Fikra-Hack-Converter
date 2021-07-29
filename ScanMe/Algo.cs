using Microsoft.VisualBasic;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace Fikra_Hack_Converter
{
    class BNR
    {
        public string HexToBinary(byte[] server)
        {
            string str_data = "";

            for (int i = 0; i < server.Length; i++)
            {
                str_data += HexToBin(server[i]) + ".";
            }
            return str_data;
        }


        String HexToBin(byte b)
        {
            StringBuilder str = new StringBuilder(8);
            int[] bl = new int[8];

            for (int i = 0; i < bl.Length; i++)
            {
                bl[bl.Length - 1 - i] = ((b & (1 << i)) != 0) ? 1 : 0;
            }

            foreach (int num in bl) str.Append(num);

            return str.ToString();
        }
    }

    public class Aes256
    {
        private const int KeyLength = 32;
        private const int AuthKeyLength = 64;
        private const int IvLength = 16;
        private const int HmacSha256Length = 32;
        private readonly byte[] _key;
        private readonly byte[] _authKey;

        private static readonly byte[] Salt =
        {
            0xBF, 0xEB, 0x1E, 0x56, 0xFB, 0xCD, 0x97, 0x3B, 0xB2, 0x19, 0x2, 0x24, 0x30, 0xA5, 0x78, 0x43, 0x0, 0x3D, 0x56,
            0x44, 0xD2, 0x1E, 0x62, 0xB9, 0xD4, 0xF1, 0x80, 0xE7, 0xE6, 0xC3, 0x39, 0x41
        };

        public Aes256(string masterKey)
        {
            if (string.IsNullOrEmpty(masterKey))
                throw new ArgumentException($"{nameof(masterKey)} can not be null or empty.");

            using (Rfc2898DeriveBytes derive = new Rfc2898DeriveBytes(masterKey, Salt, 50000))
            {
                _key = derive.GetBytes(KeyLength);
                _authKey = derive.GetBytes(AuthKeyLength);
            }
        }

        public string Encrypt(string input)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(input)));
        }

        public byte[] Encrypt(byte[] input)
        {
            if (input == null)
                throw new ArgumentNullException($"{nameof(input)} can not be null.");

            using (var ms = new MemoryStream())
            {
                ms.Position = HmacSha256Length; // reserve first 32 bytes for HMAC
                using (var aesProvider = new AesCryptoServiceProvider())
                {
                    aesProvider.KeySize = 256;
                    aesProvider.BlockSize = 128;
                    aesProvider.Mode = CipherMode.CBC;
                    aesProvider.Padding = PaddingMode.PKCS7;
                    aesProvider.Key = _key;
                    aesProvider.GenerateIV();

                    using (var cs = new CryptoStream(ms, aesProvider.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        ms.Write(aesProvider.IV, 0, aesProvider.IV.Length); // write next 16 bytes the IV, followed by ciphertext
                        cs.Write(input, 0, input.Length);
                        cs.FlushFinalBlock();

                        using (var hmac = new HMACSHA256(_authKey))
                        {
                            byte[] hash = hmac.ComputeHash(ms.ToArray(), HmacSha256Length, ms.ToArray().Length - HmacSha256Length); // compute the HMAC of IV and ciphertext
                            ms.Position = 0; // write hash at beginning
                            ms.Write(hash, 0, hash.Length);
                        }
                    }
                }

                return ms.ToArray();
            }
        }

        public string Decrypt(string input)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(input)));
        }

        public byte[] Decrypt(byte[] input)
        {
            if (input == null)
                throw new ArgumentNullException($"{nameof(input)} can not be null.");

            using (var ms = new MemoryStream(input))
            {
                using (var aesProvider = new AesCryptoServiceProvider())
                {
                    aesProvider.KeySize = 256;
                    aesProvider.BlockSize = 128;
                    aesProvider.Mode = CipherMode.CBC;
                    aesProvider.Padding = PaddingMode.PKCS7;
                    aesProvider.Key = _key;

                    // read first 32 bytes for HMAC
                    using (var hmac = new HMACSHA256(_authKey))
                    {
                        var hash = hmac.ComputeHash(ms.ToArray(), HmacSha256Length, ms.ToArray().Length - HmacSha256Length);
                        byte[] receivedHash = new byte[HmacSha256Length];
                        ms.Read(receivedHash, 0, receivedHash.Length);

                        if (!AreEqual(hash, receivedHash))
                            throw new CryptographicException("Invalid message authentication code (MAC).");
                    }

                    byte[] iv = new byte[IvLength];
                    ms.Read(iv, 0, IvLength); // read next 16 bytes for IV, followed by ciphertext
                    aesProvider.IV = iv;

                    using (var cs = new CryptoStream(ms, aesProvider.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        byte[] temp = new byte[ms.Length - IvLength + 1];
                        byte[] data = new byte[cs.Read(temp, 0, temp.Length)];
                        Buffer.BlockCopy(temp, 0, data, 0, data.Length);
                        return data;
                    }
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private bool AreEqual(byte[] a1, byte[] a2)
        {
            bool result = true;
            for (int i = 0; i < a1.Length; ++i)
            {
                if (a1[i] != a2[i])
                    result = false;
            }
            return result;
        }
    }


    public class Algo
    {

        public byte[] RC4Encrypt(byte[] A6, string A7)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(A7);
            uint num = 0u;
            uint[] array = new uint[256];
            byte[] array2 = new byte[A6.Length];
            uint num2;
            for (num2 = 0u; num2 <= 255u; num2 += 1u)
            {
                array[(int)((UIntPtr)num2)] = num2;
            }
            for (num2 = 0u; num2 <= 255u; num2 += 1u)
            {
                num = (num + (uint)bytes[(int)(checked((IntPtr)(unchecked((ulong)num2 % (ulong)((long)bytes.Length)))))] + array[(int)((UIntPtr)num2)] & 255u);
                uint num3 = array[(int)((UIntPtr)num2)];
                array[(int)((UIntPtr)num2)] = array[(int)((UIntPtr)num)];
                array[(int)((UIntPtr)num)] = num3;
            }
            num2 = 0u;
            num = 0u;
            for (long num4 = 0L; num4 <= (long)(array2.Length - 1); num4 += 1L)
            {
                num2 = (num2 + 1u & 255u);
                num = (num + array[(int)((UIntPtr)num2)] & 255u);
                uint num3 = array[(int)((UIntPtr)num2)];
                array[(int)((UIntPtr)num2)] = array[(int)((UIntPtr)num)];
                array[(int)((UIntPtr)num)] = num3;
                array2[(int)(checked((IntPtr)num4))] = Convert.ToByte((uint)A6[(int)(checked((IntPtr)num4))] ^ array[(int)((UIntPtr)(array[(int)((UIntPtr)num2)] + array[(int)((UIntPtr)num)] & 255u))]);
            }
            return array2;
        }
        public byte[] DESEncrypt(byte[] B, string ikey)
        {
            DESCryptoServiceProvider descryptoServiceProvider = new DESCryptoServiceProvider();
            SHA256CryptoServiceProvider sha256CryptoServiceProvider = new SHA256CryptoServiceProvider();
            byte[] array = new byte[8];
            byte[] sourceArray = sha256CryptoServiceProvider.ComputeHash(Encoding.BigEndianUnicode.GetBytes(ikey));
            Array.Copy(sourceArray, 0, array, 0, 8);
            descryptoServiceProvider.Key = array;
            descryptoServiceProvider.Mode = CipherMode.ECB;
            return descryptoServiceProvider.CreateEncryptor().TransformFinalBlock(B, 0, B.Length);
        }
        public static byte[] MD5Encrypt(byte[] bytData, string Skey)
        {
            MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] array = md5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(Skey));
            return new TripleDESCryptoServiceProvider
            {
                Key = array,
                Mode = CipherMode.ECB
            }.CreateEncryptor().TransformFinalBlock(bytData, 0, bytData.Length);
        }

        public byte[] AES_Encrypt(byte[] Data, string Pass)
        {
            SHA256Managed sha256Managed = new SHA256Managed();
            byte[] array = sha256Managed.ComputeHash(Encoding.BigEndianUnicode.GetBytes(Pass));
            return new AesCryptoServiceProvider
            {
                KeySize = 256,
                Key = array,
                Mode = CipherMode.ECB
            }.CreateEncryptor().TransformFinalBlock(Data, 0, Data.Length);
        }

        static byte[] zzzzzzzzzzzz(byte[] data, byte[] key)
        {
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(key, new byte[8], 1);
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(16);
            rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(16);
            byte[] array = new byte[data.Length + 16];
            Buffer.BlockCopy(Guid.NewGuid().ToByteArray(), 0, array, 0, 16);
            Buffer.BlockCopy(data, 0, array, 16, data.Length);
            return rijndaelManaged.CreateEncryptor().TransformFinalBlock(array, 0, array.Length);
        }

        public byte[] RSM_Result(byte[] File, string key2)
        {
            return zzzzzzzzzzzz(File, Encoding.ASCII.GetBytes(key2));
        }

        public byte[] XOREncrypt(byte[] up, string BB2)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(BB2);
            VBMath.Randomize();
            int num = Convert.ToInt32(256f * VBMath.Rnd()) + 1;
            byte[] array = new byte[up.Length + 1];
            int num2 = 0;
            for (int i = 0; i <= up.Length - 1; i++)
            {
                byte[] array2 = array;
                int num3 = i;
                array2[num3] += Convert.ToByte((int)(up[i] ^ bytes[num2]) ^ num);
                if (num2 == BB2.Length - 1)
                {
                    num2 = 0;
                }
                else
                {
                    num2++;
                }
            }
            array[up.Length] = Convert.ToByte(112 ^ num);
            return array;
        }

        //************************************************
        public byte[] RC2Encrypt(byte[] B, string ikey)
        {
            RC2CryptoServiceProvider rc2CryptoServiceProvider = new RC2CryptoServiceProvider();
            MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] key = md5CryptoServiceProvider.ComputeHash(Encoding.BigEndianUnicode.GetBytes(ikey));
            rc2CryptoServiceProvider.Key = key;
            rc2CryptoServiceProvider.Mode = CipherMode.ECB;
            return rc2CryptoServiceProvider.CreateEncryptor().TransformFinalBlock(B, 0, B.Length);
        }
        public byte[] Md5Encrypt(byte[] B, string iKey)
        {
            MD5CryptoServiceProvider md5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] key = md5CryptoServiceProvider.ComputeHash(Encoding.BigEndianUnicode.GetBytes(iKey));
            AesManaged aesManaged = new AesManaged();
            aesManaged.Key = key;
            aesManaged.Mode = CipherMode.ECB;
            ICryptoTransform cryptoTransform = aesManaged.CreateEncryptor();
            byte[] result = cryptoTransform.TransformFinalBlock(B, 0, B.Length);
            aesManaged.Clear();
            return result;
        }

        public byte[] fikralgoEnc(byte[] inn)
        {
            checked
            {
                int a = inn.Length - 1;
                string b = "";
                int num = a;
                for (int i = 0; i <= num; i++)
                {
                    b = b + inn[i].ToString() + " ";
                }
                return System.Text.Encoding.Default.GetBytes(Strings.StrReverse(b));
            }
        }
    }
}



