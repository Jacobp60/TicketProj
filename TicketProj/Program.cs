using System.IO;

namespace TicketProj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int ticketID = 0;
            string status = "Open"; 
            string file = "courseData.txt";
            string choice;
            string nameString = "";
            string prior = "High";
            
            do
            {
                // ask user a question
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    // read data from file
                    if (File.Exists(file))
                    {
                        // read data from file
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
          
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                          
                        }
                        sr.Close();
                    }
                    else
                    {
                        Console.WriteLine("File does not exist");
                    }
                }
                else if (choice == "2")
                {
                    // create file from data
                    StreamWriter sw = new StreamWriter(file);
                    sw.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
                        // ask a question
                        Console.WriteLine("What Movie would you like to watch?");
                        // input the response
                        string movieTitle = Console.ReadLine().ToUpper();                      
                        Console.WriteLine("Who is buying the ticket(s)?");
                        string buyerName = Console.ReadLine();
                        // number of watchers
                        Console.WriteLine("How many will be watching the movie?");
                        string Watchers = Console.ReadLine();
                        
                        int numOfWatchers = Convert.ToInt32(Watchers);

                        for(int j = 0; j < numOfWatchers; j++)
                        {
                            Console.WriteLine("Enter name of guest: ");
                            string userInName = Console.ReadLine();
                            
                            nameString = nameString  + "|" +userInName;
                        }
                        sw.WriteLine("{0},{1},{2},{3},{4},{5}", ticketID, movieTitle,status,prior,buyerName,nameString);

                    
                    sw.Close();
                }
            } while (choice == "1" || choice == "2");

        }

    }
}