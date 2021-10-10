using System.Collections.Generic;

namespace EducationalCenter.Common.Dtos.Api.Responses
{
    public class RegistrationResponseDto
    {
        public bool IsSuccessfulRegistration { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}
