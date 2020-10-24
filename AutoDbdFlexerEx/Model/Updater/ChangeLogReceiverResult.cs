using System;

namespace AutoDbdFlexerEx.Model.Updater
{
    class ChangeLogReceiverResult
    {
        private string _ChangeLogFilePath;

        public bool Success { get; }
        public string ChangeLogFilePath
        {
            get
            {
                if (!Success) throw new InvalidOperationException();
                return _ChangeLogFilePath;
            }
        }

        public ChangeLogReceiverResult(string changeLogFilePath)
        {
            Success = true;
            _ChangeLogFilePath = changeLogFilePath;
        }
        /// <summary>
        /// Инициализирует объект, где Success = false
        /// </summary>
        public ChangeLogReceiverResult()
        {
            Success = false;
        }
    }
}
