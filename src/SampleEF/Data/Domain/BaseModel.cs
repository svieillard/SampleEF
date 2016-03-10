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
        Unchanged,
        Added,
        Modified,
        Deleted
    }
}
