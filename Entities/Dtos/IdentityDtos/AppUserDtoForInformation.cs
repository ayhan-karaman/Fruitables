namespace Entities.Dtos.IdentityDtos
{
    public record AppUserDtoForInformation:AppUserDto
    {
        
         public string FullName  => $"{FirstName} {LastName}"; 

    }
}