﻿using System;
using System.Collections.Generic;

namespace Mobile3.Models;

public partial class Transport
{
    public int TransportId { get; set; }

    public int UserId { get; set; }

    public int Code { get; set; }

    public string Color { get; set; } = null!;

    public string Company { get; set; } = null!;
    
}
