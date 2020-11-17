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
            DATHANHTOAN = 6,
            HONGHOC = 7,
            DACHECKIN = 8,
            CHUACHECKIN = 9
        }
        //
        public enum EnumNhomNguoiDung
        {
            ADMIN = 1,
            LETAN = 2,
            KETOAN = 3,
            PHONG = 4
        } 
        
        public enum EnumQuyen
        {
            KHACHHANG_THEM = 1,KHACHHANG_SUA = 2,KHACHHANG_XOA = 3,KHACHHANG_XEM = 4,
            LOAIPHONG_THEM = 5,LOAIPHONG_SUA = 6,LOAIPHONG_XOA = 7,LOAIPHONG_XEM = 8,
            PHONG_THEM = 9,PHONG_SUA = 10,PHONG_XOA = 11,PHONG_XEM = 12,
            THUEPHONG_THEM = 13,THUEPHONG_SUA = 14,THUEPHONG_XOA = 15,THUEPHONG_XEM = 16,
            THANHTOAN_THEM = 17,THANHTOAN_SUA = 18,THANHTOAN_XOA = 19,THANHTOAN_XEM = 20,
            DICHVU_THEM = 21, DICHVU_SUA = 22, DICHVU_XOA = 23, DICHVU_XEM = 24,
            SUDUNGDICHVU_THEM = 25, SUDUNGDICHVU_SUA = 26, SUDUNGDICHVU_XOA = 27, SUDUNGDICHVU_XEM = 28,
            DATPHONG_THEM = 29, DATPHONG_SUA = 30, DATPHONG_XOA = 31, DATPHONG_XEM = 32,
            CHITIETTHUEPHONG_THEM = 37,
            CHITIETTHUEPHONG_SUA = 38,
            CHITIETTHUEPHONG_XOA = 39,
            CHITIETTHUEPHONG_XEM = 40,
            NHOMNGUOIDUNG_THEM = 41,
            NHOMNGUOIDUNG_SUA = 42,
            NHOMNGUOIDUNG_XOA = 43,
            NHOMNGUOIDUNG_XEM = 44,
            NGUOIDUNG_THEM = 45,
            NGUOIDUNG_SUA = 46,
            NGUOIDUNG_XOA = 47,
            NGUOIDUNG_XEM = 48,
            LOG_XEM = 49,
            LOAITINHTRANG_THEM = 50,
            LOAITINHTRANG_SUA = 51,
            LOAITINHTRANG_XOA = 52,
            LOAITINHTRANG_XEM = 53,
            THONGKEDOANHTHU_XEM = 54,
            THONGKEDOANHTHUDICHVU_XEM = 55,
            CHUONGTRINHGIAMGIA_THEM = 56,
            CHUONGTRINHGIAMGIA_SUA = 57,
            CHUONGTRINHGIAMGIA_XOA = 58,
            CHUONGTRINHGIAMGIA_XEM = 59,
            PHANQUYEN = 60,
            NGUOIDUNG_DOITHONGTINCANHAN = 61,
            PHONG_DOITRANGTHAI = 62,
            TRAPHONG_THEM = 63,
            TRAPHONG_SUA = 64,
            TRAPHONG_XOA = 65,
            TRAPHONG_XEM = 66
        }

        public enum EnumLoaiHanhDong
        {
            THEM = 1,
            SUA = 2,
            XOA = 3,
            DANGNHAP = 4,
            DANGXUAT = 5
        }
    }
}