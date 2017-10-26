using Renci.SshNet;
using System;

namespace InstrumentalCommandPrompt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter IP:");
            string ip = Console.ReadLine();

            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            using (var client = new SshClient(ip, username, password))
            {
                client.Connect();

                while (true)
                {
                    var input = Console.ReadLine();
                    if (input.Contains("exit instrumental command prompt"))
                        break;

                    Console.WriteLine(client.RunCommand(input).Result);
                }
            }
        }
    }
}
