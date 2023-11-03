using TechnicalTask1_DotNetCourse.Models;

namespace TechnicalTask1_DotNetCourse.Repository.Interfaces
{
    public interface IDbFileRepository
    {
        Task<List<DbFile>> GetFilesForCatalog(int catalogId);

    }
}
