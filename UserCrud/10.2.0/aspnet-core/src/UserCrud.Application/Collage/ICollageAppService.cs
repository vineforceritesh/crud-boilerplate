using Abp.Application.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserCrud.Collage.Dto;

namespace UserCrud.Collage
{
    public interface ICollageAppService : IApplicationService
    {
        Task<List<CollageDto>> GetAllAsync();
        Task<CollageDto> CreateAsync(CreatecollageDto input);
        Task<CollageDto> UpdateAsync(UpdateCollageDto input);
        Task DeleteAsync(int Id);


    }


}
