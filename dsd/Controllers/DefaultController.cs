using dsd.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace dsd.Controllers
{
    public class DefaultController : ApiController
    {
        EmployeeDetailsContext entities = new EmployeeDetailsContext();
        [HttpPost]
        [Route("api/Default/SaveFile")]
        public HttpResponseMessage SaveFile()
        {
            //Create HTTP Response.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            //Check if Request contains File.
            if (HttpContext.Current.Request.Files.Count == 0)
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            //Read the File data from Request.Form collection.
            HttpPostedFile postedFile = HttpContext.Current.Request.Files[0];

            //Convert the File data to Byte Array.
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }

            //Insert the File to Database Table.
            //  FilesEntities entities = new FilesEntities();
           
            FileModal file = new FileModal
            {
                FileName = Path.GetFileName(postedFile.FileName),
                ContentType = postedFile.ContentType,
                Data = bytes
            };
            entities.FileModal.Add(file);
            entities.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, new { id = file.Id, Name = file.FileName });
        }

        [HttpPost]
        [Route("api/Default/GetFiles")]
        public HttpResponseMessage GetFiles()
        {
            EmployeeDetailsContext entities = new EmployeeDetailsContext();
            var files = from file in entities.FileModal
                        select new { id = file.Id, Name = file.FileName };
            return Request.CreateResponse(HttpStatusCode.OK, files);
        }
        [HttpGet]
       [Route("api/Default/GetFile")]
        public HttpResponseMessage GetFiles(int fileId)
        {
            //Create HTTP Response.
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);

            //Fetch the File data from Database.
          //FilesEntities entities = new FilesEntities();
            FileModal file = entities.FileModal.ToList().Find(p => p.Id == fileId);

            //Set the Response Content.
            response.Content = new ByteArrayContent(file.Data);

            //Set the Response Content Length.
            response.Content.Headers.ContentLength = file.Data.LongLength;

            //Set the Content Disposition Header Value and FileName.
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = file.FileName;

            //Set the File Content Type.
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            return response;
        }

    }
}
