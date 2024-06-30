using WebAppGraphQL.Dto;
using WebAppGraphQL.Models;

namespace WebAppGraphQL.Abstraction
{
    public interface IProductGroupRepository
    {
        IEnumerable<ProductGroupDto> GetAllProductsGroups();
        int AddProductGroup(ProductGroupDto productGroupDto);
        void DeleteProductGroup(int id);
    }
}
