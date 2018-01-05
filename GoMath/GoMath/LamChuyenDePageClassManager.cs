using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoMath.ServiceReference1;
namespace GoMath
{
    class LamChuyenDePageClassManager
    {
        public static List<LamChuyenDePageClass>Get()
        {
            List<LamChuyenDePageClass>L=new List<LamChuyenDePageClass>();
            for(int i=0;i<LopThongTin.ChuyenDePass.SoCau;i++)
            {
                LamChuyenDePageClass temp = new LamChuyenDePageClass();
               temp.SoCauNguoiDung= "Câu " + (i+1).ToString() + ".";
                L.Add(temp);
            }
            return L;
        }
    }
}
