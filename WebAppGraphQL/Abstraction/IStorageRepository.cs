using WebAppGraphQL.Dto;
using WebAppGraphQL.Models;

namespace WebAppGraphQL.Abstraction
{
    public interface IStorageRepository
    {
        IEnumerable<StorageDto> GetAllStorages();
        int AddStorage(StorageDto storageDto);

    }
}
