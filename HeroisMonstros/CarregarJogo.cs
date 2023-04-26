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
    public partial class CarregarJogo : Form
    {
        // CONSTRUTOR PRINCIPAL
        public CarregarJogo()
        {
            InitializeComponent();
            ConfigurarBotoes();
            PreencherLista();
        }

        // VARIÁVEL DA CLASSE
        public string NomeHeroi;

        // MÉTODO PARA CONFIGURAR OS BOTÕES EMULANDO EFEITO 3D
        private void ConfigurarBotoes()
        {
            Configuracoes configuracoes = new Configuracoes();
            this.btnIniciarJogo.Paint += new PaintEventHandler(configuracoes.pintar_Botoes3D);
            this.btnVoltar.Paint += new PaintEventHandler(configuracoes.pintar_Botoes3D);
        }

        // MÉTODO PARA BUSCAR NA BASE DE DADOS (TABELA HERÓI), OS HERÓIS PREVIAMENTE CRIADOS E APRESENTÁ-LOS NUMA LISTBOX
        private void PreencherLista()
        {
            Conecta conecta = new Conecta();
        
            lstEscolhaSeuPersonagem.DisplayMember = "Nome";
            conecta.StrSQL = "SELECT Nome FROM Heroi;";

            lstEscolhaSeuPersonagem.DataSource = conecta.BuscarDados();
        }

        // EVENTO RESPONSÁVEL POR FECHAR O FORM ATUAL, INSTANCIAR O NOVO FORM, PARA INÍCIO DE FATO DO JOGO
        private void btnIniciarJogo_Click(object sender, EventArgs e)
        {
            this.Hide();
            Encontro masmorra = new Encontro(NomeHeroi);
            masmorra.Closed += (s, args) => this.Close();

            // PARA INSTANCIAR, BUSCAR E TOCAR A MÚSICA TEMA NO PRÓXIMO FORM
            SoundPlayer tocador = new SoundPlayer();
            tocador.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\ps4edgeofdarkness1.wav";
            tocador.PlayLooping();

            // ABRE NOVO FORM (ENCONTRO)
            masmorra.Show();
        }

        // EVENTO RELACIONADO AO BOTÃO QUE PERMITE RETORNAR AO FORM ANTERIOR (TELAINICIAL)
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaInicial telaInicial = new TelaInicial();
            telaInicial.Closed += (s, args) => this.Close();
            telaInicial.Show();
        }

        // EVENTO RELECIONADO À SELEÇÃO DO HERÓI NA LISTBOX
        private void lstEscolhaSeuPersonagem_SelectedIndexChanged(object sender, EventArgs e)
        {
            NomeHeroi = Convert.ToString(lstEscolhaSeuPersonagem.Text);
        }
    }
}
