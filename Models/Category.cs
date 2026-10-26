using System.Collections.Generic;

namespace Anca_DumitruDaniel_Lab2.Models
{
    public class Category
    {
        public int ID { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public ICollection<BookCategory> BookCategories { get; set; }
            = new List<BookCategory>();
    }
}