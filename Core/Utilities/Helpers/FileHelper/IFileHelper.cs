using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelper
{
    public interface IFileHelper
    {
        string  Add(IFormFile files, string root);
        void Delete(string filePath);
        string Update(IFormFile file,string filePath , string root);
    }
}
