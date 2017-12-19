using System;

namespace NativePlatformApp.Models
{
    public class UserUpdatedResponse
    {
        public string name { get; set; }
        public string job { get; set; }
        public DateTime updatedAt { get; set; }
    }
}