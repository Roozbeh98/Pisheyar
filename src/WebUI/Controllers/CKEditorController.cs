using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CKEditorController : ControllerBase
    {
        private readonly IWebHostEnvironment hostingEnvironment;

        public CKEditorController(IWebHostEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        [HttpPost("[action]")]
        public IActionResult UploadImage(IFormFile upload)
        {
            var filename = DateTime.Now.ToString("yyyyMMddHHmmss") + upload.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(),
                hostingEnvironment.WebRootPath, "uploads", filename);
            var stream = new FileStream(path, FileMode.Create);
            upload.CopyToAsync(stream);
            return new JsonResult(new { url = "http://185.94.97.164/uploads/" + filename });
        }
    }
}