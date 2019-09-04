using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SimpleMathClient
{
    public class Worker
    {
        public void Start()
        {

            while (true)
            {
                using (TcpClient clientSocket = new TcpClient("localhost", 3000))
                using (StreamReader reader = new StreamReader(clientSocket.GetStream()))
                using (StreamWriter writer = new StreamWriter(clientSocket.GetStream()))
                {
                    while (true)
                    {
                        string str = Console.ReadLine();
                        writer.WriteLine(str);

                        writer.Flush();

                        string stringReader = reader.ReadLine();
                        Console.WriteLine(stringReader);





                        writer.Close();
                        reader.Close();
                    }
                    
                    
                    


                }
            }
        }

        public static int countLetters(string word)
        {
            return word.Length;

        }
    }
}
