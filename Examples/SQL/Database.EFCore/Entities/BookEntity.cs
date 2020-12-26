using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.EFCore.Entities
{
    [Table("book")]
    public class BookEntity
    {
        public int Id { get; set; }
        
        public BookCategoryEntity Category { get; set; }
        
        public Double Rating { get; set; }

        public String Name { get; set; }
    }
}