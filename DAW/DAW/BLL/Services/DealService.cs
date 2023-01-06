using AutoMapper;
using DAW.BLL.Interfaces;
using DAW.Common.DTOs.Client;
using DAW.Common.DTOs.Deals;
using DAW.DAL.Interfaces;
using DAW.Models;

namespace DAW.BLL.Services
{
    public class DealService: IDealService
    {
        private readonly IDealRepository _repository;
        private readonly IMapper _mapper;

        public DealService(IDealRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task Add(CreateDealDto dealDto)
        {
            var deal = _mapper.Map<Deal>(dealDto);
            await _repository.Add(deal);
            await _repository.Save();
        }

        public async Task Delete(int id)
        {
            var deal = await _repository.FindById(id);
            _repository.Delete(deal);
            await _repository.Save();
        }

        public async Task<List<DealDto>> GetAll()
        {
            var deals = await _repository.GetAll();
            return _mapper.Map<List<DealDto>>(deals);
        }

        public async Task Update(int id, UpdateDealDto dealDto)
        {
            var deal = await _repository.FindById(id);
            _mapper.Map(dealDto, deal);
            await _repository.Save();
        }
    }
}
