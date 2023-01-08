using System.Collections.ObjectModel;

namespace DatabasesProgrammingExampleSocialNetwork.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string? Content { get; set; }
        public DateTime? PostDate { get; set; }
        public virtual ICollection<Reaction> Reactions { get; set; } = new Collection<Reaction>();
    }
}
