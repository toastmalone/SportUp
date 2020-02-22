using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportUp.Data.Models
{
    public enum TeamPlayStyle
    {
        Casual,
        Serious,
        Hardcore,
        League,
        Event,
    }

    public enum GeneralMeetingTimes
    {
        Morning,
        Afternoon,
        Evening
    }

    public class Team
    {
        [Key]
        public int Id { get; set; }

        public string TeamName { get; set; }

        [Required]
        public ICollection<UserTeam> UserTeams { get; set; }
        
        [Required]
        public Sport TeamSportType { get; set; }

        [Required]
        public TeamPlayStyle TeamPlayStyle { get; set; }

        public int TeamMaxPlayers { get; set; }

        public DateTime TeamCreationDate { get; set; }

        public bool IsPickupTeam { get; set; }

        public GeneralMeetingTimes MeetingTime { get; set; }
    }
}
