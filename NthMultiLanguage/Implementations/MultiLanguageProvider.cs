using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NthDeveloper.MultiLanguage
{
    public class MultiLanguageProvider : IMultiLanguageProvider
    {
        private List<ILanguagePackage> _allPackages;
        private ILanguagePackage _currentPackage;
        private ILanguagePackageSource _packageSource;

        public event LanguagePackageChangedHandler CurrentPackageChanged;

        public IList<ILanguagePackage> AllPackages { get; private set; }

        public ILanguagePackage CurrentPackage
        {
            get { return _currentPackage; }
            private set
            {
                if (value == _currentPackage)
                    return;

                _currentPackage = value;

                if (CurrentPackageChanged != null)
                    CurrentPackageChanged(this, _currentPackage);
            }
        }

        public MultiLanguageProvider(ILanguagePackageSource packageSource)
        {
            _packageSource = packageSource;

            _allPackages = new List<ILanguagePackage>();
            this.AllPackages = _allPackages.AsReadOnly();

            _allPackages.AddRange(_packageSource.GetAllPackages());
        }

        public void SetCurrentLanguage(string languageCode)
        {
            ILanguagePackage package = _allPackages.FirstOrDefault(x => x.LanguageCode == languageCode);
            if (package == null)
                throw new Exception("Specified language package could not be found.");

            _packageSource.LoadPackage(package);

            this.CurrentPackage = package;
        }

        public string GetString(string key)
        {
            return _currentPackage.GetString(key);
        }

        public string GetString(string groupName, string key)
        {
            return _currentPackage.GetString(groupName, key);
        }
    }
}
