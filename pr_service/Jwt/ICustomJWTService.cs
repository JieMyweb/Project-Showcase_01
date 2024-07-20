using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr_service
{
    public interface ICustomJWTService
    {
        //獲取Token
        string GetToken(UserRes user);
    }
}
