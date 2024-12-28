using Microsoft.AspNetCore.Http;

namespace Application.IService;

public interface IFileService
{
    public Task<string> UploadFileAsync(IFormFile file, string uploadPath);
}
