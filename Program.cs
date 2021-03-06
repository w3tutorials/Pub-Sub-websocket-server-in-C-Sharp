﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
using System.Reflection;
using SuperWebSocket.PubSubProtocol;
 

namespace SuperWebSocket.Samples.SubProtocol
{
    class Program
    {
        static void Main(string[] args)
        {       

            //use BasicSubProtocol with current assembly as command assembly
            var appServer = new PubSubWebSocketServer();


            var  topics = System.Configuration.ConfigurationManager.AppSettings["WebSocketServerTopics"].Split(',').ToList();
            appServer.SetSupportedTopics(topics);


            //Setup the appServer
            if (!appServer.Setup(2012)) //Setup with listening port
            {
                Console.WriteLine("Failed to setup!");
                Console.ReadKey();
                return;
            }
 

           
            Console.WriteLine();

            //Try to start the appServer
            if (!appServer.Start())
            {
                Console.WriteLine("Failed to start!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("The server started successfully, press key 'q' to stop it!");

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }

            //Stop the appServer
            appServer.Stop();

            Console.WriteLine();
            Console.WriteLine("The server was stopped!");
            Console.ReadKey();
        }
 
    }
}
