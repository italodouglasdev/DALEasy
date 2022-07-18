
namespace DALEasy
{
    partial class Form_Cadastro
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
            this.Cadastro = new Cadastro();
            this.SuspendLayout();
            // 
            // Cadastro
            // 
            this.Cadastro.AutoScroll = true;
            this.Cadastro.Location = new System.Drawing.Point(12, 12);
            this.Cadastro.Name = "Cadastro";
            this.Cadastro.Size = new System.Drawing.Size(613, 390);
            this.Cadastro.TabIndex = 0;
            // 
            // Form_Cadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 416);
            this.Controls.Add(this.Cadastro);
            this.Name = "Form_Cadastro";
            this.Text = "Cadastro";
            this.Load += new System.EventHandler(this.Form_Cadastro_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Cadastro Cadastro;
    }
}