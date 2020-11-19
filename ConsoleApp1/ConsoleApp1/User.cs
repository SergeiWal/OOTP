using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class User
    {
        private string name;
        private string location;
        private int memory;

        public delegate void SershHostForUser(string str);
        public delegate void CompressionMemory(int value);

        public event SershHostForUser Move;
        public event CompressionMemory Compr;


        public User(string nm, string loc, int memr)
        {
            name = nm;
            memory = memr;
            location = loc;
        }

        public void MoveUser(string finishLocation)
        {
            location = finishLocation;
        }

        public void Compression(int newSize)
        {
            memory = newSize;
        }

        public void Search(int searchMemory, string newHost)
        {
            if(memory > searchMemory)
            {
                Move?.Invoke(newHost);
                Compr?.Invoke(searchMemory - 10);
            }
        }
    }
}
