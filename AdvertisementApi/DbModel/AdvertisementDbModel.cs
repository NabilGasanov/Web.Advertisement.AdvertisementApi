using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertisementApi.Models;
using Amazon.DynamoDBv2.DataModel;

namespace AdvertisementApi.DbModel
{
    [DynamoDBTable("Advertisements")]
    public class AdvertisementDbModel
    {
        [DynamoDBHashKey]
        public string Id { get; set; }
        [DynamoDBProperty]
        public string Title { get; set; }
        [DynamoDBProperty]
        public string Description { get; set; }
        [DynamoDBProperty]
        public double Price { get; set; }
        [DynamoDBProperty]
        public DateTime CreationDateTime { get; set; }
        [DynamoDBProperty]
        public AdvertisementStatus Status { get; set; }
    }
}
