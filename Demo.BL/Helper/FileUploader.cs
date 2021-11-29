using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Demo.BL.Helper
{
    public static class FileUploader
    {
        public static string UploadFile(string Folder , IFormFile File)
        {
            try
            {

                // Get Folder Path
                var FilePath = Directory.GetCurrentDirectory() + "/wwwroot/" + Folder;

                // Get File Name
                var FileName = Guid.NewGuid() + Path.GetFileName(File.FileName);

                // Merge Folder Path With PhotoName
                var FinalPath = Path.Combine(FilePath, FileName);

                // Save File

                // Stream ===> Data Over Time

                using (var stream = new FileStream(FinalPath, FileMode.Create))
                {
                    File.CopyTo(stream);
                }

                return FileName;

            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }


        public static string RemoveFile(string Folder, string FileName)
        {
            try
            {

                if (System.IO.File.Exists(Directory.GetCurrentDirectory() + "/wwwroot/"+ Folder + FileName))
                {
                    System.IO.File.Delete(Directory.GetCurrentDirectory() + "/wwwroot/" + Folder + FileName);
                }

                return "File Deleted";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
