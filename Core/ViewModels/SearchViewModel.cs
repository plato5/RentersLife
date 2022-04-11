namespace RentersLife.Core.ViewModels
{
    public class SearchViewModel
    {
        public string ZipCode { get; set; }
        public int BedRooms { get; set; }
        public int BathRooms { get; set; }
        public double MinPrice { get; set; }
        public double MaxPrice { get; set; }
    }
}
