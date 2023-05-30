using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Tuckshop.Areas.Identity.Data;

// Add profile data for application users by adding properties to the TuckshopUser class
public class TuckshopUser : IdentityUser
{
    public string Firstname { get; set; }
    public string LastName { get; set; }
}

