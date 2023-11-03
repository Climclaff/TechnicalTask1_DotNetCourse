namespace TechnicalTask1_DotNetCourse.Models
{
    public class DbFile
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int CatalogId { get; set; } 

        public Catalog Catalog { get; set; } 
    }
}
