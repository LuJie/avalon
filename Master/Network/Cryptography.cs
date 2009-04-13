using System;
using System.Collections.Generic;
using System.Text;

namespace Avalon.Network
{
    public static class Cryptography
    {
        private readonly static byte[][] sEncryptionTable = new byte[256][];
        private readonly static byte[][] sDecryptionTable = new byte[256][];
        public static uint sIV;
        public static void Initialize()
        {
            for (int index1 = 0; index1 < sEncryptionTable.Length; ++index1)
            {
                byte temp1 = (byte)((index1 * 0x49) ^ 0x15);
                byte temp2 = (byte)((temp1 * 0x49) ^ 0x15);
                sEncryptionTable[temp1] = new byte[256];
                sDecryptionTable[temp1] = new byte[256];
                for (int index2 = 0; index2 < sEncryptionTable[temp1].Length; ++index2)
                {
                    sEncryptionTable[temp1][index2] = (byte)((((index2 * 0x49) ^ 0x15) + temp2) ^ 0x12);
                    sDecryptionTable[temp1][(byte)((((index2 * 0x49) ^ 0x15) + temp2) ^ 0x12)] = (byte)index2;
                }
            }
         }
            
        public static byte[] Encrypt(byte[] pBuffer)
        {
            for (int index1 = 0; index1 < pBuffer.Length; ++index1)
            {
                byte[] buf = BitConverter.GetBytes(sIV++);
                byte offset = (byte)(buf[0] + 4);
                for (int index2 = 1; index2 < buf.Length; ++index2) offset += (byte)((buf[index2] * 0x49) ^ 0x15);
                pBuffer[index1] = sEncryptionTable[offset][pBuffer[index1]];
            }
            return pBuffer;
        }
        
        public static byte[] Decrypt(byte[] pBuffer)
        {
            for (int index1 = 0; index1 < pBuffer.Length; ++index1)
            {
                byte[] buf = BitConverter.GetBytes(sIV++);
                byte offset = (byte)(buf[0] + 4);
                for (int index2 = 1; index2 < buf.Length; ++index2) offset += (byte)((buf[index2] * 0x49) ^ 0x15);
                pBuffer[index1] = sDecryptionTable[offset][pBuffer[index1]];
            }
            return pBuffer;
        }
    }
}
