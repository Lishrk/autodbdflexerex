using System;
using System.Reflection;

namespace AutoDbdFlexerEx.Model.Updater
{
    public class UpdateCheckerResult
    {
        private readonly bool _Success;
        private Version _NewVersion;
        private string _UpdatedFilePath;

        public bool Success
        {
            get
            {
                return _Success;
            }
        }
        public bool CanUpdate
        {
            get
            {
                if (!Success) throw new InvalidOperationException();
                return NewVersion > CurrentVersion;
            }
        }
        public Version NewVersion
        {
            get
            {
                if (!Success) throw new InvalidOperationException();
                return _NewVersion;
            }
        }
        public Version CurrentVersion
        {
            get
            {
                if (!Success) throw new InvalidOperationException();
                return Assembly.GetExecutingAssembly().GetName().Version;
            }
        }
        public string UpdatedFilePath
        {
            get
            {
                if (!Success || !CanUpdate) throw new InvalidOperationException();
                return _UpdatedFilePath;
            }
        }

        public UpdateCheckerResult(Version newVersion, string updatedFilePath)
        {
            _Success = true;
            _UpdatedFilePath = updatedFilePath;
            _NewVersion = newVersion;
        }
        /// <summary>
        /// Инициализирует объект, где Success = false
        /// </summary>
        public UpdateCheckerResult()
        {
            _Success = false;
        }
    }
}
