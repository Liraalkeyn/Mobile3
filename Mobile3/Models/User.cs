using System;
using System.Collections.Generic;

namespace Mobile3.Models;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public DateOnly Birth { get; set; }

    public virtual ICollection<Transport> Transports { get; set; } = new List<Transport>();
}
