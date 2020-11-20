namespace PresentationLayerWP
{
    partial class Room
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
            this.txtroomnumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtroombaseprice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvroom = new System.Windows.Forms.DataGridView();
            this.btncleanfields = new System.Windows.Forms.Button();
            this.btnregister = new System.Windows.Forms.Button();
            this.cbcategory = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvroom)).BeginInit();
            this.SuspendLayout();
            // 
            // txtroomnumber
            // 
            this.txtroomnumber.Location = new System.Drawing.Point(12, 91);
            this.txtroomnumber.Name = "txtroomnumber";
            this.txtroomnumber.Size = new System.Drawing.Size(229, 22);
            this.txtroomnumber.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Número quarto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Preço base";
            // 
            // txtroombaseprice
            // 
            this.txtroombaseprice.Location = new System.Drawing.Point(12, 150);
            this.txtroombaseprice.Name = "txtroombaseprice";
            this.txtroombaseprice.Size = new System.Drawing.Size(229, 22);
            this.txtroombaseprice.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Categoria";
            // 
            // dgvroom
            // 
            this.dgvroom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvroom.Location = new System.Drawing.Point(276, 33);
            this.dgvroom.Name = "dgvroom";
            this.dgvroom.RowHeadersWidth = 51;
            this.dgvroom.RowTemplate.Height = 24;
            this.dgvroom.Size = new System.Drawing.Size(525, 366);
            this.dgvroom.TabIndex = 6;
            // 
            // btncleanfields
            // 
            this.btncleanfields.Location = new System.Drawing.Point(12, 200);
            this.btncleanfields.Name = "btncleanfields";
            this.btncleanfields.Size = new System.Drawing.Size(229, 34);
            this.btncleanfields.TabIndex = 7;
            this.btncleanfields.Text = "Limpar campos";
            this.btncleanfields.UseVisualStyleBackColor = true;
            this.btncleanfields.Click += new System.EventHandler(this.btncleanfields_Click);
            // 
            // btnregister
            // 
            this.btnregister.Location = new System.Drawing.Point(12, 240);
            this.btnregister.Name = "btnregister";
            this.btnregister.Size = new System.Drawing.Size(229, 34);
            this.btnregister.TabIndex = 8;
            this.btnregister.Text = "Cadastrar";
            this.btnregister.UseVisualStyleBackColor = true;
            this.btnregister.Click += new System.EventHandler(this.btnregister_Click);
            // 
            // cbcategory
            // 
            this.cbcategory.FormattingEnabled = true;
            this.cbcategory.Location = new System.Drawing.Point(12, 33);
            this.cbcategory.Name = "cbcategory";
            this.cbcategory.Size = new System.Drawing.Size(229, 24);
            this.cbcategory.TabIndex = 9;
            // 
            // RoomRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 418);
            this.Controls.Add(this.cbcategory);
            this.Controls.Add(this.btnregister);
            this.Controls.Add(this.btncleanfields);
            this.Controls.Add(this.dgvroom);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtroombaseprice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtroomnumber);
            this.Name = "RoomRegisterForm";
            this.Text = "RoomRegisterForm";
            this.Load += new System.EventHandler(this.RoomRegisterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvroom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtroomnumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtroombaseprice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvroom;
        private System.Windows.Forms.Button btncleanfields;
        private System.Windows.Forms.Button btnregister;
        private System.Windows.Forms.ComboBox cbcategory;
    }
}