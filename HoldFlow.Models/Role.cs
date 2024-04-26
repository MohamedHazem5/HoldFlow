using Microsoft.AspNetCore.Identity;

namespace HoldFlow.Models
{
	public class Role : IdentityRole<int>
    {
        public ICollection<UserRole> UsersRole { get; set; }
    }
}