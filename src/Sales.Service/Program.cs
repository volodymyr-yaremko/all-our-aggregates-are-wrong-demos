﻿using NServiceBus;
using System;
using System.Threading.Tasks;

namespace Sales.Service
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var serviceName = typeof(Program).Namespace;
            var config = new EndpointConfiguration(serviceName);
            config.ApplyCommonConfiguration();

            var endpointInstance = await Endpoint.Start(config);

            Console.WriteLine($"{serviceName} sarted. Press any key to stop.");
            Console.ReadLine();

            await endpointInstance.Stop();
        }
    }
}
