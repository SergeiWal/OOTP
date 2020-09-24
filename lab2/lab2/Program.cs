using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {

            Vector vc1 = new Vector(1, 2, 3, 4, 5, 3, 3);
            Vector vc2 = new Vector(5);
            Vector vc3 = new Vector(1, 0, 2, 2, 0, 10);

            vc2[0] = 2;
            vc2[1] = 3;
            vc2[2] = 4;
            vc2[3] = 7;
            vc2[4] = 1;
            vc2.multiplication(2);
            vc1.add(1);

            Vector vc4 = new Vector();
            vc4.Length = 3;
            vc4.Numbers = new int[3] { 1, 1, 1 };
            Vector vc5 = (Vector)vc1.Clone();

            if (vc1.Equals(vc5)) Console.WriteLine("vc1 == vc5");
            if (!vc1.Equals(vc2)) Console.WriteLine("vc1 != vc2");
            Console.WriteLine(vc4.GetType());

            Vector[] vcArr = new Vector[] { vc1, vc2, vc3, vc4, vc5 };
            Console.WriteLine("Вектора содержащие 0:");
            for(int i = 0; i<vcArr.Length; ++i)
                    if (vcArr[i].IsNullInVector()) Console.WriteLine($" {i+1}: " + vcArr[i].ToString());
            Console.WriteLine("Вектора с найменьшим модулем:");
            int abslt = vcArr[0].absoluteValueForVector();
            for (int i = 1; i < vcArr.Length; ++i)
                if (vcArr[i].absoluteValueForVector() < abslt) abslt = vcArr[i].absoluteValueForVector();
            for(int i = 0; i < vcArr.Length; ++i)
                if (vcArr[i].absoluteValueForVector() == abslt) Console.WriteLine($" {i+1}: " + vcArr[i].ToString()); ;


            var vc6 = new { Numbers = vc4.Numbers, Length = 3, State = 0 , ID = 124354543};
            Console.WriteLine(vc6);
            Console.Read();
        }
    }
}
