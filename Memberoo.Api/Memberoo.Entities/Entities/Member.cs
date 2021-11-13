using Memberoo.Domain.Common;

namespace Memberoo.Domain.Entities;

public class Member : AuditableEntity
{
    public int MemberId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int EncodedId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? MembershipNo { get; set; }
    public bool Active { get; set; }
    public bool Employee { get; set; }

}