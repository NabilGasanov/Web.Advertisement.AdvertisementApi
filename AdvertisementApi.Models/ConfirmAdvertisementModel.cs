using System;
using System.Collections.Generic;
using System.Text;

namespace AdvertisementApi.Models
{
    public class ConfirmAdvertisementModel
    {
        public string Id { get; set; }
        public AdvertisementStatus Status { get; set; }
    }
}
