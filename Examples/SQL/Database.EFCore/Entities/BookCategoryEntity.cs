using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    public class BookCategoryEntity
    {
        public int Id { get; set; }
        
        public string Category { get; set; }
    }
}