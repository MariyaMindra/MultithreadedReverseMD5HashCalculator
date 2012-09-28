using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FindPasswordMD5HashExem
{
    public partial class DescriptorSecure : Form
    {
        
        //private int ThreadCount { get; set; }
        //private int PasswdLength { get; set; }
        //private PasswordOptions RangeOptions { get; set; }


        public DescriptorSecure()
        {
            InitializeComponent();
        }

       


        private void btnFind_Click(object sender, EventArgs e)
        {
            btnFind.Enabled = false;
            Generator generator = new Generator(3, PasswordOptions.Capital, CalculateMd5.CalculateMd5Hash("ABC"), 3);
            generator.ThreadCracker();
            //Console.WriteLine(generator.Password);
            tbResult.Text = generator.Password;
            //RangeCalculateForThreads.GetStartingPoints(5, 4, PasswordOptions.Capital);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
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
            return true;

        }
   

    }
}
