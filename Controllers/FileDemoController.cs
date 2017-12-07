using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DotNetNote.Controllers
{
    public class FileDemoController : Controller
    {
        private IHostingEnvironment _environment;

        public FileDemoController(IHostingEnvironment environment)
        {
            // 웹 프로젝트의 wwwroot 폴더에 대한 물리적인 경로를 받기 위함
            _environment = environment;
        }

        [HttpGet]
        public IActionResult FileUploadDemo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FileUploadDemo(ICollection<IFormFile> files)
        {
            var uploadFolder = Path.Combine(_environment.WebRootPath, "files");

            foreach(var file in files)
            {
                if(file.Length > 0)
                {
                    var fileName = Path.GetFileName(
                        ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Value.Trim('"')
                    );

                    using(var fileStream = new FileStream(Path.Combine(uploadFolder, fileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                }
            }

            return View();
        }

        public FileResult FileDownloadDemo(string fileName = "Test.txt")
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(
                Path.Combine(_environment.WebRootPath, "files") + "//" + fileName);

            return File(fileBytes, "application/octet-stream");
        }
    }
}