using System.Collections.ObjectModel;

namespace DatabasesProgrammingExampleSocialNetwork.Models
{
    public class Reaction
    {
        public int ReactionId { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string? Comment { get; set; }
        public int? Like { get; set; }

        public DateTime? ReactionDate;
        public int? ReactedToId { get; set; }
    }
}
