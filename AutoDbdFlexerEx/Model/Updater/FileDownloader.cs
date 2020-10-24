using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace AutoDbdFlexerEx.Model.Updater
{
    static class FileDownloader
    {
        public static async Task<FileDownloaderResult> DownloadAsync(string url, string savePath = null)
        {
            return await Task.Run(() => Download(url, savePath));
        }
        public static FileDownloaderResult Download(string url, string savePath = null)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                string tempFile = savePath ?? Path.GetTempFileName();

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream responseStream = response.GetResponseStream())
                using (FileStream fs = new FileStream(tempFile, FileMode.Create))
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;
                    do
                    {
                        bytesRead = responseStream.Read(buffer, 0, buffer.Length);
                        fs.Write(buffer, 0, bytesRead);
                    } while (bytesRead > 0);
                }

                return new FileDownloaderResult(savePath);
            }
            catch
            {
                return new FileDownloaderResult();
            }
        }
    }
}