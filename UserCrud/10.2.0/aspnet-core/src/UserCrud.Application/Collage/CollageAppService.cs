using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserCrud.Collage.Dto;

namespace UserCrud.Collage
{
    public class CollageAppService : ApplicationService, ICollageAppService
    {
        private readonly IRepository<Collage, int> _collageRepository;

        public CollageAppService(IRepository<Collage, int> collageRepository)
        {
            _collageRepository = collageRepository;
        }

        public async Task<List<CollageDto>> GetAllAsync()
        {
            var collages = await _collageRepository.GetAllListAsync();
            return ObjectMapper.Map<List<CollageDto>>(collages);
        }


        public async Task<CollageDto> CreateAsync(CreatecollageDto input)
        {
            var collage = ObjectMapper.Map<Collage>(input);
            var insertedCollage = await _collageRepository.InsertAsync(collage);
            return ObjectMapper.Map<CollageDto>(insertedCollage);
        }

        public async Task<CollageDto> UpdateAsync(UpdateCollageDto input)
        {
            var collage = await _collageRepository.FirstOrDefaultAsync(x => x.Id == input.Id);
            ObjectMapper.Map(input, collage);
            await _collageRepository.UpdateAsync(collage);
            return ObjectMapper.Map<CollageDto>(collage);
        }

        public async Task DeleteAsync(int id)
        {
            var collage = await _collageRepository.FirstOrDefaultAsync(id);
            if (collage == null)
                throw new UserFriendlyException("Collage not found");

            await _collageRepository.DeleteAsync(collage);
        }

    }
}
