namespace FindPasswordMD5HashExem
{
    partial class DescriptorSecure
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbRangAZ = new System.Windows.Forms.CheckBox();
            this.cbRangeNumber = new System.Windows.Forms.CheckBox();
            this.cbRangeaz = new System.Windows.Forms.CheckBox();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbMd5 = new System.Windows.Forms.TextBox();
            this.numThread = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.Result = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbRange = new System.Windows.Forms.GroupBox();
            this.epPassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.epThread = new System.Windows.Forms.ErrorProvider(this.components);
            this.epRangeChecked = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numThread)).BeginInit();
            this.gbRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epThread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRangeChecked)).BeginInit();
            this.SuspendLayout();
            // 
            // cbRangAZ
            // 
            this.cbRangAZ.AutoSize = true;
            this.cbRangAZ.Location = new System.Drawing.Point(15, 19);
            this.cbRangAZ.Name = "cbRangAZ";
            this.cbRangAZ.Size = new System.Drawing.Size(49, 17);
            this.cbRangAZ.TabIndex = 0;
            this.cbRangAZ.Text = "A - Z";
            this.cbRangAZ.UseVisualStyleBackColor = true;
            // 
            // cbRangeNumber
            // 
            this.cbRangeNumber.AutoSize = true;
            this.cbRangeNumber.Location = new System.Drawing.Point(16, 84);
            this.cbRangeNumber.Name = "cbRangeNumber";
            this.cbRangeNumber.Size = new System.Drawing.Size(47, 17);
            this.cbRangeNumber.TabIndex = 2;
            this.cbRangeNumber.Text = "0 - 9";
            this.cbRangeNumber.UseVisualStyleBackColor = true;
            // 
            // cbRangeaz
            // 
            this.cbRangeaz.AutoSize = true;
            this.cbRangeaz.Location = new System.Drawing.Point(16, 51);
            this.cbRangeaz.Name = "cbRangeaz";
            this.cbRangeaz.Size = new System.Drawing.Size(46, 17);
            this.cbRangeaz.TabIndex = 3;
            this.cbRangeaz.Text = "a - z";
            this.cbRangeaz.UseVisualStyleBackColor = true;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(64, 29);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(193, 20);
            this.tbPassword.TabIndex = 4;
            this.tbPassword.Validated += new System.EventHandler(this.TextBoxPasswordValidated);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Your Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(317, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "MD5 hash code";
            // 
            // tbMd5
            // 
            this.tbMd5.Location = new System.Drawing.Point(409, 29);
            this.tbMd5.Name = "tbMd5";
            this.tbMd5.Size = new System.Drawing.Size(100, 20);
            this.tbMd5.TabIndex = 7;
            // 
            // numThread
            // 
            this.numThread.Location = new System.Drawing.Point(121, 112);
            this.numThread.Name = "numThread";
            this.numThread.Size = new System.Drawing.Size(63, 20);
            this.numThread.TabIndex = 8;
            this.numThread.Validated += new System.EventHandler(this.NumThreadValidated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Thread amount";
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(217, 318);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(100, 20);
            this.tbResult.TabIndex = 10;
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Location = new System.Drawing.Point(101, 324);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(37, 13);
            this.Result.TabIndex = 11;
            this.Result.Text = "Result";
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(166, 262);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 12;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(307, 262);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbRange
            // 
            this.gbRange.Controls.Add(this.cbRangAZ);
            this.gbRange.Controls.Add(this.cbRangeaz);
            this.gbRange.Controls.Add(this.cbRangeNumber);
            this.gbRange.Location = new System.Drawing.Point(241, 112);
            this.gbRange.Name = "gbRange";
            this.gbRange.Size = new System.Drawing.Size(167, 122);
            this.gbRange.TabIndex = 14;
            this.gbRange.TabStop = false;
            this.gbRange.Text = "Range";
            this.gbRange.Validated += new System.EventHandler(this.GbRangeValidated);
            // 
            // epPassword
            // 
            this.epPassword.ContainerControl = this;
            // 
            // epThread
            // 
            this.epThread.ContainerControl = this;
            // 
            // epRangeChecked
            // 
            this.epRangeChecked.ContainerControl = this;
            // 
            // DescriptorSecure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 374);
            this.Controls.Add(this.gbRange);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numThread);
            this.Controls.Add(this.tbMd5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPassword);
            this.Name = "DescriptorSecure";
            this.Text = "Descriptor";
            ((System.ComponentModel.ISupportInitialize)(this.numThread)).EndInit();
            this.gbRange.ResumeLayout(false);
            this.gbRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epThread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRangeChecked)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbRangAZ;
        private System.Windows.Forms.CheckBox cbRangeNumber;
        private System.Windows.Forms.CheckBox cbRangeaz;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbMd5;
        private System.Windows.Forms.NumericUpDown numThread;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label Result;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbRange;
        private System.Windows.Forms.ErrorProvider epPassword;
        private System.Windows.Forms.ErrorProvider epThread;
        private System.Windows.Forms.ErrorProvider epRangeChecked;
    }
}

