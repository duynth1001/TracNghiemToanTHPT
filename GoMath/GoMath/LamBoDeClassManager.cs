using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMath
{
    class LamBoDeClassManager
    {        public static List<LamBoDeClass>GetData()
        {
            List<LamBoDeClass> datalist = new List<LamBoDeClass>();
            for(int i=1;i<=50;i++)
            {
                LamBoDeClass temp = new LamBoDeClass();
                temp.SoCauNguoiDung = "Câu "+i.ToString()+".";          
                datalist.Add(temp);
            }
            return datalist;
        }
      
    }
}
