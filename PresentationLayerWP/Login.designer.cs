namespace PresentationLayerWP
{
    partial class Login
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
            this.logarbtn = new System.Windows.Forms.Button();
            this.emailtxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.senhatxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // logarbtn
            // 
            this.logarbtn.Location = new System.Drawing.Point(155, 220);
            this.logarbtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.logarbtn.Name = "logarbtn";
            this.logarbtn.Size = new System.Drawing.Size(181, 70);
            this.logarbtn.TabIndex = 0;
            this.logarbtn.Text = "Logar";
            this.logarbtn.UseVisualStyleBackColor = true;
            this.logarbtn.Click += new System.EventHandler(this.logarbtn_Click);
            // 
            // emailtxt
            // 
            this.emailtxt.Location = new System.Drawing.Point(16, 75);
            this.emailtxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.emailtxt.Name = "emailtxt";
            this.emailtxt.Size = new System.Drawing.Size(199, 22);
            this.emailtxt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 124);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Senha";
            // 
            // senhatxt
            // 
            this.senhatxt.Location = new System.Drawing.Point(20, 170);
            this.senhatxt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.senhatxt.Name = "senhatxt";
            this.senhatxt.Size = new System.Drawing.Size(195, 22);
            this.senhatxt.TabIndex = 3;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 305);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.senhatxt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.emailtxt);
            this.Controls.Add(this.logarbtn);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button logarbtn;
        private System.Windows.Forms.TextBox emailtxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox senhatxt;
    }
}