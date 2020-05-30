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
        }
    }
}