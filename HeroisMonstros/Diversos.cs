// PROJETO DE PROGRAMAÇÃO - 25 HORAS
// FORMADOR: PAULO JORGE

// TEMA: HERÓIS VS MONSTROS
// FORMANDO: RODRIGO FERNANDES - Nº 13

// ÁREA DOS IMPORTS
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// NAMESPACE SECUNDÁRIO
namespace Diversos
{
    // CLASSE PRINCIPAL
    public class Conecta
    {
        // VARIÁVEIS DA CLASSE CONECTA, COM A STRING CONNECTION
        public static string StrConn = "Data Source = 62.28.39.135,62444; Initial Catalog = zRodrigoProjeto25;" +
                                       "User Id = EFARodrigo; Password = 123.Abc;";
        public string StrSQL;

        // MÉTODO DE ACESSO À BASE DE DADOS
        public DataTable BuscarDados()
        {
            // CRIA UMA CONEXÃO
            SqlConnection C = new SqlConnection(StrConn);
            C.Open();

            // PARA CRIAR COMANDO SQL E EXTRAIR OS DADOS PRETENDIDOS
            SqlCommand command = C.CreateCommand();
            command.CommandText = StrSQL;

            // PARA TRAZER OS DADOS DA TABELA ESPECIFICADA E DEIXAR EM MEMÓRIA
            SqlDataAdapter da = new SqlDataAdapter(command);
            var dt = new DataTable();
            da.Fill(dt);

            // PARA DESLIGAR A CONEXÃO
            C.Close();
            return dt;
        }
    }

    // CLASSE PARA CONFIGURAÇÕES (ESCALÁVEL)
    public class Configuracoes
    {
        // EVENTO PARA EMULAR A "PINTURA" DOS BOTÕES EM 3D
        public void pintar_Botoes3D(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, (sender as System.Windows.Forms.Button).ClientRectangle,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset,
            SystemColors.ControlLightLight, 5, ButtonBorderStyle.Outset);
        }
    }
}
