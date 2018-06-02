using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1dsadasd.Models;

namespace WebApplication1dsadasd.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult FileUpload(HttpPostedFileBase arquivo)
        {

            if(arquivo != null && arquivo.ContentLength > 0)
            {
                var uploadPath = Server.MapPath("~/Content/Upload");
                string caminhoArquivo = Path.Combine(@uploadPath, Path.GetFileName(arquivo.FileName));
                string ext = Path.GetExtension(caminhoArquivo);

                if (ext != ".txt")
                {
                    return Json(new { ok = false, aviso = "Arquivo não permitido" });
                }

                arquivo.SaveAs(caminhoArquivo);

                Arquivo ArquivoClass = new Arquivo();
                string[] data = ArquivoClass.LerArquivo(caminhoArquivo);

                return Json(new { ok = true, stringLida = data[0] ,caminho = caminhoArquivo});

            }

            return Json(new { ok = false , aviso = "arquivo não encontrado"});
            
        }
    }
}