using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace AA_TP_Projeto_II___Forca
{
    public partial class Form1 : Form
    {
        VetorPalavra vetorPalavra = new VetorPalavra(1000);
        public Form1()
        {
            InitializeComponent();

            if(dlgAbrirArquivo.ShowDialog() == DialogResult.OK)
            {
                int i = 0;
                var arquivo = new StreamReader(dlgAbrirArquivo.FileName);
                while (arquivo.EndOfStream)
                {
                    string linhaLida = arquivo.ReadLine();
                    var pessoa = new Palavra(linhaLida);
                    vetorPalavra.InserirAposFim
                }
            }
        }
    }
}
