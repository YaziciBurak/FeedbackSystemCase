using Core.Entities;

namespace Core.Utilities.Security.Entities;

public class OperationClaim:BaseEntity<int>
{
    public string Name { get; set; }
    public virtual ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    public OperationClaim()
    {
        UserOperationClaims = new List<UserOperationClaim>();
    }
    public OperationClaim(int id, string name, ICollection<UserOperationClaim> userOperationClaims) :this()
    {
        Id = id; 
        Name = name;
        UserOperationClaims = userOperationClaims;
    }
}
