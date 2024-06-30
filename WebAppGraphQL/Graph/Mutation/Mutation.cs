using WebAppGraphQL.Abstraction;
using WebAppGraphQL.Dto;
using WebAppGraphQL.Repository;

namespace WebAppGraphQL.Graph.Mutation
{
    public class Mutation(IProductRepository productRepository, IProductGroupRepository productGroupRepository, IStorageRepository storageRepository)
    {
        public int AddProduct(ProductDto productDto) => productRepository.AddProduct(productDto);
        public int AddProductGroup(ProductGroupDto productGroupDto, [Service] ProductGroupRepository groupGroupRepository) => 
            productGroupRepository.AddProductGroup(productGroupDto);
        public int AddStorage(StorageDto storageDto) => storageRepository.AddStorage(storageDto);
    }
}
