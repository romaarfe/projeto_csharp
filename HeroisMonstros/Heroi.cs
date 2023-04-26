using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroisMonstros
{
    public class Heroi
    {
        public Heroi() { }
        public Heroi(int id, string nome, int pontosDeVida, int nivel, string arma, string armadura, string magiaOfensiva, string magiaDefensiva, bool rip) 
        {
            Id= id;
            Nome= nome;
            PontosDeVidaMaximo= pontosDeVida;
            Nivel= nivel;
            Arma= arma;
            Armadura= armadura;
            MagiaOfensiva= magiaOfensiva;
            MagiaDefensiva= magiaDefensiva;
            Rip= rip;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int PontosDeVidaMaximo { get; set; }
        public int Nivel { get; set; }
        public string Arma { get; set; }
        public string Armadura { get; set; }
        public string MagiaOfensiva { get; set; }
        public string MagiaDefensiva { get; set; }
        public bool Rip { get; set; }
    }
}
