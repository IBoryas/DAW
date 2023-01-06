using AutoMapper;
using DAW.Common.DTOs.Client;
using DAW.Models;

namespace DAW.BLL.Profiles
{
    public class ClientProfile: Profile
    {
        public ClientProfile()
        {
            CreateMap<CreateClientDto, Client>();
            CreateMap<Client, ClientDto>()
                .ForMember(
                    x=>x.Deals,
                    y=>y.MapFrom(z=>z.Deals.Select(d=>d.Name)));
            CreateMap<Client, ListCLientDto>();
            CreateMap<UpdateClientDto, Client>();
        }
    }
}
