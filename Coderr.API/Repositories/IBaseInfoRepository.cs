using Coderr.API.Models.DTOs;

namespace Coderr.API.Repositories
{
    public interface IBaseInfoRepository
    {
        Task<BaseInfoResponseDTO> GetBaseInfoAsync();
    }
}
