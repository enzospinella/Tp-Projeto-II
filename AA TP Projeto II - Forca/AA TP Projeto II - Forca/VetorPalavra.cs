using System;
using static System.Console;
using System.IO;
using System.Windows.Forms;
using System.Threading.Tasks;


class VetorPalavra
{
    int tamanhoMaximo;
    int qtosDados;
    int[] dados;

    public int QtosDados { get => qtosDados; set => qtosDados = value; }
    public int[] Dados { get => dados; set => dados = value; }

    public VetorPalavra(int tamanhoDesejado)
    {
      dados = new int[tamanhoDesejado];
      qtosDados = 0;
      tamanhoMaximo = tamanhoDesejado;
    }
    public void LerDados(string nomeArq)   // ler de um arquivo texto
    { 
      var arq = new StreamReader(nomeArq);
      qtosDados = 0;  // esvaziamos o vetor
      while (!arq.EndOfStream && qtosDados <= tamanhoMaximo )
      {
        int dadoLido = int.Parse(arq.ReadLine());
        InserirAposFim(dadoLido);
      }
      arq.Close();
    }
    public void LerDados()   // ler do teclado, segunda assinatura --> sobrecarga
    {
      Write("Quantos valores serão digitados?");
      qtosDados = int.Parse(ReadLine()); // informa quantos elementos lidos
      dados = new int[qtosDados]; // instancia com tamanho correto
      for (int indice = 0; indice < qtosDados; indice++)
      {
        Write($"Digite o {indice + 1}º valor:");
        dados[indice] = int.Parse(ReadLine());
      }
    }

    public void Listar()
    {
      for (int indice = 0; indice < qtosDados; indice++)
          Write($"{dados[indice],5} ");
    }
    public void Listar(ListBox lista)
    {
      lista.Items.Clear();
      for (int indice = 0; indice < qtosDados; indice++)
          lista.Items.Add(dados[indice]);
    }
    public void Listar(ComboBox lista)
    {
      lista.Items.Clear();
      for (int indice = 0; indice < qtosDados; indice++)
        lista.Items.Add(dados[indice]);
    }
    public void Listar(TextBox lista)
    {
      lista.Multiline = true;
      lista.ScrollBars = ScrollBars.Both;
      lista.Clear();
      for (int indice = 0; indice < qtosDados; indice++)
        lista.AppendText(dados[indice]+Environment.NewLine);
    }

    public void GravarDados(string nomeArquivo)
    {
       var arquivo = new StreamWriter(nomeArquivo);
       for (int i = 0; i < qtosDados; i++)
                arquivo.WriteLine(dados[i]);
       arquivo.Close();
    }
    public void InserirAposFim(int valorAInserir)
    {
        if (qtosDados >= tamanhoMaximo)
            ExpandirVetor();

       dados[qtosDados++] = valorAInserir;
    }

    // Projeto II

    public void InserirAposFim(string palavra, string dica)
    {
        if (qtosDados >= tamanhoMaximo)
            ExpandirVetor();

        dados[qtosDados++] = 
    }

        private  void Excluir(int posicaoAExcluir)
        {
            qtosDados--;
            for (int indice = posicaoAExcluir; indice < qtosDados; indice++)
                dados[indice] = dados[indice + 1];

            // pensar em como diminuir o tamanho fisico do vetor, para economizar
        }
        public void ExpandirVetor()
        {
            tamanhoMaximo += 10;
            int[] vetorMaior = new int[tamanhoMaximo];
            for (int indice = 0; indice < qtosDados; indice++)
                vetorMaior[indice] = dados[indice];

            dados = vetorMaior; // O vetor antigo recebe o novo vetor, este com mais espaço (construído com o tamanhoMaximo)
        }

        public void CompactarVetor()
        {
            tamanhoMaximo -= 10;
            int[] vetorMinimo = new int[tamanhoMaximo];
            for (int i = 0; i < qtosDados; i++)
                vetorMinimo[i] = dados[i];

            dados = vetorMinimo;
        }
        public void Ordenar(ref int[] vetor)
        {
            for (int lento = 0; lento < qtosDados; lento++)
            {
                for (int rapido = lento + 1; rapido < qtosDados; rapido++)
                {
                    if (vetor[lento] > vetor[rapido])
                    {
                        int aux = dados[lento];
                        vetor[lento] = vetor[rapido];
                        vetor[rapido] = aux;
                    }
                }
            }
        }

        public void TrocarPrimeirosPorUltimos()
        {
            int primeiros = 0;
            int ultimos = qtosDados - 1;

            while (primeiros < ultimos)
            {
                int aux = dados[primeiros];
                dados[primeiros] = dados[ultimos];
                dados[ultimos] = aux;

                primeiros++;
                ultimos--;
            }

        }

        public void Trocar()
        {
            int indice = 0;

            while (indice < qtosDados)
            {
                int aux = dados[indice];
                dados[indice] = dados[indice + 1];
                dados[indice + 1] = aux;

                indice += 2;
            }
        }

        public string ConverterBase(int val, int aBase)
        {
            string valor = "";
            int i = 0;

            do
            {
                int quociente = val / aBase;
                int resto = val % aBase;

                val = quociente;
                dados[i] = resto;

                i++;
            }
            while (val > 0);

            for (int indice = i - 1; indice >= 0; indice--)
                valor += dados[indice] + "";
            return valor;
        }

        public int AcharProdutoPeloCodigo(int produtoAProcurar)
        {
            int indice = 0;
            while (indice < qtosDados)
            {
                int codProduto = dados[indice];
                if (produtoAProcurar == codProduto)
                {
                    int qtdeProduto = dados[indice + 1];
                    return qtdeProduto;
                }
                indice += 2;
            }
            return -1;
        }

        public void ExcluirImpares()
        {
            int onde = 0;
            while (onde < qtosDados)
            {
                if (dados[onde] % 2 != 0)
                    Excluir(onde);
                else
                    onde++;
            }
        }

        public VetorPalavra CasarCom(VetorPalavra outroVetor)
        {
            var C = new VetorPalavra(qtosDados);
            int indA = 0, indB = 0;
            while (indA < qtosDados && indB < outroVetor.qtosDados)
            {
                if (dados[indA] < outroVetor.dados[indB])
                    C.InserirAposFim(dados[indA++]);
                else
                    if (outroVetor.dados[indB] < dados[indA])
                    C.InserirAposFim(outroVetor.dados[indB++]); 
                else
                {
                    C.InserirAposFim(dados[indA++]);
                    indB++;
                }
            }
            return C;
        }

        public override string ToString()
        {
            return ToString(" ");
        }

        public string ToString(string separador)
        {
            string resultado = "";
            for (int i = 0; i < qtosDados; i++)
                resultado += dados[i] + separador;
            return resultado;

        }
}

