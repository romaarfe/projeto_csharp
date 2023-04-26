using System.Windows.Forms;

namespace HeroisMonstros
{
    partial class CarregarJogo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarregarJogo));
            this.lblEscolhaSeuPersonagem = new System.Windows.Forms.Label();
            this.lstEscolhaSeuPersonagem = new System.Windows.Forms.ListBox();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.btnIniciarJogo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEscolhaSeuPersonagem
            // 
            this.lblEscolhaSeuPersonagem.AutoSize = true;
            this.lblEscolhaSeuPersonagem.BackColor = System.Drawing.Color.Transparent;
            this.lblEscolhaSeuPersonagem.Font = new System.Drawing.Font("Zero Cool", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEscolhaSeuPersonagem.ForeColor = System.Drawing.Color.Gold;
            this.lblEscolhaSeuPersonagem.Location = new System.Drawing.Point(125, 9);
            this.lblEscolhaSeuPersonagem.Name = "lblEscolhaSeuPersonagem";
            this.lblEscolhaSeuPersonagem.Size = new System.Drawing.Size(278, 225);
            this.lblEscolhaSeuPersonagem.TabIndex = 0;
            this.lblEscolhaSeuPersonagem.Text = "ESCOLHA\r\nSEU\r\nPERSONAGEM\r\n\r\n\r\n";
            this.lblEscolhaSeuPersonagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstEscolhaSeuPersonagem
            // 
            this.lstEscolhaSeuPersonagem.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lstEscolhaSeuPersonagem.Font = new System.Drawing.Font("Zero Cool", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEscolhaSeuPersonagem.ForeColor = System.Drawing.Color.Black;
            this.lstEscolhaSeuPersonagem.FormattingEnabled = true;
            this.lstEscolhaSeuPersonagem.ItemHeight = 26;
            this.lstEscolhaSeuPersonagem.Location = new System.Drawing.Point(47, 164);
            this.lstEscolhaSeuPersonagem.Name = "lstEscolhaSeuPersonagem";
            this.lstEscolhaSeuPersonagem.Size = new System.Drawing.Size(449, 212);
            this.lstEscolhaSeuPersonagem.TabIndex = 1;
            this.lstEscolhaSeuPersonagem.SelectedIndexChanged += new System.EventHandler(this.lstEscolhaSeuPersonagem_SelectedIndexChanged);
            // 
            // btnVoltar
            // 
            this.btnVoltar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnVoltar.FlatAppearance.BorderSize = 0;
            this.btnVoltar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVoltar.Font = new System.Drawing.Font("Zero Cool", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.ForeColor = System.Drawing.Color.Black;
            this.btnVoltar.Location = new System.Drawing.Point(47, 438);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(177, 41);
            this.btnVoltar.TabIndex = 2;
            this.btnVoltar.Text = "VOLTAR";
            this.btnVoltar.UseVisualStyleBackColor = false;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // btnIniciarJogo
            // 
            this.btnIniciarJogo.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnIniciarJogo.FlatAppearance.BorderSize = 0;
            this.btnIniciarJogo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnIniciarJogo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarJogo.Font = new System.Drawing.Font("Zero Cool", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarJogo.ForeColor = System.Drawing.Color.Black;
            this.btnIniciarJogo.Location = new System.Drawing.Point(319, 438);
            this.btnIniciarJogo.Name = "btnIniciarJogo";
            this.btnIniciarJogo.Size = new System.Drawing.Size(177, 41);
            this.btnIniciarJogo.TabIndex = 3;
            this.btnIniciarJogo.Text = "INICIAR JOGO";
            this.btnIniciarJogo.UseVisualStyleBackColor = false;
            this.btnIniciarJogo.Click += new System.EventHandler(this.btnIniciarJogo_Click);
            // 
            // CarregarJogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::HeroisMonstros.Properties.Resources.bludng;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(541, 508);
            this.Controls.Add(this.btnIniciarJogo);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.lstEscolhaSeuPersonagem);
            this.Controls.Add(this.lblEscolhaSeuPersonagem);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CarregarJogo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Carregar Jogo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEscolhaSeuPersonagem;
        private System.Windows.Forms.ListBox lstEscolhaSeuPersonagem;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Button btnIniciarJogo;
    }
}