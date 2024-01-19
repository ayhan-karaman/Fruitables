using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MvcUIApp.Infrastructure.UploadHelpers
{
    public static class FileHelper
    {
        public static async Task<string> Upload(IFormFile file, string folderName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", folderName);
            if (file.Length > 0)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string pathResult = ChangeFile(path, file.FileName);
                string fullPath = Path.Combine(path, pathResult);
                using (FileStream stream = File.Create(fullPath))
                {
                    await file.CopyToAsync(stream);
                    await stream.FlushAsync();
                    return $"img/{folderName}/{pathResult}";
                }
            }
            else
            {
                return $"img/default.png";
            }
        }
        public static async Task<string> UpdateFile(IFormFile file, string folderName, string replacePath)
        {
             var defaultImageReplace = replacePath.Replace(folderName + "/", "");
             string defaultImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", defaultImageReplace);
             string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", replacePath);
             if (file.Length > 0 && File.Exists(defaultImage))
             {
                return await Upload(file, folderName);
             }
             else if(file.Length > 0 && File.Exists(path))
             {
                 DeleteFile(path);
                 return await Upload(file, folderName);
             }
             else
                return $"img/default.png";
        }
        public static void DeleteFile(string url)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", url);
            if(File.Exists(path))
            {
                 File.Delete(path);
            }
        }
       
        public static string ChangeFile(string folderName, string fileName)
        {
            string extension = Path.GetExtension(fileName);
            string oldName = Path.GetFileNameWithoutExtension(fileName);
            string s = oldName.Substring(oldName.Length -1);
            oldName = char.IsDigit(char.Parse(s)) ? oldName.Substring(0, oldName.Length -1) : oldName;
            string requlatedFileName = CharacterRegulatory(oldName);

            var files = Directory.GetFiles(folderName, requlatedFileName + "*");
            if(files.Length <= 0)
                return requlatedFileName + "-1" + extension;
            else if(files.Length == 1)
                return requlatedFileName + "-2" + extension;
            else
            {
                var searchingFile = $"{folderName}/{requlatedFileName+extension}";
                int firstFileNameIndex = Array.IndexOf(files, searchingFile);
                files = files.Where((val, index) => index != firstFileNameIndex).ToArray();
                int[] fileNumbers = new int[files.Length];
                int lastHypenIndex;
                for (int i = 0; i < files.Length; i++)
                {
                    lastHypenIndex = files[i].LastIndexOf("-");
                    int substrNumber = int.Parse(files[i].Substring(lastHypenIndex +1, files[i].Length - extension.Length - lastHypenIndex -1));
                    fileNumbers[i] = substrNumber;
                }
                int bigNumber = fileNumbers.Max();
                bigNumber++;
                return requlatedFileName + "-" +bigNumber+extension;
            }
        }

        private static string CharacterRegulatory(string name)
        {
            name = name.ToLower();
            // özel karakterlere boşluk bırakır ve türkçe karakterleri dönüştürür
            name = Regex.Replace(name, @"[^0-9A-Za-z ,]", ""); ;

            // birden fazla boşlukları tire tek bir tire işaretine dönüştürür  
            name = Regex.Replace(name, @"\s+", "-");

            // son karakter tire ise onu siler yoksa olduğu gibi geri döndürür
            name = name[name.Length - 1].ToString() == "-"
            ? name.Substring(0, name.Length - 1) : name;

            return name;
        }
    }
}