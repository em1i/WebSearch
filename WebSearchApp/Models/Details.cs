using System;
using Nest;

namespace WebSearch.Models
{
    public class Details
    {
        [Text(Name = "username")]
        public string Username { get; set; }

        [Text(Name = "name")]
        public string Name { get; set; }

        [Text(Name = "sex")]
        public string Sex { get; set; }

        [Text(Name = "address")]
        public string Address { get; set; }

        [Keyword(Name = "email")]
        public string Email { get; set; }

        [Date(Name = "birthdate", Format = "yyyy-MM-dd")]
        public DateTime Birthdate { get; set; }

        [Text(Name = "company")]
        public string Company { get; set; }

        [Text(Name = "job")]
        public string Job { get; set; }

        [Text(Name = "website")]
        public List<string> Website { get; set; }
        public string FirstWebsite => Website?.FirstOrDefault();
    }
}