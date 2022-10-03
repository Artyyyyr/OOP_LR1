namespace Lr1
{
    class Program
    {
        public class Gameacount
        {
            private string UserName = "No name";
            private int CurrentRating = 1;
            private int GamesCount = 0;
            private List<int> index = new List<int>();
            private List<int> WL = new List<int>();
            private List<string> opponent = new List<string>();
            private List<int> rate = new List<int>();

            public string GetUserName()
            {
                return UserName;
            }

            public int GetCurrentRating()
            {
                return CurrentRating;
            }

            public int GetGamesCount()
            {
                return GamesCount;
            }

            public void SetGamesCount(int GamesCount)
            {
                this.GamesCount = GamesCount;
            }

            public Gameacount(string UserName, int CurretRating)
            {
                this.UserName = UserName;
                this.CurrentRating = CurretRating;
            }

            public void WinGame(string opponentname, int Rating, int index)
            {
                if (Rating > 0)
                {
                    CurrentRating = CurrentRating + Rating;
                    this.index.Add(index);
                    WL.Add(1);
                    opponent.Add(opponentname);
                    rate.Add(Rating);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            public void LoseGame(string opponentname, int Rating, int index)
            {
                if (Rating > 0 & CurrentRating - Rating > 0)
                {
                    CurrentRating = CurrentRating - Rating;
                    this.index.Add(index);
                    WL.Add(0);
                    opponent.Add(opponentname);
                    rate.Add(Rating);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }

            public void GetStats()
            {
                for (int i = 0; i < index.Count; i++)
                {
                    if (WL[i] == 0)
                    {
                        Console.WriteLine("Game {0} lose {1} -{2} points", index[i], opponent[i], rate[i]);
                    }
                    else
                    {
                        Console.WriteLine("Game {0} win {1} +{2} points", index[i], opponent[i], rate[i]);
                    }
                    
                }
                
            }
        }

        public class Game
        {
            private int gamecount = 0;
            private List<int> index = new List<int>();
            private List<string> W = new List<string>();
            private List<string> L = new List<string>();
            private List<int> rate = new List<int>();

            public void game(Gameacount winner, Gameacount loser, int Rate)
            {
                if (Rate > 0 & loser.GetCurrentRating() - Rate > 0)
                {
                    winner.WinGame(loser.GetUserName(), Rate, gamecount);
                    loser.LoseGame(winner.GetUserName(), Rate, gamecount);
                    index.Add(gamecount);
                    W.Add(winner.GetUserName());
                    L.Add(loser.GetUserName());
                    rate.Add(Rate);
                    winner.SetGamesCount(winner.GetGamesCount() + 1);
                    loser.SetGamesCount(loser.GetGamesCount() + 1);
                    gamecount = gamecount + 1;
                }
                else
                {
                    Console.WriteLine("Error");
                }

            }

            public void GetStats()
            {
                for (int i = 0; i < index.Count; i++)
                {
                    Console.WriteLine("Game {0}. Lose: {1}, win: {2}, rate: {3}points", index[i], L[i], W[i], rate[i]);
                }
            }
        }

        static void Main(string[] args)
        {
            Gameacount Vasya = new Gameacount("Vasiliy", 100);
            Gameacount Lera = new Gameacount("Lera", 100);
            Game game = new Game();

            Console.WriteLine("Start");
            Console.WriteLine("Lera: {0}", Lera.GetCurrentRating());
            Console.WriteLine("Vasay: {0}", Vasya.GetCurrentRating());

            game.game(Lera, Vasya, 20);
            game.GetStats();
            Console.WriteLine("Lera: {0}", Lera.GetCurrentRating());
            Console.WriteLine("Vasay: {0}", Vasya.GetCurrentRating());
            
            game.game(Vasya, Lera, 5);
            game.GetStats();
            Console.WriteLine("Lera: {0}", Lera.GetCurrentRating());
            Console.WriteLine("Vasay: {0}", Vasya.GetCurrentRating());
            
            game.game(Vasya, Lera, 5);
            game.GetStats();
            Console.WriteLine("Lera: {0}", Lera.GetCurrentRating());
            Console.WriteLine("Vasay: {0}", Vasya.GetCurrentRating());
            
            game.game(Lera, Vasya, 85);
            game.GetStats();
            Console.WriteLine("Lera: {0}", Lera.GetCurrentRating());
            Console.WriteLine("Vasay: {0}", Vasya.GetCurrentRating());
            
            Console.WriteLine("Vasya");
            Vasya.GetStats();
            Console.WriteLine("Lera");
            Lera.GetStats();
        }
    }
}
