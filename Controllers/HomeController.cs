
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1dsadasd.Models;
using WebApplication1dsadasd.ViewModels;

namespace WebApplication1dsadasd.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var functionalidades = new List<Funcionalidades>
            {
               new Funcionalidades{Tempo = 30, Potencia = 10, Nome = "Padrao", Instrucoes = "Padrao", CozimentoString = "."},
               new Funcionalidades{Tempo = 2, Potencia = 2 ,Nome = "Frango", Instrucoes = "Isso é um frango",  CozimentoString = "F"},
               new Funcionalidades{Tempo = 3, Potencia = 3, Nome = "Pipica", Instrucoes = "Isso é uma pipica", CozimentoString = "P"},
               new Funcionalidades{Tempo = 4, Potencia = 4, Nome = "Ovo", Instrucoes = "Isso é um ovo",  CozimentoString = "O"},
               new Funcionalidades {Tempo = 5, Potencia =  5, Nome = "marmelada",  Instrucoes = "Isso é marmelada", CozimentoString = "M" }
            };

            var funcionalidadesDropDown = functionalidades.AsEnumerable();

            var FuncionalidadeView = new FuncionalidadeViewModel
            {
                FuncionalidadesDropDown = funcionalidadesDropDown
            };

            return View(FuncionalidadeView);
        }


    }
}