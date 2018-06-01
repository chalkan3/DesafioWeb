
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
            List<Funcionalidades>  functionalidades;
            if (Session["bancoDeDados"] == null)
            {
                functionalidades = Funcionalidades.BancoDeDados();
            }
            else
            {
                functionalidades = (List<Funcionalidades>)Session["bancoDeDados"];
            }
                 

            var funcionalidadesDropDown = functionalidades.AsEnumerable();

            var FuncionalidadeView = new FuncionalidadeViewModel
            {
                FuncionalidadesDropDown = funcionalidadesDropDown
            };

            Session["bancoDeDados"] = functionalidades;

            return View(FuncionalidadeView);
        }

        [HttpPost]
        public ActionResult ActionInputStringCozimento(FormCollection formulario)
        {
            return Json(new { produto = formulario["Produto"] });
            
        }

        [HttpPost]
        public ActionResult ActionAlterarTempo(FormCollection formulario)
        {
            int tempo = 0;
            var bancoDeDados = (List<Funcionalidades>)Session["bancoDeDados"];

            if (int.TryParse(formulario["Tempo"], out tempo))
            {
                Funcionalidades Padrao = Funcionalidades.Padrao(bancoDeDados);
                bancoDeDados = Padrao.CalcularTempo(tempo, bancoDeDados);


                Session["bancoDeDados"] = bancoDeDados;
            }
            else
            {
                return Json(new { ok = false });

            }

            return Json(new { ok = true });
        }

        [HttpPost]
        public ActionResult ActionAlterarPotencia(FormCollection formulario)
        {
            int potencia = 0;
            var bancoDeDados = (List<Funcionalidades>)Session["bancoDeDados"];
            if (int.TryParse(formulario["Potencia"], out potencia))
            {
                Funcionalidades Padrao = Funcionalidades.Padrao(bancoDeDados);
                bancoDeDados = Padrao.CalcularPotencia(potencia,bancoDeDados);
                Session["bancoDeDados"] = bancoDeDados;

            }
            else
            {
                return Json(new { ok = false });

            }

            return Json(new { ok = true });
        }

        [HttpPost]
        public ActionResult ActionIncluirNovo(FormCollection forumulario)
        {
            int Tempo = 0;
            int Potencia = 0;
            bool GravarOK = true;
            if(!int.TryParse(forumulario["NovoTempo"], out Tempo))
            {
                GravarOK = false;

            }
           
            if(!int.TryParse(forumulario["NovoPotencia"], out Potencia))
            {
                GravarOK = false;

            }


            if (GravarOK == true)
            {
                Funcionalidades novaFuncionalidade = new Funcionalidades(Tempo, Potencia, forumulario["Instrucoes"], forumulario["Nome"], forumulario["cozimentoString"]);
                var bancoDeDados = (List<Funcionalidades>)Session["bancoDeDados"];

                bancoDeDados = Funcionalidades.NovoItem(bancoDeDados, novaFuncionalidade);
                Session["bancoDeDados"] = bancoDeDados;

                return Json(new { ok = true });
            }
            else
            {
                return Json(new { ok = false });
            }

        }

        [HttpPost]
        public ActionResult ActionInicioRapdio(FormCollection formulario)
        {
            var bancoDeDados = (List<Funcionalidades>)Session["bancoDeDados"];

            if (formulario["iniciar"] == "ok")
            {

                Funcionalidades Padrao = Funcionalidades.Padrao(bancoDeDados);
                return Json(new { Objeto = Padrao, ok = true });

            }
            else
            {
                return Json(new { Objeto = "", ok = false });

            }


        }

        [HttpPost]
        public ActionResult ActionIniciarAquecimento(FormCollection formulario)
        {
            var bancoDeDados = (List<Funcionalidades>)Session["bancoDeDados"];
            Funcionalidades Programa = Funcionalidades.EscolherPrograma(formulario["Programa"], bancoDeDados);

            return Json(new { ObjPrograma = Programa });
        }




    }
}