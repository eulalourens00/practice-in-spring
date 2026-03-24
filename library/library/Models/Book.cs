using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public string Status => AvailableQuantity > 0 ? "Доступна" : "Нет в наличии";
    }
}
