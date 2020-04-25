using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using dsd.Models;
using System.IO;

namespace dsd.Controllers
{
    public class FileController : Controller
    {
        // GET: File
        public ActionResult Index()
        {
            return View();
        }
        //public ActionResult fileupload()
        //{
        //    return View();
        //}
        [HttpPost]
        public ActionResult fileupload()
        {
            if (Request.Files.Count > 0)
            {

                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fname;

                        // Checking for Internet Explorer  
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }

                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("~/FileUpload/"), fname);
                        file.SaveAs(fname);
                    }
                    // Returns message that successfully uploaded  
                    return Json("File Uploaded Successfully!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }  
    else  
    {
                return Json("No files selected.");
            }

            //  if (Request.Files.Count > 0)
            //  {
            //      //try
            //      //{
            //          //  Get all files from Request object  
            //          HttpFileCollectionBase files = Request.Files;
            //          // for (int i = 0; i < files.Count; i++)
            //          //FileUpload1 fs = new FileUpload1();
            //          //fs.filesize = 2000;
            //          //string us = fs.UploadUserFile(file);
            //          //if (us != null)
            //          //{

            //          //    ViewBag.ResultErrorMessage = fs.ErrorMessage;
            //          //}
            //          //if (file.ContentLength > 0)
            //          //{
            //          //    string filename = Path.GetFileName(file.FileName);
            //          //    string folderPath = Path.Combine(Server.MapPath("~/FileUpload"), filename);
            //          //    file.SaveAs(folderPath);
            //          //}
            //          // }
            //      //}
            //}
           // return View();
        }
    }
    
}