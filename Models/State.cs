using System;
using System.Collections.Generic;

namespace TeamPlayCRUD.Models
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Player> Players { get; set; }
    }
}
