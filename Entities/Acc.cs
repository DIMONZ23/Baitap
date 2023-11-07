using System;
using System.Collections.Generic;

namespace Baitap.Entities;

public partial class Acc
{
    public string Fullname { get; set; } = null!;

    public int Age { get; set; }

    public string? Email { get; set; }

    public string? Mobile { get; set; }
}
