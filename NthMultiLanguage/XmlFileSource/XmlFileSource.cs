using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NthDeveloper.MultiLanguage
{
    public class XmlFileSource : ILanguagePackageSource
    {
        string _folderPath;
        string _fileExtension;

        public XmlFileSource(string folderPath, string fileExtension)
        {
            _folderPath = folderPath;
            _fileExtension = fileExtension;

            if (!_fileExtension.StartsWith("."))
                _fileExtension = "." + _fileExtension;
        }

        public IList<ILanguagePackage> GetAllPackages()
        {
            string[] foundFiles = getAllFiles();

            List<ILanguagePackage> packageList = new List<ILanguagePackage>(foundFiles.Length);

            foreach (string filePath in foundFiles)
            {
               packageList.Add(XmlLanguagePackage.LoadOnlyWithNameAndCodeFromFile(filePath));
            }

            return packageList;
        }

        public void LoadPackage(ILanguagePackage pack)
        {
            ((XmlLanguagePackage)pack).LoadFullData();
        }     
        
        private string[] getAllFiles()
        {
            return Directory.GetFiles(_folderPath, _fileExtension);
        }
    }
}
