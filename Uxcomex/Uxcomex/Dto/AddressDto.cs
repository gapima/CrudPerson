﻿using Uxcomex.Models;

namespace Uxcomex.Dto
{
    public class AddressDto
    {
        public int id { get; set; }
        public string StreetAddress { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PersonId { get; set; }
        public PersonModel Person { get; set; }


    }
}
