namespace SlackTrack.Dal.Models
{
    public class SlackTaskLogItem
    {
        public int Id { get; set; }

        public int Hours { get; set; }
        public string Name { get; set; }
        public int MyProperty { get; set; }

        public virtual SlackUser User { get; set; }
    }
}