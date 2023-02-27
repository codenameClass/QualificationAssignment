﻿namespace Api.People.UpdatePerson
{
    public record UpdatePersonRequest
    (
        Guid id,
        string Firstname,
        string Lastname,
        List<string> SocialSkills,
        List<UpdatePersonSocialAccountRequest> SocialAccounts
    );
}
