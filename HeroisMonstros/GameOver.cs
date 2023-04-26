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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// NAMESPACE PRINCIPAL
namespace HeroisMonstros
{
    // CLASSE PRINCIPAL E SUA HERANÇA
    public partial class GameOver : Form
    {
        // CONSTRUTOR PRINCIPAL QUE RECEBE INFORMAÇÕES DO FORM ANTERIOR POR ARGUMENTOS
        public GameOver(bool ripHeroi, bool fimDaAventura, int idHeroi, int nivelHeroi)
        {
            InitializeComponent();

            RipHeroi = ripHeroi;
            FimDaAventura = fimDaAventura;
            IdHeroi = idHeroi;
            NivelHeroi = nivelHeroi;
            pbxRIP.Visible = false;
            dgvFinal.Visible = false;

            FinalDoJogo();
        }

        // VARIÁVEIS DA CLASSE
        private int NivelHeroi;
        private int IdHeroi;
        private bool RipHeroi;
        private bool FimDaAventura;

        // MÉTODO PARA FINALIZAR O JOGO
        private void FinalDoJogo()
        {
            if (RipHeroi == true)
            {
                RegistrarDerrota();
            }

            else if (FimDaAventura == true)
            {
                RegistrarVitoria();
            }
        }

        // COM FINAL DO JOGO, ESTE MÉTODO REGISTRA A VITÓRIA, FAZENDO UPDATE NO HERÓI NA BASE DE DADOS
        // TAMBÉM BUSCA PARA UMA DATAGRIDVIEW AS INFORMAÇÕES REGISTRADAS NO ENCONTRO E APRESENTA APENAS AS 4 ÚLTIMAS
        private void RegistrarVitoria()
        {
            lblResultadoFinal.Text = "VOCÊ VENCEU!!!";

            Conecta conecta = new Conecta();
            conecta.StrSQL = $"UPDATE Heroi SET Nivel = '{NivelHeroi + 1}' WHERE Id = '{IdHeroi}';";
            conecta.BuscarDados();

            dgvFinal.Visible = true;
            dgvFinal.AllowUserToAddRows = false;
            dgvFinal.ColumnHeadersVisible = true;
            dgvFinal.RowHeadersVisible = false;

            Conecta conecta2 = new Conecta();
            conecta2.StrSQL = $"SELECT TOP 4 E.Descritivo AS ENCONTRO, H.Nome AS HEROI, M.Nome AS MONSTRO FROM Encontro E " +
                $"INNER JOIN Heroi H ON E.IdHeroi = H.Id INNER JOIN Monstro M ON E.IdMonstro = M.Id WHERE IdHeroi = {IdHeroi} " +
                $"ORDER BY E.Id DESC;";
            dgvFinal.DataSource = conecta2.BuscarDados();
        }

        // COM FINAL DO JOGO, ESTE MÉTODO REGISTRA A DERROTA, DELETANDO DA BASE DE DADOS AS INFORMAÇÕES DO ENCONTRO E DO HERÓI
        private void RegistrarDerrota()
        {
            lblResultadoFinal.Text = "VOCÊ PERDEU!!!";
            pbxRIP.Visible = true;

            Conecta conecta = new Conecta();
            conecta.StrSQL = $"DELETE FROM Encontro WHERE IdHeroi = '{IdHeroi}'; DELETE FROM Heroi WHERE Id = '{IdHeroi}';";
            conecta.BuscarDados();
        }

    }
}
