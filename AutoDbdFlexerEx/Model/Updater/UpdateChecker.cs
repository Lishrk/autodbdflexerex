using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace AutoDbdFlexerEx.Model.Updater
{
    static class UpdateChecker
    {
        public const string GITHUB_EXECUTABLE_URL = "http://github.com/TheWonderfulCookie/autodbdflexerex/raw/master/AutoDbdFlexerEx/bin/Release/AutoDbdFlexerEx.exe";

        public static async Task<UpdateCheckerResult> CheckForUpdatesAsync()
        {
            return await Task.Run(CheckForUpdates);
        }
        public static UpdateCheckerResult CheckForUpdates()
        {
            FileDownloaderResult fileDownlaoderResult = FileDownloader.Download(GITHUB_EXECUTABLE_URL, Path.Combine(Path.GetTempPath(), "AutoDbdFlexerEx.exe"));

            if (fileDownlaoderResult.Success)
            {
                FileVersionInfo newVersion = FileVersionInfo.GetVersionInfo(fileDownlaoderResult.FilePath);
                UpdateCheckerResult updateCheckerResult = new UpdateCheckerResult(Version.Parse(newVersion.FileVersion), fileDownlaoderResult.FilePath);
                if (!updateCheckerResult.CanUpdate) File.Delete(fileDownlaoderResult.FilePath);
                return updateCheckerResult;
            }
            else return new UpdateCheckerResult();
        }
    }
}
