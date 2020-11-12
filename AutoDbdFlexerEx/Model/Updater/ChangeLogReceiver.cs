using System.IO;
using System.Threading.Tasks;

namespace AutoDbdFlexerEx.Model.Updater
{
    static class ChangeLogReceiver
    {
        public const string GITHUB_CHANGELOG_URL = "http://github.com/TrickyBestia/autodbdflexerex/raw/master/Changelog.txt";

        public static async Task<ChangeLogReceiverResult> GetChangeLogAsync()
        {
            return await Task.Run(GetChangeLog);
        }
        public static ChangeLogReceiverResult GetChangeLog()
        {
            FileDownloaderResult fileDownloaderResult = FileDownloader.Download(GITHUB_CHANGELOG_URL, Path.Combine(Path.GetTempPath(), "AutoDbdFlexerExChangelog.txt"));
            if (fileDownloaderResult.Success)
                return new ChangeLogReceiverResult(fileDownloaderResult.FilePath);
            else return new ChangeLogReceiverResult();
        }
    }
}
