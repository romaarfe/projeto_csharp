using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace HeroisMonstros
{
    partial class TelaInicial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaInicial));
            this.btnNovoJogo = new System.Windows.Forms.Button();
            this.btnCarregarJogo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNovoJogo
            // 
            this.btnNovoJogo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNovoJogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNovoJogo.FlatAppearance.BorderSize = 0;
            this.btnNovoJogo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnNovoJogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoJogo.Font = new System.Drawing.Font("Zero Cool", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNovoJogo.ForeColor = System.Drawing.Color.Black;
            this.btnNovoJogo.Location = new System.Drawing.Point(182, 326);
            this.btnNovoJogo.Name = "btnNovoJogo";
            this.btnNovoJogo.Size = new System.Drawing.Size(177, 41);
            this.btnNovoJogo.TabIndex = 0;
            this.btnNovoJogo.Text = "Novo Jogo";
            this.btnNovoJogo.UseVisualStyleBackColor = false;
            this.btnNovoJogo.Click += new System.EventHandler(this.btnNovoJogo_Click);
            // 
            // btnCarregarJogo
            // 
            this.btnCarregarJogo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCarregarJogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCarregarJogo.FlatAppearance.BorderSize = 0;
            this.btnCarregarJogo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnCarregarJogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarregarJogo.Font = new System.Drawing.Font("Zero Cool", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarregarJogo.ForeColor = System.Drawing.Color.Black;
            this.btnCarregarJogo.Location = new System.Drawing.Point(182, 386);
            this.btnCarregarJogo.Name = "btnCarregarJogo";
            this.btnCarregarJogo.Size = new System.Drawing.Size(177, 41);
            this.btnCarregarJogo.TabIndex = 1;
            this.btnCarregarJogo.Text = "Carregar Jogo";
            this.btnCarregarJogo.UseVisualStyleBackColor = false;
            this.btnCarregarJogo.Click += new System.EventHandler(this.btnCarregarJogo_Click);
            // 
            // TelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BackgroundImage = global::HeroisMonstros.Properties.Resources.RPG2__2_;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(541, 508);
            this.Controls.Add(this.btnCarregarJogo);
            this.Controls.Add(this.btnNovoJogo);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TelaInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela Inicial";
            this.ResumeLayout(false);

        }

        
        #endregion

        private System.Windows.Forms.Button btnNovoJogo;
        private System.Windows.Forms.Button btnCarregarJogo;
    }
}

