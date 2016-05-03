using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hangman
{
    public class encDecr
    {
        public object MessageBox { get; private set; }
        /*public static string inp = @"../../Resources/score.txt";
        public static string outp = @"../../Resources/scorencr.txt";
        public static string decr = @"../../Resources/scoredecr.txt";*/

        /*static void Main(string[] args)
        {
            if (!File.Exists(inp) && !File.Exists(outp))
            {
                File.Create(inp).Close();
                EncryptFile(inp, outp);
                File.Delete(inp);
                DecryptFile(outp, decr);
                File.Delete(outp);
                StreamWriter wr = new StreamWriter(decr, true);
                wr.WriteLine("Filip    1234");
                wr.Flush();
                wr.Close();
                EncryptFile(decr, outp);
                File.Delete(decr);
            }
            else
            {
                DecryptFile(outp, decr);
                File.Delete(outp);
                StreamWriter wr = new StreamWriter(decr, true);
                wr.WriteLine("Jona    1234");
                wr.Flush();
                wr.Close();
                EncryptFile(decr, outp);
                File.Delete(decr);
            }
        }*/

        public void EncryptFile(string inputFile, string outputFile)
        {

            try
            {
                string password = @"vProCks7"; // Your Key Here
                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                string cryptFile = outputFile;
                FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

                System.Security.Cryptography.RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateEncryptor(key, key),
                    CryptoStreamMode.Write);

                FileStream fsIn = new FileStream(inputFile, FileMode.Open);

                int data;
                while ((data = fsIn.ReadByte()) != -1)
                    cs.WriteByte((byte)data);


                fsIn.Close();
                cs.Close();
                fsCrypt.Close();
            }
            catch
            {
                //MessageBox.Show("Encryption failed!", "Error");
            }
        }


        public void DecryptFile(string inputFile, string outputFile)
        {

            {
                string password = @"vProCks7"; // Your Key Here

                UnicodeEncoding UE = new UnicodeEncoding();
                byte[] key = UE.GetBytes(password);

                FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);

                RijndaelManaged RMCrypto = new RijndaelManaged();

                CryptoStream cs = new CryptoStream(fsCrypt,
                    RMCrypto.CreateDecryptor(key, key),
                    CryptoStreamMode.Read);

                FileStream fsOut = new FileStream(outputFile, FileMode.Create);

                int data;
                while ((data = cs.ReadByte()) != -1)
                    fsOut.WriteByte((byte)data);

                fsOut.Close();
                cs.Close();
                fsCrypt.Close();

            }
        }
    }
}
