using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Equipment : BaseModel
    {
        public ulong OwnerId { get; set; }
        public bool IsBooked { get; set; }
        public ulong? BookedId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public Category Category { get; set; }
        public ulong CategoryId { get; set; }
    }
}
