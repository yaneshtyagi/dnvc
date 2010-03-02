using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace dotNetFWVersionChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = ".Net Framework Installed: \r\n";
            RegistryKey installed_versions = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
            string[] version_names = installed_versions.GetSubKeyNames();
            //version names start with 'v', eg, 'v3.5' which needs to be trimmed off before conversion
            double Framework = Convert.ToDouble(version_names[version_names.Length - 1].Remove(0, 1));
            for (int i = 0; i < version_names.Length; i++)
            {
                //int SP = Convert.ToInt32(installed_versions.OpenSubKey(version_names[version_names.Length - 1]).GetValue("SP", 0));
                int SP = Convert.ToInt32(installed_versions.OpenSubKey(version_names[i]).GetValue("SP", 0));
                label1.Text += version_names[i] + (SP > 0 ? " SP " + SP.ToString() : "") + "\r\n";
            }
        }
    }
}
