using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamePicker.WebApp.Models
{
    public partial class Sport
    {
        public Sport()
        {
            Team = new HashSet<Team>();
        }

        [Key]
        public int SportId { get; set; }
        public string SportTitle { get; set; }

        public virtual ICollection<Team> Team { get; set; }
    }
}
