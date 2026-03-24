using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsOverdue => !ReturnDate.HasValue && DueDate < DateTime.Now;
        public bool IsActive => !ReturnDate.HasValue;
        public string UserLogin { get; set; }
        public string BookTitle { get; set; }
    }
}
