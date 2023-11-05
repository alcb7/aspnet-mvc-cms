using Cms.Data.Models.Entities;
using Cms.Services.Responses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
    public interface IFileService
    {
        List<string> GetFiles();
        Task UploadFileAsync(IFormFile formFile);

        Task<FileResponse?> DownloadFileAsync(string fileName);

        Task DeleteAsync(string fileName);
    }
}
