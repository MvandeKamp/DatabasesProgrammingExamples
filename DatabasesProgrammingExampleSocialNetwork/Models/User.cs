using System.Collections.ObjectModel;

namespace DatabasesProgrammingExampleSocialNetwork.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public virtual ICollection<UserFriendsJoin> Friends { get; set; } = new Collection<UserFriendsJoin>();
        public virtual ICollection<Post> Posts { get; set; } = new Collection<Post>();
    }
}
