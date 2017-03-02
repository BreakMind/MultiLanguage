using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace NthDeveloper.MultiLanguage
{
    class XmlLanguagePackage : ILanguagePackage
    {
        private bool _isLoaded;
        private string _sourceFilePath;        
        private bool _hasSingleGroup;
        private Dictionary<string, string> _singleGroupCache;
        private Dictionary<string, Dictionary<string, string>> _multiGroupCache;

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
            if (_hasSingleGroup)
                return _singleGroupCache[key];

            foreach(string groupName in _multiGroupCache.Keys)
            {
                if (_multiGroupCache[groupName].ContainsKey(key))
                    return _multiGroupCache[groupName][key];
            }

            return key;
        }

        public string GetString(string groupName, string key)
        {
            if (_hasSingleGroup)
                return _singleGroupCache[key];

            return _multiGroupCache[groupName][key];
        }

        internal static XmlLanguagePackage LoadOnlyWithNameAndCodeFromFile(string filePath)
        {
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                reader.MoveToContent();

                return new XmlLanguagePackage(filePath, reader.GetAttribute("Code"), reader.GetAttribute("Name"));
            }
        }

        internal void LoadFullData()
        {
            if (_isLoaded)
                return;

            XmlLanguageData languageData = null;
            XmlSerializer serializer = new XmlSerializer(typeof(XmlLanguageData));

            using (FileStream fs = File.OpenRead(_sourceFilePath))
            {
                languageData = (XmlLanguageData)serializer.Deserialize(fs);
            }

            prepareFastAccessCaches(languageData);

            _isLoaded = true;
        }

        private void prepareFastAccessCaches(XmlLanguageData languageData)
        {
            var _translationGroups = languageData.Groups;
            _hasSingleGroup = _translationGroups.Count == 1;

            if(_hasSingleGroup)
            {
                _singleGroupCache = createCacheFromGroup(languageData.Groups[0]);
            }
            else
            {
                _multiGroupCache = new Dictionary<string, Dictionary<string, string>>(languageData.Groups.Count);

                for (int i = 0; i < languageData.Groups.Count; i++)
                    _multiGroupCache.Add(languageData.Groups[i].Name, createCacheFromGroup(languageData.Groups[i]));
            }
        }

        private Dictionary<string, string> createCacheFromGroup(XmlLanguageTranslationGroup group)
        {
            Dictionary<string, string> dictionaryCache = new Dictionary<string, string>(group.Items.Count);

            for(int i=0;i< group.Items.Count;i++)
            {
                var translationItem = group.Items[i];

                dictionaryCache.Add(translationItem.Name, translationItem.Value);
            }

            return dictionaryCache;
        }
    }
}
