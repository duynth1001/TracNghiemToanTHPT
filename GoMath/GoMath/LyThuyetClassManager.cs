using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMath
{
    class LyThuyetClassManager
    {
        public static List<LyThuyetClass> Get()
        {
            List<LyThuyetClass> L = new List<LyThuyetClass>();
            LyThuyetClass temp = new LyThuyetClass();
            temp.LyThuyetCode = "chuyendehamso";
            temp.LyThuyetName = "Lý thuyết khảo sát hàm số";
            temp.LyThuyetImage = "Assets/function-512.png";
            L.Add(temp);
            LyThuyetClass temp1 = new LyThuyetClass();
            temp1.LyThuyetCode = "chuyendelogarit";
            temp1.LyThuyetName = "Lý thuyết lũy thừa,logarit";
            temp1.LyThuyetImage = "Assets/logarit.png";
            L.Add(temp1);
            LyThuyetClass temp2 = new LyThuyetClass();
            temp2.LyThuyetCode = "chuyendetichphan";
            temp2.LyThuyetName = "Lý thuyết nguyên hàm,tích phân";
            temp2.LyThuyetImage = "Assets/tichphan.png";
            L.Add(temp2);
            LyThuyetClass temp3 = new LyThuyetClass();
            temp3.LyThuyetCode = "chuyendesophuc";
            temp3.LyThuyetName = "Lý thuyết số phức";
            temp3.LyThuyetImage = "Assets/complexso.png";
            L.Add(temp3);
            LyThuyetClass temp4 = new LyThuyetClass();
            temp4.LyThuyetCode = "chuyendethetich";
            temp4.LyThuyetName = "Lý thuyết thể tích";
            temp4.LyThuyetImage = "Assets/volumeicon.png";
            L.Add(temp4);
            return L;
        }
    }
}
