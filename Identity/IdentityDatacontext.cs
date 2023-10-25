using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Girişlogin.Identity
{
    public class IdentityDatacontext : IdentityDbContext<ApplicationUser>
    {
        public IdentityDatacontext():base("identityConntection")
        {
                
        }
    }
}