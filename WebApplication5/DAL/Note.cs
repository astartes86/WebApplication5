﻿using System.ComponentModel.DataAnnotations;
using WebApplication5.Interfaces;

namespace WebApplication5.DAL
{
    public class Note : IEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Header { get; set; } = string.Empty;
        [Required]
        public string Text { get; set; } = string.Empty;
    }
}
