using System;
using System.Collections.Generic;
using System.Text;

namespace NativePlatformApp.Models
{

    public class Response
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }
        public User[] data { get; set; }
    }
}
