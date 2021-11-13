namespace Memberoo.Persistence.Seeds;

public class DevelopmentInitialiser
{
    private readonly Dictionary<int, Member> Members = new();

    public static void Initalise(MemberooContext ctx)
    {
        var initialiser = new DevelopmentInitialiser();
        initialiser.SeedEverything(ctx);
    }

    public void SeedEverything(MemberooContext ctx)
    {
        ctx.Database.EnsureCreated();

        //check if exists
        if (!ctx.Members.Any())
        {
            SeedMembers(ctx);
        }
    }

    private void SeedMembers(MemberooContext ctx)
    {
        Members.Add(1, new Member()
        {
            Active = true,
            Created = DateTime.Now,
            Employee = false,
            Email = "test1@test.com",
            FirstName = "Test1",
            LastName = "Test11",
            MembershipNo = "AB1234A",
            Password = "dsuhwiuofhrwiugher",
            LastModifiedBy = "Dan"
        });

        Members.Add(2, new Member()
        {
            Active = true,
            Created = DateTime.Now,
            Employee = false,
            Email = "test2@test.com",
            FirstName = "Test2",
            LastName = "Test2",
            MembershipNo = "BC1234D",
            Password = "dsuhwiuofhrwiugher",
            LastModifiedBy = "Dan"
        });

        foreach (var value in Members.Values)
        {
            ctx.Members.Add(value);
        }

        ctx.SaveChanges();
    }
}