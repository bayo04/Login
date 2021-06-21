
namespace BruteForce
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHash = new System.Windows.Forms.Button();
            this.btnSalt = new System.Windows.Forms.Button();
            this.btnPepper = new System.Windows.Forms.Button();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLoading = new System.Windows.Forms.Label();
            this.rdbHash = new System.Windows.Forms.RadioButton();
            this.rdbSalt = new System.Windows.Forms.RadioButton();
            this.rdbPepper = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(13, 36);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(438, 27);
            this.txtPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "File path";
            // 
            // btnHash
            // 
            this.btnHash.Location = new System.Drawing.Point(166, 174);
            this.btnHash.Name = "btnHash";
            this.btnHash.Size = new System.Drawing.Size(94, 29);
            this.btnHash.TabIndex = 2;
            this.btnHash.Text = "Samo hash";
            this.btnHash.UseVisualStyleBackColor = true;
            this.btnHash.Click += new System.EventHandler(this.btnHash_Click);
            // 
            // btnSalt
            // 
            this.btnSalt.Location = new System.Drawing.Point(262, 173);
            this.btnSalt.Name = "btnSalt";
            this.btnSalt.Size = new System.Drawing.Size(94, 29);
            this.btnSalt.TabIndex = 3;
            this.btnSalt.Text = "Sa soli";
            this.btnSalt.UseVisualStyleBackColor = true;
            this.btnSalt.Click += new System.EventHandler(this.btnSalt_Click);
            // 
            // btnPepper
            // 
            this.btnPepper.Location = new System.Drawing.Point(358, 174);
            this.btnPepper.Name = "btnPepper";
            this.btnPepper.Size = new System.Drawing.Size(94, 29);
            this.btnPepper.TabIndex = 4;
            this.btnPepper.Text = "Sa paprom";
            this.btnPepper.UseVisualStyleBackColor = true;
            this.btnPepper.Click += new System.EventHandler(this.btnPepper_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(93, 69);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(92, 27);
            this.txtUsername.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Username";
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Location = new System.Drawing.Point(27, 123);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(0, 20);
            this.lblLoading.TabIndex = 7;
            // 
            // rdbHash
            // 
            this.rdbHash.AutoSize = true;
            this.rdbHash.Checked = true;
            this.rdbHash.Location = new System.Drawing.Point(208, 71);
            this.rdbHash.Name = "rdbHash";
            this.rdbHash.Size = new System.Drawing.Size(63, 24);
            this.rdbHash.TabIndex = 8;
            this.rdbHash.TabStop = true;
            this.rdbHash.Text = "Hash";
            this.rdbHash.UseVisualStyleBackColor = true;
            // 
            // rdbSalt
            // 
            this.rdbSalt.AutoSize = true;
            this.rdbSalt.Location = new System.Drawing.Point(208, 103);
            this.rdbSalt.Name = "rdbSalt";
            this.rdbSalt.Size = new System.Drawing.Size(51, 24);
            this.rdbSalt.TabIndex = 9;
            this.rdbSalt.Text = "Sol";
            this.rdbSalt.UseVisualStyleBackColor = true;
            // 
            // rdbPepper
            // 
            this.rdbPepper.AutoSize = true;
            this.rdbPepper.Location = new System.Drawing.Point(208, 133);
            this.rdbPepper.Name = "rdbPepper";
            this.rdbPepper.Size = new System.Drawing.Size(67, 24);
            this.rdbPepper.TabIndex = 10;
            this.rdbPepper.Text = "Papar";
            this.rdbPepper.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 222);
            this.Controls.Add(this.rdbPepper);
            this.Controls.Add(this.rdbSalt);
            this.Controls.Add(this.rdbHash);
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.btnPepper);
            this.Controls.Add(this.btnSalt);
            this.Controls.Add(this.btnHash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHash;
        private System.Windows.Forms.Button btnSalt;
        private System.Windows.Forms.Button btnPepper;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.RadioButton rdbHash;
        private System.Windows.Forms.RadioButton rdbSalt;
        private System.Windows.Forms.RadioButton rdbPepper;
    }
}

