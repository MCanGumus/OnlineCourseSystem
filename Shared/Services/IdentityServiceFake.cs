using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class IdentityServiceFake : IIdentityService
    {
        public Guid GetUserId => Guid.Parse("3c3fbec4-8df2-4691-83b3-e3713706464b");

        public string UserName => "Can21";
    }
}
