﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleEF.Data.Domain
{
    public interface BaseModel
    {
        int Id { get; set; }
        State State { get; set; }
        
    }

    public enum State
    {
        Unchanged = 1,
        Added = 2,
        Modified = 3,
        Deleted = 4
    }
}
