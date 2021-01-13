using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_3
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckButton q = new CheckButton("Q", new Point(12, 34), 12, 12,CheckStates.Checked);
            CheckButton w = new CheckButton("W", new Point(12, 12), 22, 12, CheckStates.Unchecked);
            CheckButton e = new CheckButton("E", new Point(22, 33), 12, 12, CheckStates.Checked);
            CheckButton r = new CheckButton("R", new Point(132, 34), 32, 12, CheckStates.Unchecked);
            CheckButton t = new CheckButton("T", new Point(13, 56), 11, 11, CheckStates.Checked);
            CheckButton y = new CheckButton("Y", new Point(112, 134), 12, 12, CheckStates.Checked);

            User user1 = new User();
            user1.Click += () => q.Check();
            user1.Click += () => w.Check();
            user1.Click += () => y.Check();
            user1.Resize += (n) => e.Zoom(n);
            user1.Resize += (n) => t.Zoom(n);

            user1.Start(50);

            LinkedList<Button> buttonBoard = new LinkedList<Button>();
            buttonBoard.AddLast(q);
            buttonBoard.AddLast(w);
            buttonBoard.AddLast(e);
            buttonBoard.AddLast(r);
            buttonBoard.AddLast(new Button("X", new Point(12, 134), 12, 12));
            buttonBoard.AddLast(new Button("Y", new Point(112, 34), 22, 22));

            var result = from c in buttonBoard where c.Width * c.Hight == 144 select c;
            foreach(var c in result)
            {
                Console.WriteLine(c);
            }

            var query = buttonBoard.Where(b => b is CheckButton).Count();
            Console.WriteLine($"CheckButton count:{query}");

            Console.ReadKey();
        }
    }
}
