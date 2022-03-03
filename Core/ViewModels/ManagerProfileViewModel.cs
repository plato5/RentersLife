namespace RentersLife.Core.ViewModels
{
    public class ManagerProfileViewModel
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyDescription { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }
        public double Price { get; set; }

        //public ImageViewModel Image1 { get; set; }
        //public ImageViewModel Image2 { get; set; }
        //public ImageViewModel Image3 { get; set; }
        //public ImageViewModel Image4 { get; set; }

    }
}
