namespace Database.Models
{
    public class Thing : BaseModel
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsMust { get; set; }
        public string? Link { get; set; }
        public double? Cost { get; set; }
        public ulong CategotyId { get; set; }
        public Category Category { get; set; }
        public string? ImgPath { get; set; }
        public string? ImgUrl { get; set; }
        public long? OwnerPhotoId { get; set; }
        public long? PhotoId { get; set; }
    }
}
