using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LapShop.Models
{
    public class TbSettings
    {
        public int Id { get; set; }
        public string WebsiteName { get; set; }
        public string Logo { get; set; }
        public string WebsiteDescription { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstgramLink { get; set; }
        public string YoutubeLink { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public string MiddlePanner { get; set; }
        public string LastPanner { get; set; }
    }
}
