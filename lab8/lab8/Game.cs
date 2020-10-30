using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    abstract class Game : Soft, Operations
    {
        private bool offlineGame;
        private bool onlineGame;
        private string genre;
        private string directVersion;

        public Game(bool off, bool online, string gnr, string direct, int mem, int rm, int vMem, string nm, softType tp = softType.GAME, string devName = "Sergei Walko", int expr = 100,
            string lg = "WSA-2020", RangType rng = RangType.SENIOR):base(mem, rm, vMem, tp, nm, devName, expr, lg, rng)
        {
            offlineGame = off;
            onlineGame = online;
            genre = gnr;
            directVersion = direct;
        }

        virtual public bool Start()
        {
            Console.WriteLine("Start work game application!");
            this.status = true;
            return true;
        }

        virtual public string CurrentStatus()
        {
            if (this.status) return "Game working!";
            else return "Game off";
        }
        virtual public void Exit()
        {
            Console.WriteLine("Game application finished his work!");
            this.status = false;
        }


        public void Menu()
        {
            Console.WriteLine("You be in game menu!");
        }

        public void GameLoop()
        {
            Console.WriteLine("Goes game loop!");
        }

        bool IsOfflineGame
        {
            get
            {
                return offlineGame;
            }
            set
            {
                offlineGame = value;
            }
        }

        bool IsOnlineGame
        {
            get
            {
                return onlineGame;
            }
            set
            {
                onlineGame = value;
            }
        }

        string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
            }
        }

        string DirectVersion
        {
            get
            {
                return directVersion;
            }
            set
            {
                directVersion = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Type: Game\n Offline:{offlineGame}\n Online:{onlineGame}\nGenre:{genre}\n";
        }

    }
}
