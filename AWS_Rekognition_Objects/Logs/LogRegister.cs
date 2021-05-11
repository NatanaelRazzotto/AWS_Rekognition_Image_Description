using System;
using System.IO;
using System.Reflection;

namespace AWS_Rekognition_Objects.Helpers.Model
{
    public class LogRegister
    {
        private static string pathExe = string.Empty;
        public bool Log(string strMessage, string strNameFile = "ArquivoDeLog")
        {
            try
            {
                pathExe = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                string pathFile = Path.Combine(pathExe, strNameFile + ".txt");
                if (!File.Exists(pathFile))
                {
                    FileStream arquivo = File.Create(pathFile);
                    arquivo.Close();
                }
                using (StreamWriter w = File.AppendText(pathFile))
                {
                    AppendLog(strMessage, w);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private static void AppendLog(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog: ");
                txtWriter.Write($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                txtWriter.Write($"  :{logMessage}");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
