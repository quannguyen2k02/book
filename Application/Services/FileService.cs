using Application.IService;
using Microsoft.AspNetCore.Http;

namespace Application.Services;

public class FileService : IFileService
{
    public async Task<string> UploadFileAsync(IFormFile file, string uploadPath)
    {
        if (file == null || file.Length == 0)
            return "empty.jpg";

        var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(uploadPath, fileName);

        if (!Directory.Exists(uploadPath))
            Directory.CreateDirectory(uploadPath);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return fileName;
    }
}