using Cms.Data.Context;
using Cms.Data.Models.Entities;
using Cms.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Concrete
{
	public class FileService : IFileService<FileEntity>
	{
		private readonly IFileService<FileEntity> _filerepository;
		private readonly AppDbContext _appDbContext;

		public FileService(IFileService<FileEntity> filerepository, AppDbContext appDbContext)
		{
			_filerepository = filerepository;
			_appDbContext = appDbContext;
		}

		public async Task<FileEntity> GetFile(int id)
		{
			// Veritabanından belirli bir dosya verisini alma kodunu buraya ekleyin
			var file = await _appDbContext.Files.FirstOrDefaultAsync(f => f.Id == id);
			return file;
		}

		public IQueryable<FileEntity> GetFileList()
		{
			// Veritabanındaki tüm dosya verilerini sorgu olarak alın
			var fileListQuery = _appDbContext.Files;

			// IQueryable'i bir liste olarak dönüştürün (materialize)
			var fileList = fileListQuery.ToList();

			return fileList.AsQueryable();
		}

		public async Task<FileEntity> PostFile(IFormFile formFile)
		{
			// Gelen dosya verisini veritabanına kaydetme kodunu buraya ekleyin
			if (formFile == null || formFile.Length == 0)
			{
				throw new Exception("Dosya geçersiz veya boş.");
			}

			using (var stream = new MemoryStream())
			{
				await formFile.CopyToAsync(stream);

				var file = new FileEntity
				{
					Data = stream.ToArray(),
					MimeType = formFile.ContentType,
					FileName = formFile.FileName
				};

				_appDbContext.Files.Add(file);
				await _appDbContext.SaveChangesAsync();

				return file;
			}
		}
	}
}
