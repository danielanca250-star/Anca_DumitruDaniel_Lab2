
using System.Collections.Generic;
using Anca_DumitruDaniel_Lab2.Models;

namespace Anca_DumitruDaniel_Lab2.Models.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
