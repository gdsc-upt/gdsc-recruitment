using Microsoft.AspNetCore.Identity;

namespace GdscRecruitment.Auth;

public class User : IdentityUser
{
    [PersonalData] public string FirstName { get; set; }
    [PersonalData] public string LastName { get; set; }

    public override string ToString()
    {
        return FirstName + " " + LastName;
    }
}
