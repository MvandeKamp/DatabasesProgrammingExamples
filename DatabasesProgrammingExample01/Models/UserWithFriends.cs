using System.Collections.ObjectModel;

namespace DatabasesProgrammingExample01.Models
{
    public class UserWithFriends
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public virtual ICollection<UserWithFriendsJoin> Friends { get; set; } = new Collection<UserWithFriendsJoin>();
        public virtual ICollection<UserWithFriendsJoin> FriendsWith { get; set; } = new Collection<UserWithFriendsJoin>();
    }
}
