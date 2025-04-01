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
        if (imageFile == null) throw new ArgumentNullException(nameof(imageFile));

        var uploadsFolder = Path.Combine("wwwroot", "images", "vehicles");
        Directory.CreateDirectory(uploadsFolder); 

        var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(imageFile.FileName)}".Replace(" ", "");

        var filePath = Path.Combine(uploadsFolder, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await imageFile.CopyToAsync(stream);
        }

        return $"images/{fileName}";
    }
}
