﻿namespace Cms.Web.Api.DTOs
{
    public class ServiceBlogUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? ResimDosyaAdi { get; set; }

    }
}
