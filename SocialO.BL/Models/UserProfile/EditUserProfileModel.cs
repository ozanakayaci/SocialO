namespace SocialO.WebApi.Models.UserProfile
{
    public class EditUserProfileModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public char? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? About { get; set; }
        public int UserId { get; set; }


    }
}
