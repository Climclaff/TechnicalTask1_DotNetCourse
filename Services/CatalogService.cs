using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using System.Xml;
using TechnicalTask1_DotNetCourse.Data;
using TechnicalTask1_DotNetCourse.Helpers;
using TechnicalTask1_DotNetCourse.Models;
using TechnicalTask1_DotNetCourse.Repository.Interfaces;
using TechnicalTask1_DotNetCourse.Services.Interfaces;

namespace TechnicalTask1_DotNetCourse.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly ICatalogRepository _repository;

        public CatalogService(ICatalogRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> ImportFromFile(string filePath)
        {
            try
            {
                string directoryPath = Path.GetDirectoryName(filePath);
                await ExportHierarchyToFile(Path.Combine(directoryPath, "exportDb.txt"));
                string jsonContent = await File.ReadAllTextAsync(filePath);
                Catalog catalog = JsonConvert.DeserializeObject<Catalog>(jsonContent, new JsonSerializerSettings
                {
                    ContractResolver = new CatalogContractResolver(),
                    MissingMemberHandling = MissingMemberHandling.Ignore
                });
                await _repository.ClearCatalog();
                await _repository.AddCatalog(catalog);
                return true;
            }
            catch(Exception) { }
            return false;
        }

        public async Task<bool> ExportHierarchyToFile(string filePath)
        {
            try
            {
                int rootId = await _repository.GetRootCatalogId();
                if (rootId != 0)
                {
                    Catalog hierarchy = await _repository.GetCatalogWithRecursiveChildren(rootId);
                    string json = JsonConvert.SerializeObject(hierarchy, Newtonsoft.Json.Formatting.Indented,
                        new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                            ContractResolver = new CatalogContractResolver(),
                            MissingMemberHandling = MissingMemberHandling.Ignore
                        });
                    string directoryPath = Path.GetDirectoryName(filePath);
                    Directory.CreateDirectory(directoryPath);
                    await File.WriteAllTextAsync(filePath, json);
                    return true;
                }
            }
            catch(Exception) {}
            return false;

        }

        public async Task<Catalog> GetCatalogWithRecursiveChildren(int id)
        {         
            return await _repository.GetCatalogWithRecursiveChildren(id);
        }
        public async Task<Catalog> GetCatalogWithRecursiveChildren()
        {
            int rootCatId = await _repository.GetRootCatalogId();
            return await _repository.GetCatalogWithRecursiveChildren(rootCatId);
        }

    }
    
}
