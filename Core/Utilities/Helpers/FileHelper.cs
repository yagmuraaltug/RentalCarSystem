using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile formFile)
        {
            var sourcepath = Path.GetTempFileName(); //Gecici dosya adi alindi.
            if(formFile.Length > 0)
            {
                using (var uploading = new FileStream(sourcepath, FileMode.Create))
                //Filestream yeni bir dosya olusturulmak icin kullanidi. 
                //FileMode dosya acilis sekillerini belirtir. Create ile yeni bir dosya olusturulup
                //formFile a upload edildi.
                {
                    formFile.CopyTo(uploading);
                }

            }
            var result = newPath(formFile);
            File.Move(sourcepath, result); // Belirtilen bir kaynaktan hedef olan newPath a tasindi.
            return result;


        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception) //istisnai durum bulundugunda
            {
                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }

        public static string Update(string sourcePath, IFormFile formFile)
        {
            var result = newPath(formFile).ToString();
            if(sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    formFile.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;
        }

        public static string newPath(IFormFile formFile)
        {
            FileInfo fileInfo = new FileInfo(formFile.FileName);
            string fileExtension = fileInfo.Extension; //dosya uzantisi

            string path = Environment.CurrentDirectory + @"\Models\CarImages"; //aktif klasorun yolu
            var newPath = Guid.NewGuid().ToString() + fileExtension;

            string result = $@"{path}\{newPath}";
            return result;
        }
    }
}
