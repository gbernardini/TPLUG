namespace Presentacion_UI
{
    partial class Ucmail2
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mail:";
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(86, 15);
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(190, 27);
            this.TextBox.TabIndex = 5;
            // 
            // Ucmail2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TextBox);
            this.Name = "Ucmail2";
            this.Size = new System.Drawing.Size(294, 50);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label label2;
        public TextBox TextBox;
    }
}
