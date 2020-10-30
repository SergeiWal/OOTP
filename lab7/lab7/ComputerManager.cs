using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class ComputerManager
    {

        static public Computer SearchGame(Computer  pc, string ganre)
        {
            Computer list = new Computer();
            if (pc.Length == 0) throw new Exception("Not found soft in this computer!");
            for(int i = 0; i < pc.Length;++i)
            {
                if(pc.Get()[i] is Game)
                {
                    Game gm = (Game)pc.Get()[i];
                    if (gm.Genre == ganre) list.Add(gm);
                }
            }
            return list;
        }
            

        static public Computer SearchTextProcessor(Computer pc)
        {
            Computer list = new Computer();
            for (int i = 0; i < pc.Length; ++i)
            {
                if (pc.Get()[i] is TextProcessor)
                {
                    if (pc.Get()[i].Name == "Word") list.Add((Word)pc.Get()[i]);
                }
            }
            return list;
        }

        static public void AbcOut(Computer pc)
        {
            char[] eng = { 'A',  'B', 'C' , 'D' , 'E', 'F' , 'G', 'H', 'I', 'K' ,  'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'V', 'X',
                'Y', 'Z', 'W', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И','Й','К','Л','М','Н','О','П','Р','С','Т','У','Ф','Х','Ц','Ч','Ш','Щ','Ъ','Ы','Ь','Э','Ю',
                'Я'};

           

            for (int i =0;i<eng.Length;++i)
            {
                for(int j=0;j<pc.Length;++j)
                {
                    if (pc.Get()[j].Name[0] == eng[i]) Console.WriteLine(pc.Get()[j].Name);
                }
            }
        }
    }
}
