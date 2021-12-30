﻿namespace RentersLife.Core.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Telephone { get; set; }
        public string Fax { get; set; }

    }
}
