namespace EducationalCenter.Common.Dtos.Api.Responses
{
    public class AuthResponseDto
    {
        public bool IsAuthSuccessful { get; set; }

        public string ErrorMessage { get; set; }

        public string Token { get; set; }
    }
}
