using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace FindPasswordMD5HashExem
{
    public partial class DescriptorSecure : Form
    {
        private CancellationTokenSource _tokenSource;

        public DescriptorSecure()
        {
            InitializeComponent();
            _tokenSource=new CancellationTokenSource();
            cbRangAZ.Checked = true;
        }

       


        private void btnFind_Click(object sender, EventArgs e)
        {
            if (IsPasswordValid() && IsThreadValid() && IsCheckedRange())
            {
                btnFind.Enabled = false;   
                string password = this.tbPassword.Text;
                string md5hash = CalculateMd5.CalculateMd5Hash(password);
                this.tbMd5.Text = md5hash;
                PasswordOptions options=new PasswordOptions();
                if (cbRangAZ.Checked) options=options|PasswordOptions.Capital;
                if (cbRangeaz.Checked) options=options|PasswordOptions.Lower;
                if (cbRangeNumber.Checked) options=options|PasswordOptions.Numbers;
                int threadCount = (int) this.numThread.Value;
                Action<string> GetPassword;
                GetPassword = ReceivePassword;
                //Generator generator = new Generator(3, PasswordOptions.Capital, CalculateMd5.CalculateMd5Hash("ABC"), 3);
                Generator generator = new Generator(password.Length, options, md5hash, threadCount);
                _tokenSource=generator.ThreadCracker(GetPassword); 
            }
            else MessageBox.Show("Input data don't correct", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        public void ReceivePassword(string password)
        {
            lock(this)
            {
                if (_tokenSource != null)
                {
                    this.SetText(password);
                    _tokenSource.Cancel();
                    _tokenSource = null;
                    this.SetEnabled(true);
                    Console.WriteLine("Stopping tasks");
                }
            }
        }

        private void SetText(string text)
        {
            if (this.tbResult.InvokeRequired)
            {
                Action<string> d = SetText;
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.tbResult.Text = text;
            }
        }

        private void SetEnabled(bool enabled)
        {
            if (this.btnFind.InvokeRequired)
            {
                Action<bool> d = SetEnabled;
                this.Invoke(d, new object[] { enabled });
            }
            else
            {
                this.btnFind.Enabled = enabled;
            }
        }

        private void TextBoxPasswordValidated(object sender, EventArgs e)
        {
            if (IsPasswordValid() == false)
            {
                epPassword.SetError(this.tbPassword, "Password isn't required");

            }
            else
            {
                // Clear the error, if any, in the error provider.
                epPassword.SetError(this.tbPassword, String.Empty);
            }

        }

        private bool IsPasswordValid()
        {
            var password = this.tbPassword.Text;
            if (String.IsNullOrEmpty(password) || password.Length > 10) return false;
            Regex regPass=new Regex("^[0-9a-zA-Z]+$");
            if (!regPass.IsMatch(password)) return false;
            return true;
        }

        private void NumThreadValidated(object sender, EventArgs e)
        {
            if (!IsThreadValid())
            {
                epThread.SetError(this.numThread, "Set count threads");
            }
            else
            {
               epThread.SetError(this.numThread, String.Empty);
            }
        }
        private bool IsThreadValid()
        {
            var count = (int)this.numThread.Value;
            if (count > 0) return true;
            return false;
        }

        private void GbRangeValidated(object sender, EventArgs e)
        {
            if (IsCheckedRange()==false)
            {
                epRangeChecked.SetError(this.gbRange, "Checked range");
            }
            else
            {
                epThread.SetError(this.gbRange, String.Empty);
            }
        }

        private bool IsCheckedRange()
        {
            if (cbRangAZ.Checked || cbRangeNumber.Checked || cbRangeaz.Checked) return true;
            return false;
        }
    }
}
