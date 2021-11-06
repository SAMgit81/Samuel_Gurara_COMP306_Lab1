using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Lab3Metflix.Models
{
    public class MovieBucket
    {
        public List<String> Buckets { get; set; }
        public Movie Movie { get; set; } = new Movie();
        public string SelectedBucket { get; set; }
        public IFormFile MovieImage { get; set; }
        public IFormFile MovieVideo { get; set; }
        public string Email { get; set; }
    }
}
