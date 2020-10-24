using System;

namespace AutoDbdFlexerEx.Model.Updater
{
    class FileDownloaderResult
    {
        private string _FilePath;

        public bool Success { get; }
        public string FilePath
        {
            get
            {
                if (!Success) throw new InvalidOperationException();
                return _FilePath;
            }
        }

        public FileDownloaderResult(string filePath)
        {
            Success = true;
            _FilePath = filePath;
        }
        /// <summary>
        /// Инициализирует объект, где Success = false
        /// </summary>
        public FileDownloaderResult()
        {
            Success = false;
        }
    }
}
