using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace NthDeveloper.MultiLanguage
{
    class XmlLanguagePackage : ILanguagePackage
    {
        private bool _isLoaded;
        private string _sourceFilePath;

        public bool IsLoaded { get { return _isLoaded; } }

        public string LanguageCode { get; private set; }

        public string LanguageName { get; private set; }

        private XmlLanguagePackage(string sourceFilePath, string languageCode, string languageName)
        {
            _sourceFilePath = sourceFilePath;
            this.LanguageCode = languageCode;
            this.LanguageName = languageName;
        }

        public string GetString(string key)
        {
            throw new NotImplementedException();
        }

        public string GetString(string groupName, string key)
        {
            throw new NotImplementedException();
        }

        internal static XmlLanguagePackage LoadOnlyWithNameAndCodeFromFile(string filePath)
        {
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                reader.MoveToContent();

                return new XmlLanguagePackage(filePath, reader.GetAttribute("Code"), reader.GetAttribute("Name"));
            }
        }
    }
}
