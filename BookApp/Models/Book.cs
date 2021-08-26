﻿using System;
namespace BookApp.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }

        public Category Category { get; set; }
    }
}