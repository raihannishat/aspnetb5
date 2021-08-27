﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Borrow.BusinessObjects
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Barcode { get; set; }
        public double Price { get; set; }
    }
}
