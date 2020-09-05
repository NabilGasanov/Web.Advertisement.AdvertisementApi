using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdvertisementApi.DbModel;
using AdvertisementApi.Models;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using AutoMapper;

namespace AdvertisementApi.Services
{
    public class DynamoDBAdvertisementStorage : IAdvertisementStorageService

    {
        private readonly IMapper _mapper;
        public DynamoDBAdvertisementStorage(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<string> Add(AdvertisementModel model)
        {
            var advertisementEntity = _mapper.Map<AdvertisementDbModel>(model);

            advertisementEntity.Id = new Guid().ToString();
            advertisementEntity.CreationDateTime = DateTime.UtcNow;
            advertisementEntity.Status = AdvertisementStatus.Pending;

            using (var client = new AmazonDynamoDBClient())
            {
                using (var context = new DynamoDBContext(client))
                {
                    await context.SaveAsync(advertisementEntity);
                }
            }

            return advertisementEntity.Id;
        }

        public async Task Confirm(ConfirmAdvertisementModel model)
        {
            using (var client = new AmazonDynamoDBClient())
            {
                using (var context = new DynamoDBContext(client))
                {
                    var record = await context.LoadAsync<AdvertisementDbModel>(model.Id);
                    if(record is null)
                        throw new KeyNotFoundException($"A record wit Id = { model.Id } was not found");

                    if (model.Status == AdvertisementStatus.Active)
                    {
                        record.Status = AdvertisementStatus.Active;
                        await context.SaveAsync(record);
                    }
                    else
                        await context.DeleteAsync(record);
                }
            }
        }
    }
}
