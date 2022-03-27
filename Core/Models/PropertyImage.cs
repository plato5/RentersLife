namespace RentersLife.Core.Models
{
    public class PropertyImage
    {
        public int Id { get; set; }
        public int ManagerProfileId { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}
