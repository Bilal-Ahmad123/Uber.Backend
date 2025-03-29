﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Vehicle.Application.Services;
public interface IFileService
{
    public Task<string> SaveFileAsync(IFormFile imageFile);
}
