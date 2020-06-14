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
            DICHVU_THEM = 21,
            DICHVU_SUA = 22,
            DICHVU_XOA = 23,
            DICHVU_XEM = 24,
            SUDUNGDICHVU_THEM = 25,
            SUDUNGDICHVU_SUA = 26,
            SUDUNGDICHVU_XOA = 27,
            SUDUNGDICHVU_XEM = 28,
            VATTU_THEM = 29,
            VATTU_SUA = 30,
            VATTU_XOA = 31,
            VATTU_XEM = 32,
            DATPHONG_THEM = 33,
            DATPHONG_SUA = 34,
            DATPHONG_XOA = 35,
            DATPHONG_XEM = 36,
            CHITIETDATPHONG_THEM = 37,
            CHITIETDATPHONG_SUA = 38,
            CHITIETDATPHONG_XOA = 39,
            CHITIETDATPHONG_XEM = 40,
            CHITIETTHUEPHONG_THEM = 41,
            CHITIETTHUEPHONG_SUA = 42,
            CHITIETTHUEPHONG_XOA = 43,
            CHITIETTHUEPHONG_XEM = 44,
            NHOMNGUOIDUNG_THEM = 45,
            NHOMNGUOIDUNG_SUA = 46,
            NHOMNGUOIDUNG_XOA = 47,
            NHOMNGUOIDUNG_XEM = 48,
            NGUOIDUNG_THEM = 49,
            NGUOIDUNG_SUA = 50,
            NGUOIDUNG_XOA = 51,
            NGUOIDUNG_XEM = 52,
            TRAPHONG_THEM = 53,
            TRAPHONG_SUA = 54,
            TRAPHONG_XOA = 55,
            TRAPHONG_XEM = 56,
            LICHSU_XEM = 57,
            LOAITINHTRANG_THEM = 58,
            LOAITINHTRANG_SUA = 59,
            LOAITINHTRANG_XOA = 60,
            LOAITINHTRANG_XEM = 61,
            THONGKEDOANHTHU_XEM = 62,
            THONGKESOLUONGDATPHONG_XEM = 63,
            THONGKEDOANHTHUDICHVU_XEM = 64
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