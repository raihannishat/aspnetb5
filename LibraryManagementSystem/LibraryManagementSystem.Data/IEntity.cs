﻿using System;

namespace LibraryManagementSystem.Data
{
    public interface IEntity<T>
    {   
        T Id { get; set; }  
    }
}
