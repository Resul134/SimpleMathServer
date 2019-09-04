using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMathServer
{
    public class Worker
    {



        public void Start()
        {

            IPAddress IP = IPAddress.Loopback;
            TcpListener server = new TcpListener(IP, 3000);

            
                server.Start();
                Console.WriteLine("Server is succesfully started...We're listening");
                
            
            


            while (true)
            {

                TcpClient socket = server.AcceptTcpClient();
                //Starter ny tråd
                Task.Run(() =>
                { //indsætter en metode (delegate)
                    TcpClient tempSocket = socket;
                    DoClientMath(tempSocket);

                });

            }






        }

        public void DoClientMath(TcpClient tempsocket)
        {

            //  Culture info cult = new culturefure info("da-da)),
               // double result;
            // result = double.parse(strsplit[1], cult) 

            using (StreamReader reader = new StreamReader(tempsocket.GetStream()))
            using (StreamWriter writer = new StreamWriter(tempsocket.GetStream()))
            {


                while (true)
                {
                    string str = reader.ReadLine();

                    string[] arr = str.Split(' ');
                    if (arr[0].Contains("add"))
                    {
                        int result = int.Parse(arr[1]) + int.Parse(arr[2]);
                        writer.WriteLine(" = "+ result );
                        Console.WriteLine(result);
                        writer.Flush();


                    }
                    else if (arr[0].Contains("divide"))
                    {
                        int result = int.Parse(arr[1]) / int.Parse(arr[2]);
                        writer.WriteLine(" = " + result);
                        Console.WriteLine(result);
                        writer.Flush();
                    }
                    else if(arr[0].Contains("minus"))
                    {
                        int result = int.Parse(arr[1]) - int.Parse(arr[2]);
                        writer.WriteLine(" = " + result);
                        Console.WriteLine(result);
                        writer.Flush();
                    }
                    else if (arr[0].Contains("mult"))
                    {
                        int result = int.Parse(arr[1]) * int.Parse(arr[2]);
                        writer.WriteLine(" = " + result);
                        Console.WriteLine(result);
                        writer.Flush();
                    }
                    tempsocket.Close();
                    


                }
                
                





            }

        }

        public int Addition(int a, int x)
        {
            return a + x;
        }
    }
}
