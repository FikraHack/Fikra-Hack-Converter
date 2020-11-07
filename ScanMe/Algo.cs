using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Fikra_Hack_Converter
{
   public class Algo
    {

		public  byte[] RC4Encrypt(byte[] A6, string A7)
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

		public  byte[] AES_Encrypt(byte[] Data, string Pass)
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

		public  byte[] XOREncrypt(byte[] up, string BB2)
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
				return System.Text.Encoding.Default.GetBytes( Strings.StrReverse(b));
			}
		}
	}
}



