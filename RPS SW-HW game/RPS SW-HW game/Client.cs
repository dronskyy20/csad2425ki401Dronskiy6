using System;
using System.IO.Ports;


class Program
{
    static void Main()
    {
        SerialPort port = new SerialPort("COM3", 9600); 
        port.Open();

        while (true)
        {
            Console.WriteLine("Enter your move (r: ROCK, p: PAPER, s: SCISSORS): ");
            char clientMove = Console.ReadKey().KeyChar;
            Console.WriteLine();
            port.Write(new char[] { clientMove }, 0, 1);
            string response = port.ReadLine();
            Console.WriteLine($"Server response: {response}");
            if (clientMove == 'q')
                break;
        }

        port.Close();
    }
}
