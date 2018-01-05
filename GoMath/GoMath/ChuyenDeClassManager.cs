using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMath
{
    class ChuyenDeClassManager
    {
        public static List<ChuyendeClass> Get()
        {
            List<ChuyendeClass> L = new List<ChuyendeClass>();
            ChuyendeClass temp = new ChuyendeClass();
            temp.ChuyenDeName = "Khảo sát hàm số";
            temp.ChuyenDeCode = "kshs";
            temp.ChuyenDeImage = "Assets/dothihamso.jpg";
            L.Add(temp);
            ChuyendeClass temp1 = new ChuyendeClass();
            temp1.ChuyenDeName = "Lũy thừa,logarit";
            temp1.ChuyenDeCode = "luythua";
            temp1.ChuyenDeImage = "Assets/logarit.jpeg";
            L.Add(temp1);
            ChuyendeClass temp2 = new ChuyendeClass();
            temp2.ChuyenDeName = "Nguyên hàm,tích phân";
            temp2.ChuyenDeCode = "tichphan";
            temp2.ChuyenDeImage = "Assets/integral.png";
            L.Add(temp2);
            ChuyendeClass temp3 = new ChuyendeClass();
            temp3.ChuyenDeName = "Số phức";
            temp3.ChuyenDeCode = "sophuc";
            temp3.ChuyenDeImage = "Assets/complexnumb.jpeg";
            L.Add(temp3);
            ChuyendeClass temp4 = new ChuyendeClass();
            temp4.ChuyenDeCode = "thetich";
            temp4.ChuyenDeName = "Thể tích";
            temp4.ChuyenDeImage = "Assets/conic.png";
            L.Add(temp4);
            return L;
        }
    }
}
