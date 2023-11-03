using TechnicalTask1_DotNetCourse.Models;

namespace TechnicalTask1_DotNetCourse.Repository.Interfaces
{
    public interface ICatalogRepository
    {
        public Task<Catalog> GetCatalogWithRecursiveChildren(int id);
        Task<int> GetRootCatalogId();
        Task<bool> AddCatalog(Catalog catalog);
        Task<bool> ClearCatalog();
    }
}
