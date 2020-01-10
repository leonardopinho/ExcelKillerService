using System;
using System.Configuration;
using System.IO;

namespace ClearExcelService
{
    class LogTxt
    {
        public void Logger(string texto)
        {
            StreamWriter fluxoTexto;
            string path = ConfigurationManager.AppSettings["PASTA_DESTINO"].ToString();

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            String pathLog = path + "LOG.txt";

            try
            {
                if (!File.Exists(pathLog))
                {
                    FileStream fs = File.Create(pathLog);
                    fs.Close();

                    fluxoTexto = new StreamWriter(pathLog, true);
                    fluxoTexto.WriteLine("DATE: " + DateTime.Now.ToString() + Environment.NewLine + "Description: " + texto);
                    fluxoTexto.Close();
                }
                else
                {
                    fluxoTexto = new StreamWriter(pathLog, true);
                    fluxoTexto.WriteLine("DATE: " + DateTime.Now.ToString() + Environment.NewLine + "Description: " + texto);
                    fluxoTexto.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
