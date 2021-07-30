using System;

namespace TeamPlayCRUD.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateBirth { get; set; }
        public string Passport { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
       
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int StateId { get; set; }
        public State State { get; set; }

    }
}
