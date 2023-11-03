using Microsoft.EntityFrameworkCore;
using TechnicalTask1_DotNetCourse.Data;
using TechnicalTask1_DotNetCourse.Models;
using TechnicalTask1_DotNetCourse.Repository.Interfaces;

namespace TechnicalTask1_DotNetCourse.Repository
{
    public class DbFileRepository : IDbFileRepository
    {
        private readonly ApplicationDbContext _context;
        public DbFileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DbFile>> GetFilesForCatalog(int catalogId)
        {
            return await _context.DbFiles.Where(f => f.CatalogId == catalogId).ToListAsync();
        }
    }
}
