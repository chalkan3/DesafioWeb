using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication1dsadasd.Models
{
    public class Arquivo
    {
        public string Nome { get; set; }
        public int Tamanho { get; set; }
        public string Tipo { get; set; }
        public string Caminho { get; set; }
        private bool existeArquivo { get; set; }




        public Arquivo()
        {
            existeArquivo = false;
        }


        private Stream AbrirArquivo(string caminho)
        {
            Stream arquivo = null;
            try
            {
                arquivo = File.Open(caminho, FileMode.Open, FileAccess.ReadWrite);

            }
            catch (IOException)
            {
                return arquivo;
            }



            return arquivo;


        }

        public string[] LerArquivo(string caminho)
        {

            Stream arquivo = AbrirArquivo(caminho);
            List<string> listaInput = new List<string>();
            if (arquivo != null)

            {
                StreamReader leitor = new StreamReader(arquivo);
                string linha = leitor.ReadLine();
                while (linha != null)
                {
                    listaInput.Add(linha);
                    linha = leitor.ReadLine();
                }

                arquivo.Close();
                leitor.Close();

            }
            else
            {
                Console.WriteLine("Arquivo já está aberto.");
            }

            return listaInput.ToArray();
        }


        public bool ArquivoExiste(string caminho)
        {
            return File.Exists(caminho);
        }

    }
}