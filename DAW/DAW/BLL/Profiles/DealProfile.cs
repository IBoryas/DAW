using AutoMapper;
using DAW.Common.DTOs.Deals;
using DAW.Models;

namespace DAW.BLL.Profiles
{
    public class DealProfile:Profile
    {
        public DealProfile()
        {
            CreateMap<CreateDealDto, Deal>();
            CreateMap<Deal, DealDto>();
            CreateMap<UpdateDealDto, Deal>();
        }
    }
}
