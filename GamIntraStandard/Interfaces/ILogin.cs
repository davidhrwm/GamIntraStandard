using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamIntraStandard.Models;

namespace GamIntraStandard.Interfaces
{
    interface ILogin
    {
        bool VerifyLogin(string usuario, string passwd);
        void SetCookie(string userName);
    }
}
