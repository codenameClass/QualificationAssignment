using Cui;
using System.ComponentModel.DataAnnotations;

public record PersonInputDto
(
    [Required] string FirstName,
    [Required] string LastName,
    List<string> SocialSkills,
    List<SocialAccountInputDto> SocialAccounts
);