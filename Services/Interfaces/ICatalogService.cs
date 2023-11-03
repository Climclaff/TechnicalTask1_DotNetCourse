using TechnicalTask1_DotNetCourse.Models;

namespace TechnicalTask1_DotNetCourse.Services.Interfaces
{
    public interface ICatalogService
    {
        Task<bool> ImportFromFile(string rootPath);
        Task<bool> ExportHierarchyToFile(string filePath);
        Task<Catalog> GetCatalogWithRecursiveChildren(int id);
        Task<Catalog> GetCatalogWithRecursiveChildren();
    }
}
