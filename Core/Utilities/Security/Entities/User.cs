using Core.Entities;

namespace Core.Utilities.Security.Entities;

public class User : BaseEntity<int>
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    public User()
    {
        UserOperationClaims = new HashSet<UserOperationClaim>();
    }
    public User(int id, string userName, string email, byte[] passwordHash, byte[] passwordSalt, ICollection<UserOperationClaim> userOperationClaims)
    {
        Id = id;
        UserName = userName;
        Email = email;
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
        UserOperationClaims = userOperationClaims;
    }
}
