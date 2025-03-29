using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Vehicle.Application.Services;

namespace Vehicle.Infrastructure.Services;
public class FileService : IFileService
{
    public async Task<string> SaveFileAsync(IFormFile imageFile)
    {
        string? imagePath = null;

        if (imageFile != null)
        {
            var fileName = $"{Guid.NewGuid()} - {Path.GetFileName(imageFile.FileName)}";
            var filePath = Path.Combine("wwwroot", "images", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            imagePath = Path.Combine("images", fileName);
        }
        return imagePath!;
    }
}
