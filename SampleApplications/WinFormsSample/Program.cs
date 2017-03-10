using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using NthDeveloper.MultiLanguage;

namespace WinFormsSample
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //XML file sample
            string _xmlLangugeFilesFolder = Path.GetFullPath(@"..\..\SampleData\XML");

            XmlFileSource _xmlFileSource = new XmlFileSource(_xmlLangugeFilesFolder);
            MultiLanguageProvider _languageProvider = new MultiLanguageProvider(_xmlFileSource);

            //Text file sample
            /*
            string _txtLangugeFilesFolder = Path.GetFullPath(@"..\..\SampleData\Text");

            TextFileSource _textFileSource = new TextFileSource(_txtLangugeFilesFolder);
            MultiLanguageProvider _languageProvider = new MultiLanguageProvider(_textFileSource);
            */

            _languageProvider.SetCurrentLanguage("en-US");            

            Application.Run(new FrmMain(_languageProvider));
        }
    }
}
