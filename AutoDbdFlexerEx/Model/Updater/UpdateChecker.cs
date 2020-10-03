using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AutoDbdFlexerEx.Model.Updater
{
    public class UpdateChecker
    {
        public const string GITHUB_EXECUTABLE_URL = "http://github.com/TheWonderfulCookie/autodbdflexerex/raw/master/AutoDbdFlexerEx/bin/Release/AutoDbdFlexerEx.exe";

        public static async Task<UpdateCheckerResult> CheckForUpdatesAsync()
        {
            return await Task.Run(CheckForUpdates);
        }
        public static UpdateCheckerResult CheckForUpdates()
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                string tempFile = Path.Combine(Path.GetTempPath(), "AutoDbdFlexerEx.exe");
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(GITHUB_EXECUTABLE_URL);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    Stream responseStream = response.GetResponseStream();
                    byte[] buffer = new byte[1024];
                    long bytesRead = 0;
                    using (FileStream fs = new FileStream(tempFile, FileMode.Create))
                    {
                        while (bytesRead < response.ContentLength)
                        {
                            int read = responseStream.Read(buffer, 0, buffer.Length);
                            if (read == 0)
                            {
                                Thread.Sleep(10);
                                continue;
                            }
                            fs.Write(buffer, 0, read);
                            bytesRead += read;
                        }
                    }
                }
                FileVersionInfo newVersion = FileVersionInfo.GetVersionInfo(tempFile);
                UpdateCheckerResult result = new UpdateCheckerResult(Version.Parse(newVersion.FileVersion), tempFile);
                if (!result.CanUpdate) File.Delete(tempFile);
                return result;
            }
            catch
            {
                return new UpdateCheckerResult();
            }
        }
    }
}
