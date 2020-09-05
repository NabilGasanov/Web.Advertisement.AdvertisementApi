using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertisementApi.Models;

namespace AdvertisementApi.Services
{
    public interface IAdvertisementStorageService
    {
        Task<string> Add(AdvertisementModel model);
        Task Confirm(ConfirmAdvertisementModel model);
    }
}
