using System;
using System.Collections.Generic;

namespace pr_model.Models;

public partial class Users
{
    public string Id { get; set; } = null!;

    public string NickName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime CreateTime { get; set; }

    public int UserType { get; set; }

    public string UserName { get; set; } = null!;
}
