using System;
using System.Collections.Generic;

namespace GamePicker.WebApp.Models
{
    public partial class Team
    {
        public Team()
        {
            GameAwayTeam = new HashSet<Game>();
            GameHomeTeam = new HashSet<Game>();
        }

        public int TeamId { get; set; }
        public string TeamLocation { get; set; }
        public string TeamName { get; set; }
        public int SportId { get; set; }

        public virtual ICollection<Game> GameAwayTeam { get; set; }
        public virtual ICollection<Game> GameHomeTeam { get; set; }
        public virtual Sport Sport { get; set; }
    }
}
