namespace Pizzaria.WinApp
{
    partial class PrincipalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolStripbtnGravar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripbtnEditar = new System.Windows.Forms.ToolStripButton();
            this.ToolStripbtnExcluir = new System.Windows.Forms.ToolStripButton();
            this.panelControl = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastroToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1045, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastroToolStripMenuItem
            // 
            this.cadastroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClienteToolStripMenuItem});
            this.cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            this.cadastroToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.cadastroToolStripMenuItem.Text = "Arquivo";
            // 
            // ClienteToolStripMenuItem
            // 
            this.ClienteToolStripMenuItem.Name = "ClienteToolStripMenuItem";
            this.ClienteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ClienteToolStripMenuItem.Text = "Cliente";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripbtnGravar,
            this.ToolStripbtnEditar,
            this.ToolStripbtnExcluir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1045, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ToolStripbtnGravar
            // 
            this.ToolStripbtnGravar.Enabled = false;
            this.ToolStripbtnGravar.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripbtnGravar.Image")));
            this.ToolStripbtnGravar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripbtnGravar.Name = "ToolStripbtnGravar";
            this.ToolStripbtnGravar.Size = new System.Drawing.Size(61, 22);
            this.ToolStripbtnGravar.Text = "Gravar";
            this.ToolStripbtnGravar.Click += new System.EventHandler(this.ToolStripbtnGravar_Click);
            // 
            // ToolStripbtnEditar
            // 
            this.ToolStripbtnEditar.Enabled = false;
            this.ToolStripbtnEditar.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripbtnEditar.Image")));
            this.ToolStripbtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripbtnEditar.Name = "ToolStripbtnEditar";
            this.ToolStripbtnEditar.Size = new System.Drawing.Size(57, 22);
            this.ToolStripbtnEditar.Text = "Editar";
            this.ToolStripbtnEditar.Click += new System.EventHandler(this.ToolStripbtnEditar_Click);
            // 
            // ToolStripbtnExcluir
            // 
            this.ToolStripbtnExcluir.Enabled = false;
            this.ToolStripbtnExcluir.Image = ((System.Drawing.Image)(resources.GetObject("ToolStripbtnExcluir.Image")));
            this.ToolStripbtnExcluir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolStripbtnExcluir.Name = "ToolStripbtnExcluir";
            this.ToolStripbtnExcluir.Size = new System.Drawing.Size(61, 22);
            this.ToolStripbtnExcluir.Text = "Excluir";
            this.ToolStripbtnExcluir.Click += new System.EventHandler(this.ToolStripbtnExcluir_Click);
            // 
            // panelControl
            // 
            this.panelControl.Location = new System.Drawing.Point(12, 52);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(1021, 516);
            this.panelControl.TabIndex = 2;
            // 
            // PrincipalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 580);
            this.Controls.Add(this.panelControl);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "PrincipalForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tiagão Calzone e Pizzas";
            this.Load += new System.EventHandler(this.PrincipalForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolStripbtnGravar;
        private System.Windows.Forms.ToolStripButton ToolStripbtnEditar;
        private System.Windows.Forms.ToolStripButton ToolStripbtnExcluir;
        private System.Windows.Forms.Panel panelControl;
    }
}

