namespace Lab2ServSide
{
    internal class Program
    {
        private static List<VideoGame> games = new List<VideoGame>();
        static void Main(string[] args)
        {
            StreamReader sr = new(@"C:\Users\gqfri\source\repos\Lab2ServSide\Lab2ServSide\videogames.csv");
            string header = sr.ReadLine();
            Dictionary<string, List<VideoGame>> PlatformSort = new();
            HashSet<string> uniquePlatform = new HashSet<string>();
            string NullCheck;
            while ((NullCheck = sr.ReadLine()) != null)
            {
                games.Add(ProcessCSVLine(NullCheck));
            }
            foreach (VideoGame game in games)
            {
                if (uniquePlatform.Contains(game.Platform))
                {}
                else
                {
                    uniquePlatform.Add(game.Platform);
                }
            }
            //Dictionary<string, dynamic> makeTables = new();
            foreach (string publisher in uniquePlatform)
            {
                List<VideoGame> newList = new List<VideoGame>();
                foreach (VideoGame game in games)
                {
                    if(game.Publisher.Equals(publisher))
                    {
                        newList.Add(game);
                    }
                    PlatformSort[publisher] = newList;
                }
            }
            foreach (VideoGame game in games)
            {
                PlatformSort[game.Platform].Add(game);
            }
            string userChoice;
            do
            {
                Console.WriteLine("(Stop 6.) Input the publisher you would like to search (Case Sensistive): ");
                userChoice = Console.ReadLine();
                if (PlatformSort.ContainsKey(userChoice))
                {
                    var top5Games = PlatformSort[userChoice].OrderByDescending(VideoGame => VideoGame.GlobalSales).Take(5);
                    //Console.WriteLine("Test1");
                    //Console.WriteLine(PlatformSort["DS"].Count());
                    foreach (var game in top5Games)
                    {
                        //Console.WriteLine("Test3");
                        Console.WriteLine(game.ToString());
                    }
                }
            } while (userChoice != "6");

        }

        static VideoGame ProcessCSVLine(string LineFromCSV)
        {
            string[] rawGameParts = LineFromCSV.Split(",");
            List<string> cleanGameParts = new List<string>();
            string cleanString = string.Empty;
            for (int i = 0; i < rawGameParts.Length; i++)
            {
                cleanString += rawGameParts[i];
                // more data processing / Cleaning?
                cleanGameParts.Add(cleanString);
                cleanString = "";
            }
            string Name = cleanGameParts[0];
            string Platform = cleanGameParts[1];
            string preparse1 = cleanGameParts[2];
            int Year = Int32.Parse(preparse1);
            string Genre = cleanGameParts[3];
            string publisher = cleanGameParts[4];
            string preParse2 = cleanGameParts[5];
            double NASales = double.Parse(preParse2);
            string preParse3 = cleanGameParts[6];
            double EUSales = double.Parse(preParse3);
            string preParse4 = cleanGameParts[7];
            double JPSales = double.Parse(preParse4);
            string preParse5 = cleanGameParts[8];
            double OtherSales = double.Parse(preParse5);
            string preparse6 = cleanGameParts[9];
            double GlobalSales = double.Parse(preparse6);
            VideoGame cleanGame = new VideoGame(Name, Platform, Year, Genre, publisher, NASales, EUSales, JPSales, OtherSales, GlobalSales);
            return cleanGame;
        }
    }
}