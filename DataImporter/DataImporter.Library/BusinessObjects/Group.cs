﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Library.BusinessObjects
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid ApplicationUserId { get; set; }
    }
}
