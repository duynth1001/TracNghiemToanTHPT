using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoMath
{
    class ThongTinNguoiDungClassManager
    {
        public static List<ThongTinNguoiDungClass>GetData()
        {
            List<ThongTinNguoiDungClass> datalist = new List<ThongTinNguoiDungClass>();
            ThongTinNguoiDungClass temp = new ThongTinNguoiDungClass();
            temp.DiemTrungBinh = 4.5;
            temp.SoBaiKiemTraDaLam = 5;
            temp.TyLeLamBaiDung_khaosathamso = "40%";
            temp.TyLeLamBaiDung_luythualogarit = "50%";
            temp.TyLeLamBaiDung_nguyenhamtichphan = "30%";
            temp.TyLeLamBaiDung_sophuc = "10%";
            temp.TyLeLamBaiDung_thetich = "22%";
            temp.XepLoai = "Gioi";
            datalist.Add(temp);
            return datalist;
        }
    }
}
