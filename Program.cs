using System.Net;

using System.Net.Sockets;

using System.Text;

using System.Threading.Tasks;

namespace ClientApp

{

    internal class Program

    {

        static async Task Main(string[] args)

        {

            Console.Title = "Client App";

            var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            var ipAddress = IPAddress.Parse("--.--.--.--");

            var port = 27001;

            var ep = new IPEndPoint(ipAddress, port);

            Console.WriteLine("Enter name : ");

            string name = Console.ReadLine();

            try

            {

                await socket.ConnectAsync(ep);

                if (socket.Connected)

                {

                    Console.WriteLine("Connected successfully");

                    var bytes = Encoding.UTF8.GetBytes(name);

                    await socket.SendAsync(bytes);

                    while (true)

                    {

                        var message = Console.ReadLine();

                        bytes = Encoding.UTF8.GetBytes(message);

                        await socket.SendAsync(bytes);

                    }

                }

            }

            catch (Exception ex)

            {

                Console.WriteLine(ex.Message);

            }

        }

    }

}

