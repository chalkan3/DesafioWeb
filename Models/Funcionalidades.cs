using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1dsadasd.Utils;

namespace WebApplication1dsadasd.Models
{
    public class Funcionalidades
    {
        public int Tempo { get; set; }
        public int Potencia { get; set; }
        public string Instrucoes { get; set; }
        public string Nome { get;  set; }
        public string CozimentoString { get; set; }

        public Funcionalidades(int Tempo, int Potencia, string Instrucoes, string Nome, string CozimentoString)
        {

            if (Tempo > 120 || Tempo < 1)
            {
                throw new MicrondasException("Tempo Não valido. O tempo deve ser menor ou igual a 2 minutos ou maior que 1 segundo");
            }
            else
            {
                this.Tempo = Tempo;
            }
            if (Potencia > 10 || Potencia < 1)
            {
                this.Potencia = 1;
                throw new MicrondasException("Potencia não está dentro dos padrões definido. a potencia vai de 1 a 10");


            }
            else
            {
                this.Potencia = Potencia;

            }

            if (Instrucoes == "")
            {
                throw new MicrondasException("Instruções não podem ser vazias.");

            }
            else
            {
                this.Instrucoes = Instrucoes;

            }


            if (Nome == "")
            {
                throw new MicrondasException("Nome Não pode estar em branco.");

            }
            else
            {
                this.Nome = Nome;

            }

            if (CozimentoString == "")
            {
                throw new MicrondasException("String de cozimento nao pode ficar vazia");

            }
            else
            {
                this.CozimentoString = CozimentoString;

            }

            


        }

        public List<Funcionalidades> CalcularPotencia(int Potencia, List<Funcionalidades> DataSet)
        {
            if (Potencia > 10 || Potencia < 1)
            {
                this.Potencia = 1;
                throw new MicrondasException("Potencia não está dentro dos padrões definido. a potencia vai de 1 a 10");
            }
            else
            {
                 DataSet.Where(w => w.Nome == "Padrao").ToList().ForEach(s => s.Potencia = Potencia);
            }

            return DataSet;

        }
        public static Funcionalidades EscolherPrograma(string programa, List<Funcionalidades> DataSet)
        {
            Funcionalidades Program = DataSet.Find(x => x.Nome.ToLower() == programa.ToLower());

            return Program;
        }


        public static Funcionalidades Padrao(List<Funcionalidades> DataSet )
        {
            List<Funcionalidades> bd = DataSet;

            Funcionalidades Padrao = bd.Find(x => x.Nome == "Padrao");

            return Padrao;

        } 

        public List<Funcionalidades> CalcularTempo(int Tempo, List<Funcionalidades> DataSet)
        {
            if (Tempo > 120 || Tempo < 1)
            {
                throw new MicrondasException("Tempo Não valido. O tempo deve ser menor ou igual a 2 minutos ou maior que 1 segundo");
            }
            else
            {
                DataSet.Where(w => w.Nome == "Padrao").ToList().ForEach(s => s.Tempo = Tempo);
            }


            return DataSet;


        }

        public static List<Funcionalidades> BancoDeDados()
        {
            var functionalidades = new List<Funcionalidades>
            {
               new Funcionalidades(30, 10, "Padrao", "Padrao","."),
               new Funcionalidades(2,  2 ,"Frango", "Isso é um frango", "F"),
               new Funcionalidades(3,  3, "Pipica","Isso é uma pipica","P"),
               new Funcionalidades(4,  4,"Ovo", "Isso é um ovo","O"),
               new Funcionalidades(5,  5,"marmelada","Isso é marmelada","M")
            };

            return functionalidades;
        }

        public static List<Funcionalidades> NovoItem(List<Funcionalidades> DataSet, Funcionalidades Funcionalidades)
        {
            DataSet.Add(Funcionalidades);

            return DataSet; 
        }

        public void InicioRapido(int Potencia, int Tempo)
        {
            if (Potencia != 8)
            {
                this.Potencia = Potencia;
            }
            else
            {
                this.Potencia = 8;
            }


            if (Tempo != 3)
            {
                this.Tempo = Tempo;
            }
            else
            {
                this.Tempo = 3;

            }
        }



    }
}