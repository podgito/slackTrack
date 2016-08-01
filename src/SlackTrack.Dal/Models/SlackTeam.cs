using System.Collections.Generic;

namespace SlackTrack.Dal.Models
{
    public class SlackTeam
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SlackUser> Users { get; set; }
    }
}