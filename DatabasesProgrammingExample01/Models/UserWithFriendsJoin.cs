namespace DatabasesProgrammingExample01.Models
{
    public class UserWithFriendsJoin
    {
        public int? UserId { get; set; }
        public virtual UserWithFriends? User { get; set; }

        public int? FriendId { get; set; }
        public virtual UserWithFriends? Friend { get; set; }
    }
}
