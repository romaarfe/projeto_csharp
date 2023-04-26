// PROJETO DE PROGRAMAÇÃO - 25 HORAS
// FORMADOR: PAULO JORGE

// TEMA: HERÓIS VS MONSTROS
// FORMANDO: RODRIGO FERNANDES - Nº 13

// ÁREA DOS IMPORTS
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diversos;

// NAMESPACE PRINCIPAL
namespace HeroisMonstros
{
    // CLASSE PRINCIPAL E SUA HERANÇA
    public partial class TelaInicial : Form
    {
        // CONSTRUTOR PRINCIPAL
        public TelaInicial()
        {
            InitializeComponent();
            ConfigurarBotoes();
            TocarMusicaTema();
        }

        // MÉTODO PARA CONFIGURAR OS BOTÕES EMULANDO EFEITO 3D
        private void ConfigurarBotoes()
        {
            Configuracoes configuracoes = new Configuracoes();
            this.btnNovoJogo.Paint += new PaintEventHandler(configuracoes.pintar_Botoes3D);
            this.btnCarregarJogo.Paint += new PaintEventHandler(configuracoes.pintar_Botoes3D);
        }

        // EVENTO QUE INSTANCIA/ABRE NOVO FORM (NOVOJOGO), FECHANDO O ATUAL, PARA CRIAÇÃO DO HERÓI
        private void btnNovoJogo_Click(object sender, EventArgs e)
        {
            this.Hide();
            NovoJogo novoJogo = new NovoJogo();
            novoJogo.Closed += (s, args) => this.Close();
            novoJogo.Show();
        }

        // EVENTO QUE INSTANCIA/ABRE NOVO FORM (CARREGARJOGO), FECHANDO O ATUAL, PARA SELEÇÃO DE HERÓI PREVIAMENTE CRIADO
        private void btnCarregarJogo_Click(object sender, EventArgs e)
        {
            this.Hide();
            CarregarJogo carregarJogo = new CarregarJogo();
            carregarJogo.Closed += (s, args) => this.Close();
            carregarJogo.Show();
        }

        // MÉTODO PARA INSTANCIAR, BUSCAR E TOCAR A MÚSICA TEMA
        private void TocarMusicaTema()
        {
            SoundPlayer tocador = new SoundPlayer();
            tocador.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\ps4ahappysettlement1.wav";
            tocador.PlayLooping();
        }
    }
}
