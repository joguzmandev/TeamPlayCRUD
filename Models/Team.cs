using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamPlayCRUD.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public DateTime CreatedAt { get; set; }

        public Boolean IsActive { get; set; }

        public List<Player> Players { get; set; }
    }
}
