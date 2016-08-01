namespace SlackTrack.Dal.Models
{
    public class SlackUser
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string TeamId { get; set; }

        public virtual SlackTeam Team { get; set; }
    }
}