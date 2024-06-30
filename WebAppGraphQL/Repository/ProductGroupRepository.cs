using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using WebAppGraphQL.Abstraction;
using WebAppGraphQL.Data;
using WebAppGraphQL.Dto;
using WebAppGraphQL.Models;

namespace WebAppGraphQL.Repository
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        StorageContext storageContext;
        private readonly IMapper _mapper;
        public ProductGroupRepository(StorageContext storageContext, IMapper mapper)
        {
            this.storageContext = storageContext;
            this._mapper = mapper;
        }

        public int AddProductGroup(ProductGroupDto productGroupDto)
        {
            if (storageContext.ProductGroup.Any(p => p.Name == productGroupDto.Name))
                throw new Exception("Есть продукт с таким именем");

            var entity = _mapper.Map<ProductGroup>(productGroupDto);
            storageContext.ProductGroup.Add(entity);
            storageContext.SaveChanges();
            return entity.Id;
        }

        public void DeleteProductGroup(int id)
        {
            var productGroup = storageContext.ProductGroup.Find(id);
            if (productGroup == null)
                throw new Exception("Группа продуктов не найдена");

            storageContext.ProductGroup.Remove(productGroup);
            storageContext.SaveChanges();
        }

        public IEnumerable<ProductGroupDto> GetAllProductsGroups()
        {
            var listDto = storageContext.ProductGroup.Select(_mapper.Map<ProductGroupDto>).ToList();
            return listDto;
        }
    }
}
