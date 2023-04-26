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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// NAMESPACE PRINCIPAL
namespace HeroisMonstros
{
    // CLASSE PRINCIPAL E SUA HERANÇA
    public partial class Encontro : Form
    {
        // CONSTRUTOR PRINCIPAL QUE RECEBE INFORMAÇÕES DOS FORMS ANTERIORES POR ARGUMENTO
        public Encontro(string nome)
        {
            InitializeComponent();
            //TocarMusicaTema();

            NomeHeroi = nome;
            dgvPersonagem.Visible = false;

            ConfigurarBotoes();
            BuscarHeroi();
            ConfigurarHeroi();
            IniciarEncontros();
            BloquearBotoesDeAcao();
            BloquearSetasDeNavegacao();
        }

        // MÉTODO PARA CONFIGURAR OS BOTÕES EMULANDO EFEITO 3D
        private void ConfigurarBotoes()
        {
            Configuracoes configuracoes = new Configuracoes();
            this.btnFloresta.Paint += new PaintEventHandler(configuracoes.pintar_Botoes3D);
            this.btnMontanha.Paint += new PaintEventHandler(configuracoes.pintar_Botoes3D);
            this.btnDeserto.Paint += new PaintEventHandler(configuracoes.pintar_Botoes3D);
            this.btnTundra.Paint += new PaintEventHandler(configuracoes.pintar_Botoes3D);
            this.btnAtaque.Paint += new PaintEventHandler(configuracoes.pintar_Botoes3D);
            this.btnMagiaOfensiva.Paint += new PaintEventHandler(configuracoes.pintar_Botoes3D);
            this.btnMagiaDefensiva.Paint += new PaintEventHandler(configuracoes.pintar_Botoes3D);
        }

        // MÉTODO PARA BLOQUEAR OS BOTÕES DE AÇÃO
        private void BloquearBotoesDeAcao()
        {
            btnAtaque.Enabled = false;
            btnMagiaOfensiva.Enabled = false;
            btnMagiaDefensiva.Enabled = false;
        }

        // MÉTODO PARA ATIVAR OS BOTÕES DE AÇÃO
        private void AtivarBotoesDeAcao()
        {
            btnAtaque.Enabled = true;
            btnMagiaOfensiva.Enabled = true;
            btnMagiaDefensiva.Enabled = true;
        }

        // MÉTODO PARA BLOQUEAR OS BOTÕES DE NAVEGAÇÃO
        private void BloquearSetasDeNavegacao()
        {
            btnFloresta.Enabled = false;
            btnMontanha.Enabled = false;
            btnDeserto.Enabled = false;
            btnTundra.Enabled = false;
        }

        // MÉTODO PARA ATIVAR OS BOTÕES DE NAVEGAÇÃO
        private void AtivarSetasDeNavegacao()
        {
            btnFloresta.Enabled = true;
            btnMontanha.Enabled = true;
            btnDeserto.Enabled = true;
            btnTundra.Enabled = true;
        }

        // MÉTODO PARA "TREMER A TELA", SE APROVEITANDO DAS THREADS E SLEEP
        private void TremerTela() 
        {
            for (int i = 0; i < 5; i++)
            {
                this.Left += 10;
                System.Threading.Thread.Sleep(75);
                this.Left -= 10;
                System.Threading.Thread.Sleep(75);
            }
        }

        // MÉTODO PARA BUSCAR NA BASE DE DADOS AS INFORMAÇÕES DO HERÓI
        private void BuscarHeroi()
        {
            Conecta conecta = new Conecta();
            conecta.StrSQL = $"SELECT * FROM Heroi WHERE Nome = '{NomeHeroi}';";
            dgvPersonagem.DataSource = conecta.BuscarDados();

            IdHeroi = Convert.ToInt16(dgvPersonagem.Rows[0].Cells[0].Value);
            NivelHeroi = Convert.ToInt16(dgvPersonagem.Rows[0].Cells[2].Value);
            PontosDeVidaMaximoHeroi = Convert.ToInt16(dgvPersonagem.Rows[0].Cells[3].Value);
            ArmaHeroi = Convert.ToString(dgvPersonagem.Rows[0].Cells[4].Value);
            ArmaduraHeroi = Convert.ToString(dgvPersonagem.Rows[0].Cells[5].Value);
            MagiaOfensivaHeroi = Convert.ToString(dgvPersonagem.Rows[0].Cells[6].Value);
            MagiaDefensivaHeroi = Convert.ToString(dgvPersonagem.Rows[0].Cells[7].Value);
            RipHeroi = Convert.ToBoolean(dgvPersonagem.Rows[0].Cells[8].Value);
        }

        // VARIÁVEIS DA CLASSE

        // VARIÁVEIS DO HERÓI -- ATRIBUTOS
        private int AtaqueHeroi;
        private int DefesaHeroi;
        private int PontosDeVidaAtuaisHeroi;

        // VARIÁVEIS DO HERÓI -- PRINCIPAIS
        public int IdHeroi;
        private string NomeHeroi;
        private int PontosDeVidaMaximoHeroi;
        public int NivelHeroi;
        private string ArmaHeroi;
        private string ArmaduraHeroi;
        private string MagiaOfensivaHeroi;
        private string MagiaDefensivaHeroi;
        public bool RipHeroi;

        // VARIÁVEIS DO MONSTRO -- ATRIBUTOS
        private int PontosDeVidaAtuaisMonstro;

        // VARIÁVEIS DO MONSTRO -- PRINCIPAIS
        private int IdMonstro;
        private string NomeMonstro;
        private int DificuldadeMonstro;
        private string AtaqueNormalMonstro;
        private string AtaquePoderosoMonstro;
        private string AtaqueEspecialMonstro;

        // VARIÁVEL USADA COMO CONTADOR DE AVENTURAS PARA DAR FIM AO MESMO CASO 4 LOCAIS SEJAM VISITADOS (E MONSTROS DERROTADOS)
        private int ContadorDeAventuras = 0;

        // VARIÁVEL PARA REGISTRAR O FIM DO ENCONTRO/AVENTURA (RELACIONADA COM A VARIÁVEL ACIMA)
        public bool FimDaAventura = false;

        // MÉTODO PARA ATRIBUIR/CONFIGURAR AS INFORMAÇÕES DO HERÓI
        private void ConfigurarHeroi()
        {
            // CONDIÇÃO PARA DEFINIÇÃO DO VALOR DE ATAQUE MEDIANTE O TIPO DE ARMA
            if (ArmaHeroi == "Pequena") { AtaqueHeroi = 2; }
            else if (ArmaHeroi == "Normal") { AtaqueHeroi = 3; }
            else if (ArmaHeroi == "Grande") { AtaqueHeroi = 5; }

            if (ArmaduraHeroi == "Leve") { DefesaHeroi = 1; }
            else if (ArmaduraHeroi == "Média") { DefesaHeroi = 2; }
            else if (ArmaduraHeroi == "Pesada") { DefesaHeroi = 3; }

            // ATRIBUIÇÕES DE CONFIGURAÇÃO PRINCIPAL
            AtaqueHeroi += NivelHeroi;
            DefesaHeroi += NivelHeroi;
            PontosDeVidaMaximoHeroi += NivelHeroi;
            PontosDeVidaAtuaisHeroi = PontosDeVidaMaximoHeroi;

            // APRESENTAR OS VALORES NAS LABELS CORRESPONDENTES
            lblNomePersonagem.Text = $"NOME: {NomeHeroi}";
            lblValorAtq.Text = Convert.ToString(AtaqueHeroi);
            lblValorDef.Text = Convert.ToString(DefesaHeroi);
            lblPvAtual.Text = Convert.ToString(PontosDeVidaAtuaisHeroi);
            lblPvMaximo.Text = Convert.ToString(PontosDeVidaMaximoHeroi);
        }

        // MÉTODO ASSÍNCRONO PARA DE FATO INICIAR OS ENCONTROS COM USO DE TASK.DELAY
        private async void IniciarEncontros()
        {
            pbxLocais.Load("http://cdn.vgws.com/psalgo/images/ps_gall/ps1/twnchr.gif");

            lstEventos.Items.Add("Você começa na encantadora Cidade dos Sacro-Montes...");
            await Task.Delay(1000);
            lstEventos.Items.Add("Ao Norte é onde fica a Floresta...");
            await Task.Delay(1000);
            lstEventos.Items.Add("Para o Leste é onde fica o Deserto...");
            await Task.Delay(1000);
            lstEventos.Items.Add("Para o Oeste é onde fica a Montanha...");
            await Task.Delay(1000);
            lstEventos.Items.Add("Ao Sul é onde fica a Tundra...");
            await Task.Delay(1000);
            lstEventos.Items.Add("Por qual caminho você vai seguir?");
            await Task.Delay(1000);
            AtivarSetasDeNavegacao();
        }

        // EVENTO ASSÍNCRONO PARA INICIAR A MATEMÁTICA DO ATAQUE DO HERÓI CONTRA O MONSTRO
        private async void btnAtaque_Click(object sender, EventArgs e)
        {
            BloquearBotoesDeAcao();
            TremerTela();
            lstEventos.Items.Add($"Você ataca com sua arma {ArmaHeroi}...");
            await Task.Delay(1000);
            lstEventos.Items.Add($"... e causa {AtaqueHeroi} de dano.");
            PontosDeVidaAtuaisMonstro -= AtaqueHeroi;

            // CONDIÇÃO DE VERIFICAÇÃO PARA DEFINIR SE O MONSTRO FOI DERROTADO
            if (PontosDeVidaAtuaisMonstro <= 0)
            {
                BloquearBotoesDeAcao();
                await Task.Delay(1000);
                lstEventos.Items.Add($"VOCÊ DERROTOU O MONSTRO!");
                await Task.Delay(1000);
                FinalizarAventuras();
                lstEventos.Items.Add("Qual será seu próximo destino?");
            }
            else
            {
                await Task.Delay(1000);
                MonstroAtacar();
            }  
        }

        // EVENTO ASSÍNCRONO PARA INICIAR A MATEMÁTICA DO USO DA MAGIA OFENSIVA CONTRA O MONSTRO
        private async void btnMagiaOfensiva_Click(object sender, EventArgs e)
        {
            BloquearBotoesDeAcao();
            // O DESCRITIVO DA MAGIA OFENSIVA É BUSCADO NA BASE DE DADOS E APRESENTADO DURANTE ATIVAÇÃO DO EVENTO
            Conecta conecta = new Conecta();
            conecta.StrSQL = $"SELECT Descritivo FROM Magia WHERE Nome = '{MagiaOfensivaHeroi}';";
            dgvPersonagem.DataSource = conecta.BuscarDados();
            string descritivoMagiaOfensiva = Convert.ToString(dgvPersonagem.Rows[0].Cells[0].Value);

            TremerTela();
            lstEventos.Items.Add($"Você ataca com sua magia {MagiaOfensivaHeroi}...");
            await Task.Delay(1000);
            lstEventos.Items.Add($"{descritivoMagiaOfensiva}...");
            await Task.Delay(1000);
            lstEventos.Items.Add($"... e causa {5 + NivelHeroi} de dano.");
            PontosDeVidaAtuaisMonstro -= 5 + NivelHeroi;

            // CONDIÇÃO DE VERIFICAÇÃO PARA DEFINIR SE O MONSTRO FOI DERROTADO
            if (PontosDeVidaAtuaisMonstro <= 0)
            {
                BloquearBotoesDeAcao();
                await Task.Delay(1000);
                lstEventos.Items.Add($"VOCÊ DERROTOU O MONSTRO!");
                await Task.Delay(1000);
                FinalizarAventuras();
                lstEventos.Items.Add("Qual será seu próximo destino?");
            }
            else
            {
                await Task.Delay(1000);
                MonstroAtacar();
            }
        }

        // EVENTO ASSÍNCRONO PARA INICIAR A MATEMÁTICA DO USO DA MAGIA DEFENSIVA CONTRA O MONSTRO
        private async void btnMagiaDefensiva_Click(object sender, EventArgs e)
        {
            BloquearBotoesDeAcao();
            // O DESCRITIVO DA MAGIA DEFENSIVA É BUSCADO NA BASE DE DADOS E APRESENTADO DURANTE ATIVAÇÃO DO EVENTO
            Conecta conecta = new Conecta();
            conecta.StrSQL = $"SELECT Descritivo FROM Magia WHERE Nome = '{MagiaDefensivaHeroi}';";
            dgvPersonagem.DataSource = conecta.BuscarDados();
            string descritivoMagiaDefensiva = Convert.ToString(dgvPersonagem.Rows[0].Cells[0].Value);

            TremerTela();
            lstEventos.Items.Add($"Você utiliza sua magia {MagiaDefensivaHeroi}...");
            await Task.Delay(1000);
            lstEventos.Items.Add($"{descritivoMagiaDefensiva}...");
            await Task.Delay(1000);

            // CONDIÇÕES DE VALIDAÇÃO DA MAGIA E SUA ATIVAÇÃO NA MATEMÁTICA DO HERÓI
            if (MagiaDefensivaHeroi == "Curar Ferimentos")
            {
                lstEventos.Items.Add($"... e cura {5 + NivelHeroi} Pontos de Vida.");
                PontosDeVidaAtuaisHeroi += 5 + NivelHeroi;

                if (PontosDeVidaAtuaisHeroi >= PontosDeVidaMaximoHeroi)
                {
                    PontosDeVidaAtuaisHeroi = PontosDeVidaMaximoHeroi;
                }
                lblPvAtual.Text = Convert.ToString(PontosDeVidaAtuaisHeroi);
            }
            if (MagiaDefensivaHeroi == "Bênção da Guerra")
            {
                lstEventos.Items.Add($"... e você ganha +{NivelHeroi} no Ataque.");
                AtaqueHeroi += NivelHeroi;
                lblValorAtq.Text = Convert.ToString(AtaqueHeroi);
                
            }
            if (MagiaDefensivaHeroi == "Proteção Divina")
            {
                lstEventos.Items.Add($"... e você ganha +{NivelHeroi} na Defesa.");
                DefesaHeroi += NivelHeroi;
                lblValorDef.Text = Convert.ToString(DefesaHeroi);
            }
            await Task.Delay(1000);
            MonstroAtacar();
        }

        // MÉTODO PARA BUSCAR NA BASE DE DADOS AS INFORMAÇÕES DO MONSTRO
        private async void BuscarMonstro()
        {
            Random monstro = new Random();
            IdMonstro = monstro.Next(1, 21);

            Conecta conecta = new Conecta();
            conecta.StrSQL = $"SELECT * FROM Monstro WHERE Id = {IdMonstro};";

            dgvPersonagem.DataSource = conecta.BuscarDados();

            // SERVE PARA ATRIBUIR/CONFIGURAR AS INFORMAÇÕES DO MONSTRO
            NomeMonstro = Convert.ToString(dgvPersonagem.Rows[0].Cells[1].Value);
            DificuldadeMonstro = Convert.ToInt16(dgvPersonagem.Rows[0].Cells[2].Value);
            AtaqueNormalMonstro = Convert.ToString(dgvPersonagem.Rows[0].Cells[3].Value);
            AtaquePoderosoMonstro = Convert.ToString(dgvPersonagem.Rows[0].Cells[4].Value);
            AtaqueEspecialMonstro = Convert.ToString(dgvPersonagem.Rows[0].Cells[5].Value);

            PontosDeVidaAtuaisMonstro = 5 * DificuldadeMonstro;

            lstEventos.Items.Add($"{NomeMonstro} aparece e fica em posição de combate!");
            await Task.Delay(1000);
            lstEventos.Items.Add("O que você faz?");
            await Task.Delay(1000);
            AtivarBotoesDeAcao();
        }

        // MÉTODO ASSÍNCRONO QUE GERA VALOR "RANDÔMICO" PARA SORTEAR QUAL TIPO DE ATAQUE O MONSTRO UTILIZARÁ
        private async void MonstroAtacar()
        {
            Random ataqueMonstro = new Random();
            int decidirAtaque = ataqueMonstro.Next(1, 4);

            // TESTE DE CONDIÇÕES RELEVANTES POIS EXISTEM VARIAÇÕES DE DIFICULDADE E ATAQUES ENTRE OS MONSTROS
            // ALÉM DE GERAR A MATEMÁTICA DO COMBATE E REGISTRAR TUDO NAS LABELS RELEVANTES
            if (decidirAtaque == 1)
            {
                lstEventos.Items.Add($"{NomeMonstro} ataca com {AtaqueNormalMonstro}...");
                await Task.Delay(1000);
                lstEventos.Items.Add($"... e causa {3 * DificuldadeMonstro} de dano.");
                await Task.Delay(1000);
                lstEventos.Items.Add("O que você faz?");
                PontosDeVidaAtuaisHeroi -= (3 * DificuldadeMonstro - DefesaHeroi);
                if (PontosDeVidaAtuaisHeroi >= PontosDeVidaMaximoHeroi)
                {
                    PontosDeVidaAtuaisHeroi = PontosDeVidaMaximoHeroi;
                }
                lblPvAtual.Text = Convert.ToString(PontosDeVidaAtuaisHeroi);
            }

            else if (decidirAtaque == 2 && AtaquePoderosoMonstro != "")
            {
                lstEventos.Items.Add($"{NomeMonstro} ataca com {AtaquePoderosoMonstro}...");
                await Task.Delay(1000);
                lstEventos.Items.Add($"... e causa {4 * DificuldadeMonstro} de dano.");
                await Task.Delay(1000);
                lstEventos.Items.Add("O que você faz?");
                PontosDeVidaAtuaisHeroi -= (4 * DificuldadeMonstro - DefesaHeroi);
                if (PontosDeVidaAtuaisHeroi >= PontosDeVidaMaximoHeroi)
                {
                    PontosDeVidaAtuaisHeroi = PontosDeVidaMaximoHeroi;
                }
                lblPvAtual.Text = Convert.ToString(PontosDeVidaAtuaisHeroi);
            }

            else if (decidirAtaque == 3 && AtaqueEspecialMonstro != "")
            {
                lstEventos.Items.Add($"{NomeMonstro} ataca com {AtaqueEspecialMonstro}...");
                await Task.Delay(1000);
                lstEventos.Items.Add($"... e causa {5 * DificuldadeMonstro} de dano.");
                await Task.Delay(1000);
                lstEventos.Items.Add("O que você faz?");
                PontosDeVidaAtuaisHeroi -= (5 * DificuldadeMonstro - DefesaHeroi);
                if (PontosDeVidaAtuaisHeroi >= PontosDeVidaMaximoHeroi)
                {
                    PontosDeVidaAtuaisHeroi = PontosDeVidaMaximoHeroi;
                }
                lblPvAtual.Text = Convert.ToString(PontosDeVidaAtuaisHeroi);
            }

            else 
            {
                lstEventos.Items.Add($"{NomeMonstro} ataca com {AtaqueNormalMonstro}...");
                await Task.Delay(1000);
                lstEventos.Items.Add($"... e causa {3 * DificuldadeMonstro} de dano.");
                await Task.Delay(1000);
                lstEventos.Items.Add("O que você faz?");
                PontosDeVidaAtuaisHeroi -= (3 * DificuldadeMonstro - DefesaHeroi);
                if (PontosDeVidaAtuaisHeroi >= PontosDeVidaMaximoHeroi)
                {
                    PontosDeVidaAtuaisHeroi = PontosDeVidaMaximoHeroi;
                }
                lblPvAtual.Text = Convert.ToString(PontosDeVidaAtuaisHeroi);
            }

            // VERIFICAÇÃO DOS PONTOS DE VIDA DO HERÓI PARA CASO O ATAQUE DO MONSTRO CAUSE UMA DERROTA
            // CASO ISSO ACONTEÇA, FECHA O FORM ATUAL E INSTANCIA O PRÓXIMO (GAMEOVER)
            if (PontosDeVidaAtuaisHeroi <= 0)
            {
                await Task.Delay(1000);
                RipHeroi = true;
                this.Hide();

                GameOver gameOver = new GameOver(RipHeroi, FimDaAventura, IdHeroi, NivelHeroi);
                gameOver.Closed += (s, args) => this.Close();

                // PARA INSTANCIAR, BUSCAR E TOCAR A MÚSICA TEMA NO PRÓXIMO FORM
                SoundPlayer tocador = new SoundPlayer();
                tocador.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\ps4landmaster1.wav";
                tocador.PlayLooping();

                // ABRE NOVO FORM (GAMEOVER)
                gameOver.Show();
            }

            else
            {
                await Task.Delay(1000);
                AtivarBotoesDeAcao();
            }
        }
        
        // EVENTO ASSÍNCRONO RELACIONADO À SETA DE NAVEGAÇÃO DA MONTANHA
        // GERA INFORMAÇÕES NA LISTBOX, HABILITA BOTÕES DE AÇÃO E AINDA FAZEM A CONTAGEM DE AVENTURAS
        private async void btnMontanha_Click(object sender, EventArgs e)
        {
            BloquearSetasDeNavegacao();
            pbxLocais.Load("http://cdn.vgws.com/psalgo/images/ps_gall/ps1/plains.gif");
            lstEventos.Items.Clear();
            lstEventos.Items.Add("Você seguiu para o Oeste onde fica a Montanha Austera...");
            await Task.Delay(1000);
            lstEventos.Items.Add("... e nela encontrou um terrível monstro...");
            await Task.Delay(1000);

            BuscarMonstro();
            ContadorDeAventuras += 1;

            // POR FIM REGISTRA NA BASE DE DADOS, AS LINHAS DE ENCONTRO
            Conecta conecta = new Conecta();
            conecta.StrSQL = $"INSERT INTO Encontro VALUES ('Montanha', '{IdHeroi}', '{IdMonstro}');";
            conecta.BuscarDados();
        }

        // EVENTO ASSÍNCRONO RELACIONADO À SETA DE NAVEGAÇÃO DA FLORESTA
        // GERA INFORMAÇÕES NA LISTBOX, HABILITA BOTÕES DE AÇÃO E AINDA FAZEM A CONTAGEM DE AVENTURAS
        private async void btnFloresta_Click(object sender, EventArgs e)
        {
            BloquearSetasDeNavegacao();
            pbxLocais.Load("http://cdn.vgws.com/psalgo/images/ps_gall/ps1/forest.gif");
            lstEventos.Items.Clear();
            lstEventos.Items.Add("Você seguiu para o Norte onde fica a Floresta Lutuosa...");
            await Task.Delay(1000);
            lstEventos.Items.Add("... e nela encontrou um terrível monstro...");
            await Task.Delay(1000);

            BuscarMonstro();
            ContadorDeAventuras += 1;

            // POR FIM REGISTRA NA BASE DE DADOS, AS LINHAS DE ENCONTRO
            Conecta conecta = new Conecta();
            conecta.StrSQL = $"INSERT INTO Encontro VALUES ('Floresta', '{IdHeroi}', '{IdMonstro}');";
            conecta.BuscarDados();
        }

        // EVENTO ASSÍNCRONO RELACIONADO À SETA DE NAVEGAÇÃO DA TUNDRA
        // GERA INFORMAÇÕES NA LISTBOX, HABILITA BOTÕES DE AÇÃO E AINDA FAZEM A CONTAGEM DE AVENTURAS
        private async void btnTundra_Click(object sender, EventArgs e)
        {
            BloquearSetasDeNavegacao();
            pbxLocais.Load("http://cdn.vgws.com/psalgo/images/ps_gall/ps1/snow.gif");
            lstEventos.Items.Clear();
            lstEventos.Items.Add("Você seguiu para o Sul onde fica a Tundra Inclemente...");
            await Task.Delay(1000);
            lstEventos.Items.Add("... e nela encontrou um terrível monstro...");
            await Task.Delay(1000);
            
            BuscarMonstro();
            ContadorDeAventuras += 1;

            // POR FIM REGISTRA NA BASE DE DADOS, AS LINHAS DE ENCONTRO
            Conecta conecta = new Conecta();
            conecta.StrSQL = $"INSERT INTO Encontro VALUES ('Tundra', '{IdHeroi}', '{IdMonstro}');";
            conecta.BuscarDados();
        }

        // EVENTO ASSÍNCRONO RELACIONADO À SETA DE NAVEGAÇÃO DA DESERTO
        // GERA INFORMAÇÕES NA LISTBOX, HABILITA BOTÕES DE AÇÃO E AINDA FAZEM A CONTAGEM DE AVENTURAS
        private async void btnDeserto_Click(object sender, EventArgs e)
        {
            BloquearSetasDeNavegacao();
            pbxLocais.Load("http://cdn.vgws.com/psalgo/images/ps_gall/ps1/desert.gif");
            lstEventos.Items.Clear();
            lstEventos.Items.Add("Você seguiu para o Leste onde fica o Deserto Mordaz...");
            await Task.Delay(1000);
            lstEventos.Items.Add("... e nela encontrou um terrível monstro...");
            await Task.Delay(1000);

            BuscarMonstro();
            ContadorDeAventuras += 1;

            // POR FIM REGISTRA NA BASE DE DADOS, AS LINHAS DE ENCONTRO
            Conecta conecta = new Conecta();
            conecta.StrSQL = $"INSERT INTO Encontro VALUES ('Deserto', '{IdHeroi}', '{IdMonstro}');";
            conecta.BuscarDados();
        }

        // MÉTODO PARA FINALIZAR O ENCONTRO ATUAL
        private void FinalizarAventuras()
        {
            AtivarSetasDeNavegacao();

            // VERIFICAR SE JÁ FORAM LOCAIS VISITADOS E MONSTROS DERROTADOS
            if (ContadorDeAventuras == 4)
            {
                // VALIDA O FIM DO ENCONTRO, FECHA O FORM ATUAL E INSTANCIA O PRÓXIMO (GAMEOVER)
                FimDaAventura = true;
                this.Hide();
                GameOver gameOver = new GameOver(RipHeroi, FimDaAventura, IdHeroi, NivelHeroi);
                gameOver.Closed += (s, args) => this.Close();

                // PARA INSTANCIAR, BUSCAR E TOCAR A MÚSICA TEMA NO PRÓXIMO FORM
                SoundPlayer tocador = new SoundPlayer();
                tocador.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\Resources\\ps4landmaster1.wav";
                tocador.PlayLooping();

                // ABRE NOVO FORM (GAMEOVER)
                gameOver.Show();
            }
        }
    }
}
