namespace TP1
{
    partial class Inicio
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.aBMDueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearDuenoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearPaseadorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarMascotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mascotasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aBMDueToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(800, 28);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // aBMDueToolStripMenuItem
            // 
            this.aBMDueToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.aBMDueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearDuenoToolStripMenuItem,
            this.crearPaseadorToolStripMenuItem,
            this.gestionarMascotasToolStripMenuItem,
            this.mascotasToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.aBMDueToolStripMenuItem.Name = "aBMDueToolStripMenuItem";
            this.aBMDueToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.aBMDueToolStripMenuItem.Text = "Menu";
            this.aBMDueToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // crearDuenoToolStripMenuItem
            // 
            this.crearDuenoToolStripMenuItem.Name = "crearDuenoToolStripMenuItem";
            this.crearDuenoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.crearDuenoToolStripMenuItem.Text = "Crear Dueno";
            this.crearDuenoToolStripMenuItem.Click += new System.EventHandler(this.crearDuenoToolStripMenuItem_Click);
            // 
            // crearPaseadorToolStripMenuItem
            // 
            this.crearPaseadorToolStripMenuItem.Name = "crearPaseadorToolStripMenuItem";
            this.crearPaseadorToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.crearPaseadorToolStripMenuItem.Text = "Crear Paseador";
            this.crearPaseadorToolStripMenuItem.Click += new System.EventHandler(this.crearPaseadorToolStripMenuItem_Click);
            // 
            // gestionarMascotasToolStripMenuItem
            // 
            this.gestionarMascotasToolStripMenuItem.Name = "gestionarMascotasToolStripMenuItem";
            this.gestionarMascotasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.gestionarMascotasToolStripMenuItem.Text = "Gestionar Mascotas";
            this.gestionarMascotasToolStripMenuItem.Click += new System.EventHandler(this.gestionarMascotasToolStripMenuItem_Click);
            // 
            // mascotasToolStripMenuItem
            // 
            this.mascotasToolStripMenuItem.Name = "mascotasToolStripMenuItem";
            this.mascotasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.mascotasToolStripMenuItem.Text = "Mascotas";
            this.mascotasToolStripMenuItem.Click += new System.EventHandler(this.mascotasToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip2);
            this.IsMdiContainer = true;
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip2;
        private ToolStripMenuItem aBMDueToolStripMenuItem;
        private ToolStripMenuItem crearDuenoToolStripMenuItem;
        private BindingSource bindingSource1;
        private ToolStripMenuItem crearPaseadorToolStripMenuItem;
        private ToolStripMenuItem gestionarMascotasToolStripMenuItem;
        private ToolStripMenuItem mascotasToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
    }
}