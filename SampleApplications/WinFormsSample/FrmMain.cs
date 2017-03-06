using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NthDeveloper.MultiLanguage;

namespace WinFormsSample
{
    public partial class FrmMain : Form
    {
        IMultiLanguageProvider m_LanguageProvider;

        public FrmMain(IMultiLanguageProvider languageProvider)
        {
            InitializeComponent();

            m_LanguageProvider = languageProvider;

            translateUI();
        }

        private void translateUI()
        {
            this.Text = m_LanguageProvider.GetString("AppTitle");
        }
    }
}
