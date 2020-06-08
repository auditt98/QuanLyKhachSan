using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AutoMapper.Mappers;
using QLKS.Domain;
using QLKS.Models;

namespace QLKS.Extensions
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VATTU, VatTuModel>();
            CreateMap<VatTuModel, VATTU>();
            CreateMap<PHONG, PhongModel>();
            CreateMap<PhongModel, PHONG>();
            CreateMap<KhachHangModel, KHACHHANG>();
            CreateMap<KHACHHANG, KhachHangModel>();
            CreateMap<DichVuModel, DICHVU>();
            CreateMap<DICHVU, DichVuModel>();
            CreateMap<LoaiPhongModel, LOAIPHONG>();
            CreateMap<LOAIPHONG, LoaiPhongModel>();
            CreateMap<LoaiTinhTrangModel, LOAITINHTRANG>();
            CreateMap<LOAITINHTRANG, LoaiTinhTrangModel>();
            CreateMap<NHOMNGUOIDUNG, NhomNguoiDungModel>();
            CreateMap<NhomNguoiDungModel, NHOMNGUOIDUNG>();
            CreateMap<ThuePhongModel, THUEPHONG>();
            CreateMap<THUEPHONG, ThuePhongModel>();
            CreateMap<CHITIETTHUEPHONG, ChiTietThuePhongModel>();
            CreateMap<ChiTietThuePhongModel, CHITIETTHUEPHONG>();

            //ThuePhongModel -> KHACHHANG
            var ThuePhongKHACHHANGMap = CreateMap<ThuePhongModel, KHACHHANG>();
            ThuePhongKHACHHANGMap.ForAllMembers(opt => opt.Ignore());
            // than map property as following
            ThuePhongKHACHHANGMap.ForMember(dest => dest.sodienthoai, opt => opt.MapFrom(src => src.sdt));
            ThuePhongKHACHHANGMap.ForMember(dest => dest.socmt, opt => opt.MapFrom(src => src.socmt));
            ThuePhongKHACHHANGMap.ForMember(dest => dest.tenkhachhang, opt => opt.MapFrom(src => src.tenkhachhang));

            //KHACHHANG -> ThuePhongModel
            var KHACHHANGThuePhongMap = CreateMap<KHACHHANG, ThuePhongModel>();
            KHACHHANGThuePhongMap.ForAllMembers(opt => opt.Ignore());
            KHACHHANGThuePhongMap.ForMember(dest => dest.sdt, opt => opt.MapFrom(src => src.sodienthoai));
            KHACHHANGThuePhongMap.ForMember(dest => dest.socmt, opt => opt.MapFrom(src => src.socmt));
            KHACHHANGThuePhongMap.ForMember(dest => dest.tenkhachhang, opt => opt.MapFrom(src => src.tenkhachhang));
        }
    }
}