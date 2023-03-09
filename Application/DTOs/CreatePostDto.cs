﻿using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CreatePostDto 
    {
        public CreatePostDto()
        {

        }
        public string Title { get; set; }
        public string? Content { get; set; }
        public bool IsPublished { get; set; }
        public int CategoryId { get; set; }
    }
}
