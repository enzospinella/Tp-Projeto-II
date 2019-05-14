using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AA_TP_Projeto_II___Forca
{
    class Palavra
    {
        const int inicioPalavra = 0;
        const int inicioDica = inicioPalavra + tamanhoPalavra;

        const int tamanhoPalavra = 15;
        const int tamanhoDica = 100;

        string palavraEscolhida;
        string dica;
        public Palavra(string linha)
        {
            palavraEscolhida = linha.Substring(inicioPalavra, tamanhoPalavra);
            dica = linha.Substring(inicioDica, tamanhoDica);
        }

        public string PalavraEscolhida { get => palavraEscolhida; set => palavraEscolhida = value; }
        public string Dica { get => dica; set => dica = value; }
    }
}
