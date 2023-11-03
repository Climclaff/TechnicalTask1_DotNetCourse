namespace TechnicalTask1_DotNetCourse.Models
{
    public class Catalog
    {

        public int CatalogId { get; set; }      
        public string CatalogName { get; set; } 
        public int? ParentCatalogId { get; set; } 

        public Catalog ParentCatalog { get; set; } 
        public ICollection<Catalog> ChildCatalogs { get; set; }

        public ICollection<DbFile> DbFiles { get; set; }
    }

}

