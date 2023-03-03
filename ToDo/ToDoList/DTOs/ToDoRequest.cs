﻿using System.ComponentModel.DataAnnotations;

namespace ToDoList.DTOs
{
    public class ToDoRequest
    {
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Details { get; set; }
        
    }
}
