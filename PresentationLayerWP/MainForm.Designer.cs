namespace PresentationLayerWP
{
    partial class MainForm
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
            this.btncustomerregister = new System.Windows.Forms.Button();
            this.btnsupplierregister = new System.Windows.Forms.Button();
            this.btnroomregister = new System.Windows.Forms.Button();
            this.btnemployeeregister = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btncustomerregister
            // 
            this.btncustomerregister.Location = new System.Drawing.Point(12, 12);
            this.btncustomerregister.Name = "btncustomerregister";
            this.btncustomerregister.Size = new System.Drawing.Size(174, 46);
            this.btncustomerregister.TabIndex = 0;
            this.btncustomerregister.Text = "Cadastro Cliente";
            this.btncustomerregister.UseVisualStyleBackColor = true;
            this.btncustomerregister.Click += new System.EventHandler(this.btncustomerregister_Click);
            // 
            // btnsupplierregister
            // 
            this.btnsupplierregister.Location = new System.Drawing.Point(12, 80);
            this.btnsupplierregister.Name = "btnsupplierregister";
            this.btnsupplierregister.Size = new System.Drawing.Size(174, 46);
            this.btnsupplierregister.TabIndex = 1;
            this.btnsupplierregister.Text = "Cadastro Fornecedor";
            this.btnsupplierregister.UseVisualStyleBackColor = true;
            this.btnsupplierregister.Click += new System.EventHandler(this.btnsupplierregister_Click);
            // 
            // btnroomregister
            // 
            this.btnroomregister.Location = new System.Drawing.Point(12, 220);
            this.btnroomregister.Name = "btnroomregister";
            this.btnroomregister.Size = new System.Drawing.Size(174, 46);
            this.btnroomregister.TabIndex = 3;
            this.btnroomregister.Text = "Cadastro Quarto";
            this.btnroomregister.UseVisualStyleBackColor = true;
            this.btnroomregister.Click += new System.EventHandler(this.btnroomregister_Click);
            // 
            // btnemployeeregister
            // 
            this.btnemployeeregister.Location = new System.Drawing.Point(12, 152);
            this.btnemployeeregister.Name = "btnemployeeregister";
            this.btnemployeeregister.Size = new System.Drawing.Size(174, 46);
            this.btnemployeeregister.TabIndex = 2;
            this.btnemployeeregister.Text = "Cadastro Funcionário";
            this.btnemployeeregister.UseVisualStyleBackColor = true;
            this.btnemployeeregister.Click += new System.EventHandler(this.btnemployeeregister_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(215, 220);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(174, 46);
            this.button5.TabIndex = 7;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(215, 152);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(174, 46);
            this.button6.TabIndex = 6;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(215, 80);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(174, 46);
            this.button7.TabIndex = 5;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(215, 12);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(174, 46);
            this.button8.TabIndex = 4;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 283);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.btnroomregister);
            this.Controls.Add(this.btnemployeeregister);
            this.Controls.Add(this.btnsupplierregister);
            this.Controls.Add(this.btncustomerregister);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btncustomerregister;
        private System.Windows.Forms.Button btnsupplierregister;
        private System.Windows.Forms.Button btnroomregister;
        private System.Windows.Forms.Button btnemployeeregister;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
    }
}