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
        // GET: Upload não é o meio mais seguro passando o path do servidor porem usei deste jeito nesse exercicio.
        public ActionResult ActionFileUpload(HttpPostedFileBase arquivo)
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

        [HttpPost]
        public ActionResult ActionAtualizarArquivo(FormCollection formulario)
        {
            Arquivo arquivo = new Arquivo();
            StreamWriter escritor = arquivo.EscreverArquivo(formulario["path"]);

            if(escritor == null)
            {
                return Json(new { ok = false, aviso = "Arquivo não encontrado" });
            }
            escritor.WriteLine(formulario["conteudo"]);
            escritor.Close();
            return Json(new { ok = true });
        }
        [HttpGet]
        public ActionResult ActionFileDownload(string filePath, string mode)
        {
            if (!System.IO.File.Exists(filePath))
            {
                return HttpNotFound();
            }
            if (mode == "action")
                return Json(new { fileName = filePath }, JsonRequestBehavior.AllowGet);

            return File(filePath, System.Net.Mime.MediaTypeNames.Application.Octet, "arquivoAquecido.txt");

        }

       
    }
}