using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHeplerManager : IFileHelper
    {
        public string Add(IFormFile file, string root)
        {
            long size = file.Length;
            if (size > 0)
            { 
              return CreateFile(file, root);
            }
            return null;
        }

        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
                Delete(filePath);
            return CreateFile(file, root); 
        }
        private string CreateFile(IFormFile file ,string root)
        {
            string guid = Guid.NewGuid().ToString();
            string fileType = Path.GetExtension(file.Name);
            var filePath = guid + fileType;
            using (FileStream stream = File.Create(root+filePath))
            {
                stream.CopyTo(stream);
            }
            return filePath;
        }
    }
}