using Cms.Data.Models.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Services.Abstract
{
	public interface IFileService<FileEntity>
	{
		IQueryable<FileEntity?> GetFileList();
		Task<FileEntity> GetFile(int id);
		Task<FileEntity?> PostFile( IFormFile entity);
	}
}
