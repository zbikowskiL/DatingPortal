using System;

namespace DatingPortal.API.Dtos
{
    public class UserForListDto
    {
        public int Id { get; set; }
        public string Username { get; set; }

        // Basic data informations
        public string Gender { get; set; }
        public int Age { get; set; }
        public string ZodiacSign { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoUrl { get; set; }
    }
}