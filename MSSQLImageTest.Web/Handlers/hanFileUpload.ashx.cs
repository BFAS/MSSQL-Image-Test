using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using Newtonsoft.Json;

namespace MSSQLImageTest.Web.Handlers
{
    /// <summary>
    /// Summary description for hanFileUpload
    /// </summary>
    public class hanFileUpload : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            if (HttpContext.Current.Request.Files.AllKeys.Any())
            {
                // Get the uploaded image from the Files collection
                var httpPostedFile = HttpContext.Current.Request.Files["UploadedImage"];

                if (httpPostedFile != null)
                {
                    string extention = Path.GetExtension(httpPostedFile.FileName);

                    int intContentLength = httpPostedFile.ContentLength;
                    Byte[] bytImage = new byte[intContentLength];
                    httpPostedFile.InputStream.Read(bytImage, 0, httpPostedFile.ContentLength);

                    DataFile.InsertDataFile(bytImage, httpPostedFile.ContentType, intContentLength,
                                            httpPostedFile.FileName,
                                            extention);
                }
            }

            var json = JsonConvert.SerializeObject("test");

            context.Response.ContentType = "application/json";
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.Write(json);
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}