﻿using System;

namespace AttendanceSystem.Data
{
    public interface IEntity<T>
    {   
        T Id { get; set; }  
    }
}
