﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Icosoft.Class
{
    public class FileHelper
    {
        public static string uploadphoto(HttpPostedFileBase file, string folder)
        {
            var path = string.Empty;
            var pic = string.Empty;

            if (file != null)
            {
                pic = Path.GetFileName(file.FileName);
                path = Path.Combine(HttpContext.Current.Server.MapPath(folder), pic);
                file.SaveAs(path);
                using (MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                }
            }

            return pic;
        }
    }
}