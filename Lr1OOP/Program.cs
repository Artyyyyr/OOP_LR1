namespace Lr1
{
    class Program
    {
        public class GameRecord
        {
            public int index;
            public int WL;
            public string opponent;
            public int rate;
            public GameRecord(int index, int wl, string opponent, int rate)
            {
                this.index = index;
                this.WL = wl;
                this.opponent = opponent;
                this.rate = rate;
            }
            
        }

        public class GoodWinerAccount : GameAccount
        {
            public GoodWinerAccount(string UserName, int CurretRating) : base(UserName, CurretRating)
            {
                base.UserName = this.UserName;
                base.CurrentRating = this.CurrentRating;
            }

            public override void WinGame(string opponentname, int Rating, int index)
            {
                if (Rating > 0)
                {
                    CurrentRating = CurrentRating + 2 * Rating;
                    GameRecord a = new GameRecord(index, 1, opponentname, 2 * Rating);
                    record.Add(a);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
        public class GoodLooserAccount : GameAccount
        {
            public GoodLooserAccount(string UserName, int CurretRating) : base(UserName, CurretRating)
            {
                base.UserName = this.UserName;
                base.CurrentRating = this.CurrentRating;
            }

            public override void LoseGame(string opponentname, int Rating, int index)
            {
                if (Rating > 0 & CurrentRating - Rating > 0)
                {
                    CurrentRating = CurrentRating - Rating/2;
                    GameRecord a = new GameRecord(index, 0, opponentname, Rating/2);
                    record.Add(a);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
        public class TrainAccount : GameAccount
        {
            public TrainAccount(string UserName, int CurretRating) : base(UserName, CurretRating)
            {
                base.UserName = this.UserName;
                base.CurrentRating = this.CurrentRating;
            }
            public override void LoseGame(string opponentname, int Rating, int index)
            {
                if (Rating > 0 & CurrentRating - Rating > 0)
                {
                    CurrentRating = CurrentRating - 0;
                    GameRecord a = new GameRecord(index, 0, opponentname, 0);
                    record.Add(a);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            public override void WinGame(string opponentname, int Rating, int index)
            {
                if (Rating > 0)
                {
                    CurrentRating = CurrentRating + 0;
                    GameRecord a = new GameRecord(index, 1, opponentname, 0);
                    record.Add(a);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
        public class PremiumAccount : GameAccount
        {
            public PremiumAccount(string UserName, int CurretRating) : base(UserName, CurretRating)
            {
                base.UserName = this.UserName;
                base.CurrentRating = this.CurrentRating;
            }
            public override void WinGame(string opponentname, int Rating, int index)
            {
                if (Rating > 0)
                {
                    CurrentRating = CurrentRating + 2 * Rating;
                    GameRecord a = new GameRecord(index, 1, opponentname, 2 * Rating);
                    record.Add(a);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            public override void LoseGame(string opponentname, int Rating, int index)
            {
                if (Rating > 0 & CurrentRating - Rating > 0)
                {
                    CurrentRating = CurrentRating - Rating/2;
                    GameRecord a = new GameRecord(index, 0, opponentname, Rating/2);
                    record.Add(a);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
        public class GameAccount
        {
            protected string UserName = "No name";
            protected int CurrentRating = 1;
            private int GamesCount = 0;

            protected List<GameRecord> record = new List<GameRecord>();

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

            public GameAccount(string UserName, int CurretRating)
            {
                this.UserName = UserName;
                this.CurrentRating = CurretRating;
            }

            public virtual void WinGame(string opponentname, int Rating, int index)
            {
                if (Rating > 0)
                {
                    CurrentRating = CurrentRating + Rating;
                    GameRecord a = new GameRecord(index, 1, opponentname, Rating);
                    record.Add(a);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
            public virtual void LoseGame(string opponentname, int Rating, int index)
            {
                if (Rating > 0 & CurrentRating - Rating > 0)
                {
                    CurrentRating = CurrentRating - Rating;
                    GameRecord a = new GameRecord(index, 0, opponentname, Rating);
                    record.Add(a);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }

            public void GetStats()
            {
                for (int i = 0; i < record.Count; i++)
                {
                    if (record[i].WL == 0)
                    {
                        Console.WriteLine("Game {0} lose {1} -{2} points", record[i].index, record[i].opponent, record[i].rate);
                    }
                    else
                    {
                        Console.WriteLine("Game {0} win {1} +{2} points", record[i].index, record[i].opponent, record[i].rate);
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

            public void game(GameAccount winner, GameAccount loser, int Rate)
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
            GoodLooserAccount Vasya = new GoodLooserAccount("Vasiliy", 100);
            GoodWinerAccount Lera = new GoodWinerAccount("Lera", 100);
            TrainAccount Artyyr = new TrainAccount("Artyyr", 100);
            PremiumAccount Bodia = new PremiumAccount("Bogdan", 1000);
            
            Game game = new Game();

            Console.WriteLine("Start");
            Console.WriteLine("Lera: {0}", Lera.GetCurrentRating());
            Console.WriteLine("Vasay: {0}", Vasya.GetCurrentRating());
            Console.WriteLine("Artyyr: {0}", Artyyr.GetCurrentRating());
            Console.WriteLine("Bodia: {0}", Bodia.GetCurrentRating());
            
            game.game(Lera, Artyyr, 10);
            game.GetStats();
            Console.WriteLine("Lera: {0}", Lera.GetCurrentRating());
            Console.WriteLine("Vasay: {0}", Vasya.GetCurrentRating());
            Console.WriteLine("Artyyr: {0}", Artyyr.GetCurrentRating());
            Console.WriteLine("Bodia: {0}", Bodia.GetCurrentRating());

            game.game(Lera, Vasya, 20);
            game.GetStats();
            Console.WriteLine("Lera: {0}", Lera.GetCurrentRating());
            Console.WriteLine("Vasay: {0}", Vasya.GetCurrentRating());
            Console.WriteLine("Artyyr: {0}", Artyyr.GetCurrentRating());
            Console.WriteLine("Bodia: {0}", Bodia.GetCurrentRating());
            
            game.game(Artyyr, Vasya, 10);
            game.GetStats();
            Console.WriteLine("Lera: {0}", Lera.GetCurrentRating());
            Console.WriteLine("Vasay: {0}", Vasya.GetCurrentRating());
            Console.WriteLine("Artyyr: {0}", Artyyr.GetCurrentRating());
            Console.WriteLine("Bodia: {0}", Bodia.GetCurrentRating());
            
            game.game(Vasya, Lera, 5);
            game.GetStats();
            Console.WriteLine("Lera: {0}", Lera.GetCurrentRating());
            Console.WriteLine("Vasay: {0}", Vasya.GetCurrentRating());
            Console.WriteLine("Artyyr: {0}", Artyyr.GetCurrentRating());
            Console.WriteLine("Bodia: {0}", Bodia.GetCurrentRating());
            
            game.game(Artyyr, Lera, 10);
            game.GetStats();
            Console.WriteLine("Lera: {0}", Lera.GetCurrentRating());
            Console.WriteLine("Vasay: {0}", Vasya.GetCurrentRating());
            Console.WriteLine("Artyyr: {0}", Artyyr.GetCurrentRating());
            Console.WriteLine("Bodia: {0}", Bodia.GetCurrentRating());
            
            game.game(Vasya, Lera, 5);
            game.GetStats();
            Console.WriteLine("Lera: {0}", Lera.GetCurrentRating());
            Console.WriteLine("Vasay: {0}", Vasya.GetCurrentRating());
            Console.WriteLine("Artyyr: {0}", Artyyr.GetCurrentRating());
            Console.WriteLine("Bodia: {0}", Bodia.GetCurrentRating());
            
            game.game(Lera, Vasya, 85);
            game.GetStats();
            Console.WriteLine("Lera: {0}", Lera.GetCurrentRating());
            Console.WriteLine("Vasay: {0}", Vasya.GetCurrentRating());
            Console.WriteLine("Artyyr: {0}", Artyyr.GetCurrentRating());
            Console.WriteLine("Bodia: {0}", Bodia.GetCurrentRating());
            
            game.game(Artyyr, Lera, 10);
            game.GetStats();
            Console.WriteLine("Lera: {0}", Lera.GetCurrentRating());
            Console.WriteLine("Vasay: {0}", Vasya.GetCurrentRating());
            Console.WriteLine("Artyyr: {0}", Artyyr.GetCurrentRating());
            Console.WriteLine("Bodia: {0}", Bodia.GetCurrentRating());
            
            game.game(Bodia, Lera, 10);
            game.GetStats();
            Console.WriteLine("Lera: {0}", Lera.GetCurrentRating());
            Console.WriteLine("Vasay: {0}", Vasya.GetCurrentRating());
            Console.WriteLine("Artyyr: {0}", Artyyr.GetCurrentRating());
            Console.WriteLine("Bodia: {0}", Bodia.GetCurrentRating());
            
            game.game(Bodia, Artyyr, 10);
            game.GetStats();
            Console.WriteLine("Lera: {0}", Lera.GetCurrentRating());
            Console.WriteLine("Vasay: {0}", Vasya.GetCurrentRating());
            Console.WriteLine("Artyyr: {0}", Artyyr.GetCurrentRating());
            Console.WriteLine("Bodia: {0}", Bodia.GetCurrentRating());
            
            game.game(Bodia, Vasya, 10);
            game.GetStats();
            Console.WriteLine("Lera: {0}", Lera.GetCurrentRating());
            Console.WriteLine("Vasay: {0}", Vasya.GetCurrentRating());
            Console.WriteLine("Artyyr: {0}", Artyyr.GetCurrentRating());
            Console.WriteLine("Bodia: {0}", Bodia.GetCurrentRating());
            
            game.game(Artyyr, Bodia, 100);
            game.GetStats();
            Console.WriteLine("Lera: {0}", Lera.GetCurrentRating());
            Console.WriteLine("Vasay: {0}", Vasya.GetCurrentRating());
            Console.WriteLine("Artyyr: {0}", Artyyr.GetCurrentRating());
            Console.WriteLine("Bodia: {0}", Bodia.GetCurrentRating());
            
            Console.WriteLine("Vasya");
            Vasya.GetStats();
            Console.WriteLine("Lera");
            Lera.GetStats();
            Console.WriteLine("Artyyr");
            Artyyr.GetStats();
            Console.WriteLine("Bodia");
            Bodia.GetStats();
        }
    }
}
