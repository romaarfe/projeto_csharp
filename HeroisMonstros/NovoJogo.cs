// PROJETO DE PROGRAMAÇÃO - 25 HORAS
// FORMADOR: PAULO JORGE

// TEMA: HERÓIS VS MONSTROS
// FORMANDO: RODRIGO FERNANDES - Nº 13

// ÁREA DOS IMPORTS
using Diversos;
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

// NAMESPACE PRINCIPAL
namespace HeroisMonstros
{
    // CLASSE PRINCIPAL E SUA HERANÇA
    public partial class NovoJogo : Form
    {
        // CONSTRUTOR PRINCIPAL
        public NovoJogo()
        {
            InitializeComponent();
            ConfigurarBotoes();
        }

        // VARIÁVEIS DA CLASSE
        public string NomeHeroi;
        private bool btnRandomFoiClicado = false;


        // MÉTODO PARA CONFIGURAR OS BOTÕES EMULANDO EFEITO 3D
        private void ConfigurarBotoes()
        {
            Configuracoes configuracoes = new Configuracoes();
            this.btnRandom.Paint += new PaintEventHandler(configuracoes.pintar_Botoes3D);
            this.btnIniciarJogo.Paint += new PaintEventHandler(configuracoes.pintar_Botoes3D);
            this.btnVoltar.Paint += new PaintEventHandler(configuracoes.pintar_Botoes3D);
        }

        // EVENTO PRINCIPAL PARA ATIVAR MÉTODOS COM GERAÇÕES DE VALORES "RANDÔMICOS"
        private void btnRandom_Click(object sender, EventArgs e)
        {
            btnRandomFoiClicado = true;

            RolarPontosDeVida();
            RolarArma();
            RolarArmadura();
            RolarMagiaOfensiva();
            RolarMagiaDefensiva();
        }

        // MÉTODO PARA GERAR UM VALOR "RANDÔMICO" E APRESENTAR COMO FUTURO VALOR DOS PONTOS DE VIDA DO HERÓI
        private void RolarPontosDeVida()
        {
            Random pontosDeVida = new Random();
            lblResultadoPontosDeVida.Text = Convert.ToString(10 + pontosDeVida.Next(2, 13));
        }

        // MÉTODO PARA GERAR UM VALOR "RANDÔMICO", ATRIBUIR UMA ARMA ESPECÍFICA E APRESENTAR COMO FUTURA ARMA DO HERÓI
        private void RolarArma()
        {
            Random arma = new Random();
            int resultadoArma = arma.Next(1, 7);
            if (resultadoArma == 1 || resultadoArma == 2)
            {
                lblResultadoArma.Text = "Pequena";
            }
            else if (resultadoArma == 3 || resultadoArma == 4 || resultadoArma == 5)
            {
                lblResultadoArma.Text = "Normal";
            }
            else
            {
                lblResultadoArma.Text = "Grande";
            }
        }

        // MÉTODO PARA GERAR UM VALOR "RANDÔMICO", ATRIBUIR UMA ARMADURA ESPECÍFICA E APRESENTAR COMO FUTURA ARMADURA DO HERÓI
        private void RolarArmadura()
        {
            Random armadura = new Random();
            int resultadoArmadura = armadura.Next(1, 7);
            if (resultadoArmadura == 6 || resultadoArmadura == 5)
            {
                lblResultadoArmadura.Text = "Leve";
            }
            else if (resultadoArmadura == 2 || resultadoArmadura == 3 || resultadoArmadura == 4)
            {
                lblResultadoArmadura.Text = "Média";
            }
            else
            {
                lblResultadoArmadura.Text = "Pesada";
            }
        }

        // MÉTODO PARA GERAR UM VALOR "RANDÔMICO", BUSCAR NA BASE DE DADOS (TABELA MAGIA) E APRESENTAR COMO FUTURA MAGIA OFENSIVA DO HERÓI
        private void RolarMagiaOfensiva()
        {
            Random magiaOfensiva = new Random();
            int resultadoMagiaOfensiva = magiaOfensiva.Next(1, 6);

            Conecta conecta= new Conecta();
            conecta.StrSQL = $"SELECT Nome FROM Magia WHERE Id = {resultadoMagiaOfensiva};";

            lblResultadoMagiaOfensiva.Text = Convert.ToString(conecta.BuscarDados().Rows[0][0]);
        }

        // MÉTODO PARA GERAR UM VALOR "RANDÔMICO", BUSCAR NA BASE DE DADOS (TABELA MAGIA) E APRESENTAR COMO FUTURA MAGIA DEFENSIVA DO HERÓI
        private void RolarMagiaDefensiva()
        {
            Random magiaDefensiva = new Random();
            int resultadoMagiaDefensiva = magiaDefensiva.Next(6, 9);

            Conecta conecta = new Conecta();
            conecta.StrSQL = $"SELECT Nome FROM Magia WHERE Id = {resultadoMagiaDefensiva};";

            lblResultadoMagiaDefensiva.Text = Convert.ToString(conecta.BuscarDados().Rows[0][0]);
        }

        // EVENTO RELACIONADO AO BOTÃO QUE PERMITE RETORNAR AO FORM ANTERIOR (TELAINICIAL)
        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            TelaInicial telaInicial = new TelaInicial();
            telaInicial.Closed += (s, args) => this.Close();
            telaInicial.Show();
        }

        // EVENTO RELACIONADO AO BOTÃO QUE INICIALMENTE TESTA SE A TEXTBOX DO NOME FOI PREENCHIDA
        // ESTE EVENTO TAMBÉM VERIFICA SE O BOTÃO QUE ATIVA OS MÉTODOS DE GERADORES "RANDÔMICOS" FOI DE FATO CLICADO
        // TAMBÉM É O RESPONSÁVEL POR ATIVAR OUTROS DOIS MÉTODOS
        private void btnIniciarJogo_Click(object sender, EventArgs e)
        {
            if (txtNomeDoPersonagem.Text == "")
            {
                MessageBox.Show(caption:"AVISO!", text:"POR FAVOR, ESCOLHA UM NOME PARA O SEU HERÓI!", buttons:MessageBoxButtons.OK);
            }
            else if (btnRandomFoiClicado == false)
            {
                MessageBox.Show(caption:"AVISO!", text:"POR FAVOR, CLIQUE NO DADO E ROLE AS CARACTERÍSTICAS DO HERÓI.", buttons:MessageBoxButtons.OK);
            }
            else
            {
                try
                {
                    PesquisarNaBaseDeDados();
                }
                catch (Exception)
                {
                    RegistrarNaBaseDeDados();
                }
            }
        }

        // MÉTODO QUE PESQUISA NA BASE DE DADOS A EXISTÊNCIA DO NOME ESCOLHIDO/DIGITADO NA TEXTBOX
        private void PesquisarNaBaseDeDados()
        {
            Conecta conecta = new Conecta();
            conecta.StrSQL = $"SELECT Nome FROM Heroi WHERE Nome = '{txtNomeDoPersonagem.Text}';";
            NomeHeroi = Convert.ToString(conecta.BuscarDados().Rows[0][0]);
            MessageBox.Show(caption:"ERRO!", text:"NOME DUPLICADO, POR FAVOR ESCOLHA OUTRO NOME PARA O SEU HERÓI.", buttons:MessageBoxButtons.OK);
        }

        // MÉTODO RESPONSÁVEL POR REGISTRAR NA BASE DE DADOS (TABELA HERÓI) UM NOVO HERÓI
        private void RegistrarNaBaseDeDados()
        {
            Conecta conecta = new Conecta();
            conecta.StrSQL = $"INSERT INTO Heroi VALUES ('{txtNomeDoPersonagem.Text}', 1, {lblResultadoPontosDeVida.Text}, '{lblResultadoArma.Text}', '{lblResultadoArmadura.Text}', '{lblResultadoMagiaOfensiva.Text}', '{lblResultadoMagiaDefensiva.Text}', 0);";
            conecta.BuscarDados();

            NomeHeroi = txtNomeDoPersonagem.Text;
            
            MessageBox.Show(caption:"SUCESSO",text:"HERÓI CRIADO COM SUCESSO!", buttons:MessageBoxButtons.OK);

            // FECHA O FORM ATUAL, INSTANCIA O NOVO FORM, PARA INÍCIO DE FATO DO JOGO
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
    }
}
