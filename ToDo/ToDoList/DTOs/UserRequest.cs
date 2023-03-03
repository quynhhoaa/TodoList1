﻿using System.ComponentModel.DataAnnotations;
using ToDoList.Models;

namespace ToDoList.DTOs
{
    public class UserRequest
    {
        [MaxLength(100)]
        [Required]
        public string Email { get; set; }
        [MaxLength(100)]
        [Required]
        public string Username { get; set; }
        [MaxLength(200)]
        [Required]
        public string Password { get; set; }
        public ICollection<Todo> Tasks { get; set; }
    }
}
