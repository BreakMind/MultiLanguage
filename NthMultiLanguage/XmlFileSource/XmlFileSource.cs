using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NthDeveloper.MultiLanguage
{
    public class XmlFileSource : ILanguagePackageSource
    {
        public XmlFileSource(string folderPath, string fileExtension)
        {

        }

        public IList<ILanguagePackage> GetAllPackages()
        {
            throw new NotImplementedException();
        }

        public void LoadPackage(ILanguagePackage pack)
        {
            throw new NotImplementedException();
        }        
    }
}
