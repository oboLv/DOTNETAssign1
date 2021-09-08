using System;
using System.IO;

namespace TicketingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = "tickets.csv";
            var exit = false;
            while (!exit)
            {
                Console.WriteLine("1. Read data from file");
                System.Console.WriteLine("2. Create file from data");
                System.Console.WriteLine("3. Exit application");
                
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    var format = "{0, -10} {1, -30} {2, -10} {3, -10} {4, -25} {5, -25} {6}";
                    Console.Clear();
                    var sr = new StreamReader(file);
                    while (!sr.EndOfStream)
                    {
                        var raw = sr.ReadLine();
                        var split = raw.Split(",");
                        System.Console.WriteLine(format, split[0], split[1], split[2], split[3], split[4], split[5], split[6].Replace("|", " | "));
                    }
                    sr.Close();
                    Console.ReadKey();
                }
                else if (choice == "2")
                {
                    var ticketID = 0;
                    StreamReader sr = new StreamReader(file);
                    while (!sr.EndOfStream)//get next TicketID number
                    {
                        string toArray = sr.ReadLine();
                        if (sr.EndOfStream)
                        {
                            string[] stringArray = toArray.Split(',');
                            int tickID = Convert.ToInt32(stringArray[0]);
                            ticketID = tickID + 1;
                        }
                    }
                    sr.Close();
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
                    System.Console.WriteLine("Enter who is watching");
                    string p6 = Console.ReadLine();
                    var moreWatching = false;
                    while (!moreWatching)
                    {
                        System.Console.WriteLine("Add more watchers? (Y/N)");
                        var ans = Console.ReadLine();
                        if (ans.ToUpper() == "Y")
                        {
                            System.Console.WriteLine("Enter additional watcher");
                            var newWatcher = Console.ReadLine();
                            p6 += $"|{newWatcher}";
                        }
                        else if (ans.ToUpper() == "N")
                        {
                            moreWatching = true;
                        }
                        else
                        {
                            System.Console.WriteLine("Try again");
                        }
                    }
                    string ticketCSV = "{0},{1},{2},{3},{4},{5},{6}";
                    System.Console.WriteLine("Ticket added");
                    System.Console.ReadLine();
                    StreamWriter sw = new StreamWriter(file, true);
                    sw.WriteLine(ticketCSV, ticketID, p1, p2, p3, p4, p5, p6);
                    sw.Close();
                }
                else if (choice == "3")
                {
                    exit = true;
                }
                else
                {
                    System.Console.WriteLine("Try again");
                }
            }
        }
    }
}
