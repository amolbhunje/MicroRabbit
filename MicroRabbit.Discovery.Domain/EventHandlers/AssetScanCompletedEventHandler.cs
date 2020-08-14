using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Discovery.Domain.Events;
using MicroRabbit.Discovery.Domain.Interfaces;
using MicroRabbit.Discovery.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MicroRabbit.Discovery.Domain.Commands;
using Microsoft.Extensions.Logging;
using Amazon;
using Amazon.SecurityToken;
using Amazon.SecurityToken.Model;
using Amazon.EC2;
using Amazon.Runtime;

namespace MicroRabbit.Discovery.Domain.EventHandlers
{
    public class AssetScanCompletedEventHandler : IEventHandler<AssetScanCompletedEvent>
    {
        private readonly ILogger<AssetScanCompletedEventHandler> _logger;
        private readonly IEventBus _bus;

        public AssetScanCompletedEventHandler(IEventBus bus, ILogger<AssetScanCompletedEventHandler> logger) 
        {
            _logger = logger;
            _bus = bus;
        }

        public Task Handle(AssetScanCompletedEvent @event)
        {
            //Logic for Asset scan completed event
            _logger.LogInformation("Asset scan completed for Scan ID {0}", @event.ScanID);

            EC2Instance(@event).Wait();

            if (@event.ScanType == "Both")
            {
                _logger.LogInformation("Starting account scan for Scan ID {0}", @event.ScanID);

                _bus.Publish(new StartAccountScanEvent(@event.ScanID, @event.ScanType, @event.Payload));

            }

            return Task.CompletedTask;
        }

        private async Task EC2Instance(AssetScanCompletedEvent request)
        {
            IAmazonSecurityTokenService STSClient = new AmazonSecurityTokenServiceClient("AKIAXMJHA33LOQPJKCXO", "t1EvatLh4zIl7cBNyGR8rEE2k1vgKOiiDu6wg8IT", RegionEndpoint.USEast2);
            using (var client = STSClient)
            {
                GetSessionTokenRequest getSessionTokenRequest = new GetSessionTokenRequest() { DurationSeconds = 900 };
                GetSessionTokenResponse tokenResponse = await client.GetSessionTokenAsync(getSessionTokenRequest);
                //Console.WriteLine("SecretAccessKey: "+tokenResponse.Credentials.SecretAccessKey+" \n  AccessKeyId: "+tokenResponse.Credentials.AccessKeyId+"\n SessionToken: "+tokenResponse.Credentials.SessionToken+" \n Expiration: "+tokenResponse.Credentials.Expiration);

                var response = STSClient.AssumeRoleAsync(new AssumeRoleRequest
                {
                    RoleArn = "arn:aws:iam::507424857814:role/DemoEC2",
                    RoleSessionName = "EC2User",
                    DurationSeconds = 900

                });

                var tempCredentials = new SessionAWSCredentials
                (
                    response.Result.Credentials.AccessKeyId,
                    response.Result.Credentials.SecretAccessKey,
                    response.Result.Credentials.SessionToken
                );
                // var test= new BasicAWSCredentials("AKIAXMJHA33LOQPJKCXO","t1EvatLh4zIl7cBNyGR8rEE2k1vgKOiiDu6wg8IT");
                //Console.WriteLine("SecretAccessKey: " + response.Result.Credentials.SecretAccessKey + " \n AccessKey: " + response.Result.Credentials.AccessKeyId + " \n SessionToken: " + response.Result.Credentials.SessionToken + " \n Expiration: " + response.Result.Credentials.Expiration);
                //await Task.Delay(900500);
                //Console.WriteLine("Afetr 15 minute .......");

                IAmazonEC2 ec2 = new AmazonEC2Client(tempCredentials, Amazon.RegionEndpoint.USEast2);
                //Amazon.Util.EC2InstanceMetadata.Hostname;

               // list of Instance
               var result = await ec2.DescribeInstancesAsync();

                // Console.WriteLine("\n List of Instance");
                foreach (var reservation in result.Reservations)
                {
                    foreach (var instance in reservation.Instances)
                    {
                        _logger.LogInformation("EC2 for instance ID {0} {1} {2}",request.ScanID, instance.InstanceId,instance.InstanceType);
                        //Console.WriteLine(instance.InstanceId);
                    }

                }
                //Console.WriteLine("\n Get by InstanceID");
                //var response2 = ec2.DescribeInstancesAsync(new DescribeInstancesRequest
                //{
                //    InstanceIds = new List<string>
                //    {
                //        "i-0e76148b03298009a"
                //    }
                //});

                //Console.WriteLine(response2.Result.HttpStatusCode);

            }
        }
    }
}
