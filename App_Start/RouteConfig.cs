using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1dsadasd
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "UploadArquivo",
                "Microndas/Upload",
                new { Controller = "Upload", Action= "FileUpload" }
                );
            routes.MapRoute(
                "PegarPrograma",
                "Microndas/Programa",
                new {Controller="Home", Action= "ActionIniciarAquecimento" }
                );
            routes.MapRoute(
                "AlterarString",
                "Microndas/StringCozida",
                new { Controller = "Home", Action = "ActionInputStringCozimento" }
                );
            routes.MapRoute(
                 "AlterarTempo",
                 "Microndas/Tempo",
                  new { Controller = "Home", Action = "ActionAlterarTempo" }

                );
            routes.MapRoute(
                "InicioRapido",
                "Microndas/InicioRapido",
                new { Controller = "Home" , Action = "ActionInicioRapdio" }
                );

            routes.MapRoute(
                    "NovoItem",
                    "Microndas/Novo",
                    new { Controller= "Home", Action = "ActionIncluirNovo" }
                );

            routes.MapRoute(
                "AlterarPotencia",
                "Microndas/Potencia",
                new { Controller = "Home" , Action = "ActionAlterarPotencia" }
                );

            routes.MapRoute(
                "MostrarDetalhe",
                "Microndas/Detalhe",
                new { Controller = "Home", Action = "ActionMostrarDetalhes" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
