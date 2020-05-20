using QLKS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Extensions.Auth
{
    public class Auth
    {
        private QLKSContext db = new QLKSContext();
        public bool IsLogin(string username, string password)
        {
            //do something
            return true;
        }
    }
}