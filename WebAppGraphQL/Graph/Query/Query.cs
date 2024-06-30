using WebAppGraphQL.Abstraction;
using WebAppGraphQL.Dto;
using WebAppGraphQL.Models;
using WebAppGraphQL.Repository;

namespace WebAppGraphQL.Graph.Query
{
    public class Query(IProductRepository productRepository, IStorageRepository storageRepository)
    {
        public IEnumerable<ProductDto> GetProducts() => productRepository.GetAllProducts();
        public IEnumerable<ProductGroupDto> GetProductGroups([Service] IProductGroupRepository groupRepository) => 
            groupRepository.GetAllProductsGroups();
        public IEnumerable<StorageDto> GetStorageInfo() => storageRepository.GetAllStorages(); 
    }
}
