using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
//
namespace QLKS.Services
{
    public class NguoiDungServices
    {
        public bool isLoggedIn()
        {
            var httpContext = HttpContext.Current;
            if(httpContext.Session["tendangnhap"] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}