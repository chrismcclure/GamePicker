using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamePicker.WebApp.Models
{
    public partial class Game
    {
        [Key]
        public int GameId { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public DateTime GameDateTime { get; set; }
        public int? HomeTeamScore { get; set; }
        public int? AwayTeamScore { get; set; }
        public int? Winner { get; set; }

        public virtual Team AwayTeam { get; set; }
        public virtual Team HomeTeam { get; set; }
    }
}
