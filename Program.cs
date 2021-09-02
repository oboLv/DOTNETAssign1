using System;
using System.IO;

namespace TicketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = "tickets.csv";
            Console.WriteLine("1. Read data from file");
            System.Console.WriteLine("2. Create file from data");
            
            var choice = Console.ReadLine();

            if(choice == "1")
            {
                Console.Clear();
                var sr = new StreamReader("tickets.csv");
                sr.ReadLine();
                while(!sr.EndOfStream)
                {
                    var raw = sr.ReadLine();
                    var split = raw.Split(",");
                    System.Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}, {6}", split[0], split[1], split[2], split[3], split[4], split[5], split[6].Replace("|", " | "));
                }
                sr.Close();
            }
            else if(choice == "2")
            {
                int ticketID;
                    StreamReader reader = new StreamReader(file);
                    while (!reader.EndOfStream)//get next TicketID number
                    {
                        string toArray = reader.ReadLine();
                        if (reader.EndOfStream)
                            {
                                string[] stringArray = toArray.Split(',');
                                int tickID = Convert.ToInt32(stringArray[0]);
                                ticketID = tickID + 1;
                            }
                    }
                    reader.Close();
                    System.Console.WriteLine("Enter the ticket summary");
                    string p1 = Console.ReadLine();
                    System.Console.WriteLine("Enter the ticket status");
                    string p2 = Console.ReadLine();
                    System.Console.WriteLine("Enter the ticket priority");
                    string p3 = Console.ReadLine();
                    System.Console.WriteLine("Enter the ticket submitter");
                    string p4 = Console.ReadLine();
                    System.Console.WriteLine("Enter who is assigned to this ticket");
                    string p5 = Console.ReadLine();
                    string p6 = $"{p4}|{p5}|Bill Jones";
                    string ticketCSV = "{0},{1},{2},{3},{4},{5},{6}";
                    System.Console.WriteLine("Ticket added");
                    System.Console.ReadLine();
                    StreamWriter writer = new StreamWriter(file, true);
                    writer.WriteLine(ticketCSV, p1, p2, p3, p4, p5, p6);
                    writer.Close();
            }
            else
            {

            }
        }
    }
}
