using AutoMapper;
using DAW.BLL.Interfaces;
using DAW.Common.DTOs.Client;
using DAW.DAL.Interfaces;
using DAW.Models;
using System.Reflection.Metadata.Ecma335;

namespace DAW.BLL.Services
{
    public class ClientService:IClientService
    {
        private readonly IClientRepository _repository;
        private readonly IMapper _mapper;

        public ClientService(IClientRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Add(CreateClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            await _repository.Add(client);
            await _repository.Save();
        }

        public async Task Delete(int id)
        {
            var client = await _repository.FindById(id);
            _repository.Delete(client);
            await _repository.Save();
        }

        public async Task<List<ClientDto>> GetAll()
        {
            var clients = await _repository.GetAll();
            return _mapper.Map<List<ClientDto>>(clients);
        }

        public async Task Update(int id, UpdateClientDto clientDto)
        {
            var client = await _repository.FindById(id);
            _mapper.Map(clientDto, client);
            await _repository.Save();
        }

        public async Task<List<ListCLientDto>> GetList()
        {
            var clients = await _repository.GetAll();
            return _mapper.Map<List<ListCLientDto>>(clients);
        }
    }
}
