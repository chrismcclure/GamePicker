using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamePicker.WebApp.Models
{
    public class GamesDisplayInfo
    {
        public DateTime GameTime { get; set; }
        public string HomeTeam { get; set; }
        public int HomeTeamId { get; set; }
        public string AwayTeam { get; set; }
        public int AwayTeamId { get; set; }
    }
}
