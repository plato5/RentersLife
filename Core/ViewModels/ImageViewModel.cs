namespace RentersLife.Core.ViewModels
{
    public class ImageViewModel
    {
        public int Id { get; set; }
        public int ManagerProfileId { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
    }
}
