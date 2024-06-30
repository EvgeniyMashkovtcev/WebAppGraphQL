using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using WebAppGraphQL.Abstraction;
using WebAppGraphQL.Data;
using WebAppGraphQL.Dto;
using WebAppGraphQL.Models;

namespace WebAppGraphQL.Repository
{
    public class StorageRepository : IStorageRepository
    {
        StorageContext storageContext;
        private readonly IMapper _mapper;

        public StorageRepository(StorageContext storageContext, IMapper mapper)
        {
            this.storageContext = storageContext;
            this._mapper = mapper;
        }

        public int AddStorage(StorageDto storageDto)
        {
            if (storageContext.Storage.Any(s => s.ProductId == storageDto.ProductId))
                throw new Exception("Уже существует запись для этого продукта");

            var storage = _mapper.Map<Storage>(storageDto);

            storageContext.Storage.Add(storage);
            storageContext.SaveChanges();

            return storage.Id;
        }

        public IEnumerable<StorageDto> GetAllStorages()
        {
            throw new NotImplementedException();
        }
    }
}
