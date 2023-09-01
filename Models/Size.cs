using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
    public class Size : BaseModel
    {
        public bool IsMale { get; set; }
        public string ImgPathClothes { get; set; }
        public string ImgPathBoots { get; set; }
    }
}
