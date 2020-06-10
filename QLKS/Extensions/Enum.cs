using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKS.Extensions
{
    public class Enum
    {
        public enum EnumLoaiTinhTrang
        {
            TRONG = 1,
            DATHUE = 2,
            DATTRUOC = 3,
            BAN = 4,
            CHUATHANHTOAN = 5,
            DATHANHTOAN = 6
        }

        public enum EnumNhomNguoiDung
        {
            ADMIN = 1,
            LETAN = 2,
            KETOAN = 3,
            PHONG = 4
        } 
        
        public enum EnumQuyen
        {
            CAPQUYEN = 1,
            THONGKEDOANHTHU = 2,
            THONGKEDATPHONG = 3,
            THONGKEDOANHTHUDICHVU = 4,
            THUEPHONG = 5,
            TRAPHONG = 6,
            DM_LOAIPHONG = 7,
            DM_PHONG = 8,
            DM_DICHVU = 9,
            DM_VATTU = 10,
            DM_KHACHHANG = 11,
        }

        public enum EnumLoaiHanhDong
        {
            THEM = 1,
            SUA = 2,
            XOA = 3,
            DANGNHAP = 4
        }
    }
}