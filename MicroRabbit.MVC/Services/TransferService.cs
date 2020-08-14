using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MicroRabbit.MVC.Models.DTO;
using Newtonsoft.Json;

namespace MicroRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;

        public TransferService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        //public async Task Transfer(DiscoveryDto transferDto)
        //{
        //    try
        //    {
        //        var uri = "https://localhost:44357/api/Banking";
        //        var transferContent = new StringContent(JsonConvert.SerializeObject(transferDto),
        //                                        System.Text.Encoding.UTF8, "application/json");
        //        var response = await _apiClient.PostAsync(uri, transferContent);
        //        response.EnsureSuccessStatusCode();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}


        public async Task Discovery(DiscoveryDto transferDto)
        {
            try
            {
                var uri = "https://localhost:44357/api/Discovery";

                for (int i = 0; i < transferDto.noOfAssetScanReq; i++)
                {
                    var discoveryInfo = new DiscoveryInfo() { Id = Guid.NewGuid().ToString(), ScanType = "Asset" };

                    var transferContent = new StringContent(JsonConvert.SerializeObject(discoveryInfo),
                                                    System.Text.Encoding.UTF8, "application/json");
                    var response = await _apiClient.PostAsync(uri, transferContent);
                    response.EnsureSuccessStatusCode();
                }

                for (int i = 0; i < transferDto.noOfAccountScanReq; i++)
                {
                    var discoveryInfo = new DiscoveryInfo() { Id = Guid.NewGuid().ToString(), ScanType = "Account" };

                    var transferContent = new StringContent(JsonConvert.SerializeObject(discoveryInfo),
                                                    System.Text.Encoding.UTF8, "application/json");
                    var response = await _apiClient.PostAsync(uri, transferContent);
                    response.EnsureSuccessStatusCode();
                }

                for (int i = 0; i < transferDto.noOfBothScanReq; i++)
                {
                    var discoveryInfo = new DiscoveryInfo() { Id = Guid.NewGuid().ToString(), ScanType = "Both" };

                    var transferContent = new StringContent(JsonConvert.SerializeObject(discoveryInfo),
                                                    System.Text.Encoding.UTF8, "application/json");
                    var response = await _apiClient.PostAsync(uri, transferContent);
                    response.EnsureSuccessStatusCode();
                }


            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
