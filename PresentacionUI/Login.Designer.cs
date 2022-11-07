using System.Windows.Forms;

namespace Presentacion_UI
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
            this.button1 = new System.Windows.Forms.Button();
            this.ucmail23 = new Presentacion_UI.Ucmail2();
            this.ucmail22 = new Presentacion_UI.Ucmail2();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(59, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 29);
            this.button1.TabIndex = 4;
            this.button1.Text = "Iniciar sesion";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ucmail23
            // 
            this.ucmail23.LabelText = null;
            this.ucmail23.Location = new System.Drawing.Point(12, 82);
            this.ucmail23.Name = "ucmail23";
            this.ucmail23.RegexString = "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{4,8})$";
            this.ucmail23.Size = new System.Drawing.Size(258, 62);
            this.ucmail23.TextBox.PasswordChar = '*';
            this.ucmail23.label2.Text = "Pass:";
            this.ucmail23.TabIndex = 6;
            // 
            // ucmail22
            // 
            this.ucmail22.LabelText = null;
            this.ucmail22.Location = new System.Drawing.Point(12, 27);
            this.ucmail22.Name = "ucmail22";
            this.ucmail22.RegexString = "^\\S+@\\S+\\.\\S+$";
            this.ucmail22.Size = new System.Drawing.Size(258, 62);
            this.ucmail22.TabIndex = 5;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 203);
            this.Controls.Add(this.ucmail23);
            this.Controls.Add(this.ucmail22);
            this.Controls.Add(this.button1);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);

        }

        #endregion
        private Button button1;
        private Ucmail2 ucmail22;
        private Ucmail2 ucmail23;
    }
}