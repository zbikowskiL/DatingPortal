using System;

namespace DatingPortal.API.Dtos
{
    public class PhotoForReturnDto
    {
        public PhotoForReturnDto(int id, string url, string description, DateTime dateAdded, bool isMain)
        {
            this.Id = id;
            this.Url = url;
            this.Description = description;
            this.DateAdded = dateAdded;
            this.IsMain = isMain;

        }

        public PhotoForReturnDto()
        {

        }

        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
    }
}