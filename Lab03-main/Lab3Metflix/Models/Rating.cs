using Amazon.S3.Encryption.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3Metflix.Models
{
    public class Rating
    {
        public Users Users { get; set; }
        public string Comment { get; set; }
        public int RateNum { get; set; }
        public DateTime RateDate { get; set; } = new DateTime().ToLocalTime();
    }
}
