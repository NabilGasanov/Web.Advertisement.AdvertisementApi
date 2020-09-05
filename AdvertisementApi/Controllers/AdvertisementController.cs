using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertisementApi.Models;
using AdvertisementApi.Responses;
using AdvertisementApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisementApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        private readonly IAdvertisementStorageService _advertisementStorageService;

        public AdvertisementController(IAdvertisementStorageService advertisementStorageService)
        {
            _advertisementStorageService = advertisementStorageService;
        }

        [HttpPost("create")]
        [ProducesResponseType(404)]
        [ProducesResponseType( typeof(CreateAdvertisementResponse), 201)]
        public async Task<IActionResult> CreateAsync(AdvertisementModel model)
        {
            try
            {
                var recordId = await _advertisementStorageService.Add(model);
                return StatusCode(201, new CreateAdvertisementResponse {Id = recordId});
            }
            catch (KeyNotFoundException)
            {
                return new NotFoundResult();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("confirm")]
        [ProducesResponseType(403)]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Confirm(ConfirmAdvertisementModel model)
        {
            try
            {
                await _advertisementStorageService.Confirm(model);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return new NotFoundResult();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}