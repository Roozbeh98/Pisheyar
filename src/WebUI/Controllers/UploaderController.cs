using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pisheyar.Application.Common.UploadHelper.CKEditor;
using Pisheyar.Application.Common.UploadHelper.Filepond;

namespace WebUI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UploaderController : ApiController
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UploaderController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        /// <summary>
        /// بارگذاری سند - FilepondRevert
        /// </summary>
        /// <param name="filepond">اطلاعات سند</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<Guid?>> FilepondProcess(IFormFile filepond)
        {
            return await Mediator.Send(new FilepondProcess { Filepond = filepond, WebRootPath = _hostingEnvironment.WebRootPath });
        }

        /// <summary>
        /// بارگذاری سند - FilepondProcess
        /// </summary>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<bool>> FilepondRevert()
        {
            return await Mediator.Send(new FilepondRevert { Body = Request.Body, WebRootPath = _hostingEnvironment.WebRootPath });
        }

        /// <summary>
        /// بارگذاری سند - CKEditor
        /// </summary>
        /// <param name="file">اطلاعات سند</param>
        /// <returns></returns>
        [HttpPost("[action]")]
        public async Task<ActionResult<bool>> CKEditor(IFormFile file)
        {
            return await Mediator.Send(new CKEditorUploader { File = file, WebRootPath = _hostingEnvironment.WebRootPath });
        }







        //[HttpPost("[action]")]
        //public IActionResult UploadImage(IFormFile upload)
        //{
        //    var filename = DateTime.Now.ToString("yyyyMMddHHmmss") + upload.FileName;
        //    var path = Path.Combine(Directory.GetCurrentDirectory(),
        //        _hostingEnvironment.WebRootPath, "uploads", filename);
        //    var stream = new FileStream(path, FileMode.Create);
        //    upload.CopyToAsync(stream);
        //    return new JsonResult(true);
        //}

        //[HttpPost("[action]")]
        //public JsonResult UploadImageTest(IFormFile filepond)
        //{
        //    var filename = DateTime.Now.ToString("yyyyMMddHHmmss") + filepond.FileName;
        //    var path = Path.Combine(Directory.GetCurrentDirectory(),
        //        _hostingEnvironment.WebRootPath, "uploads", filename);
        //    var stream = new FileStream(path, FileMode.Create);
        //    filepond.CopyToAsync(stream);

        //    return new JsonResult(filename);
        //}

        //[HttpPost("[action]")]
        //public JsonResult RevertImage()
        //{
        //    string res;

        //    MemoryStream memstream = new MemoryStream();
        //    Request.Body.CopyToAsync(memstream);
        //    memstream.Position = 0;
        //    using (StreamReader reader = new StreamReader(memstream))
        //    {
        //        res = reader.ReadToEnd();
        //    }

        //    res = res.Remove(res.Length - 1);
        //    string filename = res.Substring(1);

        //    var source = Path.Combine(Directory.GetCurrentDirectory(),
        //        _hostingEnvironment.WebRootPath, "uploads", filename);

        //    if (System.IO.File.Exists(source))
        //    {
        //        //System.IO.File.Delete(source);
        //        return new JsonResult(true);
        //    }

        //    return new JsonResult(false);
        //}
    }
}