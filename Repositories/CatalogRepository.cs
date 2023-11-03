using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using TechnicalTask1_DotNetCourse.Data;
using TechnicalTask1_DotNetCourse.Models;
using TechnicalTask1_DotNetCourse.Repository.Interfaces;

namespace TechnicalTask1_DotNetCourse.Repository
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly ApplicationDbContext _context;

        public CatalogRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> GetRootCatalogId()
        {
            int id = 0;
            try
            {
                id = await _context.Catalogs.MinAsync(c => c.CatalogId);
            }
            catch(Exception) { }
            return id;

        }
        public async Task<Catalog> GetCatalogWithRecursiveChildren(int id)
        {
            var catalog = await _context.Catalogs
                .Include(c => c.ChildCatalogs) 
                .FirstOrDefaultAsync(c => c.CatalogId == id);

            if (catalog != null)
            {
                foreach (var childCatalog in catalog.ChildCatalogs)
                {
                    childCatalog.ChildCatalogs = await _context.Catalogs.Where(c => c.ParentCatalogId == childCatalog.CatalogId).ToListAsync();

                }
            }

            return catalog;
        }
        
        public async Task<bool> AddCatalog(Catalog catalog)
        {
            await _context.AddAsync(catalog);
            await _context.SaveChangesAsync();    
            return true;
        }
        

        public async Task<bool> ClearCatalog()
        {
            await _context.Catalogs.ExecuteDeleteAsync();
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
