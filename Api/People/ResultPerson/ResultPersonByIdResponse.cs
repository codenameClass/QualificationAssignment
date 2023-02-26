namespace Api.People.ResultPerson
{
    public record ResultProcessedPersonByIdResponse
    (
        Guid id,
        int NumberOfVowelsFullName,
        int NumberOfConstenantsFullName,
        string FullName,
        string ReversedFullName,
        ResultPersonResponse PersonObjectInJson
    );
}
