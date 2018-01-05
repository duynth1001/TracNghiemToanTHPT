using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace GoMathWebService
{
    /// <summary>
    /// Summary description for DataControlService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class DataControlService : System.Web.Services.WebService
    {
        private OleDbConnection cn;
        private OleDbCommand cm;
        private OleDbDataAdapter da;

        private void connect()
        {
            cn = new OleDbConnection();
            cn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + Server.MapPath("AppData\\GoMathData.mdb") + "'";
            cn.Open();
        }

        private int executeSQL(string sql)
        {
            connect();
            cm = new OleDbCommand();
            cm.Connection = cn;
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            int r = cm.ExecuteNonQuery();
            cn.Close();
            return r;
        }

        private DataTable getData(string sql)
        {
            connect();
            da = new OleDbDataAdapter(sql, cn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cn.Close();
            return dt;
        }

        [WebMethod]
        public bool InsertNewUser(string username,string fullname,string email,string password)
        {
            DataTable dt = getData("select * from THONGTINDANGNHAP where USERNAME = '" + username + "'");
            if (dt.Rows.Count == 0)
            {
                executeSQL("insert into THONGTINDANGNHAP (USERNAME,FULLNAME,EMAIL,[PASSWORD]) VALUES('"+username+"','"+fullname+"','"+email+"','"+password+"')");
                DataTable _dt = getData("select * from THONGTINDANGNHAP where USERNAME = '" + username + "' AND [PASSWORD]= '" + password + "'");
                if (_dt.Rows.Count == 0)
                    return false;
                else
                {
                    ThongTinDangNhap temp = new ThongTinDangNhap();
                    temp.IDNguoiDung = int.Parse(_dt.Rows[0][0].ToString());
                    executeSQL("insert into THONGTINNGUOIDUNG (ID,SoBaiKiemTra,DiemTrungBinh,XepLoai,HamSo,LuyThua,NguyenHam,SoPhuc,TheTich) VALUES(" +temp.IDNguoiDung.ToString()+ "," + "0" + "," + "0"+","+ "'trống'" + "," + "0" + "," + "0" + "," + "0" + "," + "0" + "," + "0" + ")");
                }
                return true;
            }
            return false;
        }
        
        [WebMethod]
        public ThongTinDangNhap UserLogin(string username,string password)
        {
            ThongTinDangNhap temp = null;
            DataTable dt = getData("select * from THONGTINDANGNHAP where USERNAME = '" + username + "' AND [PASSWORD]= '"+password+"'");
            if (dt.Rows.Count == 0)
                temp = null;
            else
            {
                temp = new ThongTinDangNhap();
                temp.IDNguoiDung = int.Parse(dt.Rows[0][0].ToString());
                temp.UserName = dt.Rows[0][1].ToString();
                temp.FullName = dt.Rows[0][2].ToString();
                temp.Email = dt.Rows[0][3].ToString();
                temp.PassWord = dt.Rows[0][4].ToString();
            }
                return temp;
        }

        [WebMethod]
        public List<BoDe> GetBoDe()
        {
            List<BoDe> datalist = new List<BoDe>();
            DataTable dt = getData("select *from BODE");
            if (dt.Rows.Count == 0)
                datalist = null;
            else
            {
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    BoDe temp = new BoDe();
                    temp.Title = dt.Rows[i][0].ToString();
                    temp.TenBoDe = dt.Rows[i][1].ToString();
                    datalist.Add(temp);
                }
            }
            return datalist;
        }
        
       [WebMethod]
        public List<ChuyenDe> GetChuyenDeHamSo()
        {
            List<ChuyenDe> datalist = new List<ChuyenDe>();
            DataTable dt = getData("select *from CHUYENDEHAMSO");
            if (dt.Rows.Count == 0)
                datalist = null;
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ChuyenDe temp = new ChuyenDe();
                    temp.Title = dt.Rows[i][0].ToString();
                    temp.TenChuyenDe = dt.Rows[i][1].ToString();
                    temp.SoCau = int.Parse(dt.Rows[i][2].ToString());
                    datalist.Add(temp);
                }
            }
            return datalist;
        }

        [WebMethod]
        public List<ChuyenDe> GetChuyenDeLuyThua()
        {
            List<ChuyenDe> datalist = new List<ChuyenDe>();
            DataTable dt = getData("select *from CHUYENDELUYTHUA");
            if (dt.Rows.Count == 0)
                datalist = null;
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ChuyenDe temp = new ChuyenDe();
                    temp.Title = dt.Rows[i][0].ToString();
                    temp.TenChuyenDe = dt.Rows[i][1].ToString();
                    temp.SoCau = int.Parse(dt.Rows[i][2].ToString());
                    datalist.Add(temp);
                }
            }
            return datalist;
        }

        [WebMethod]
        public List<ChuyenDe> GetChuyenDeNguyenHam()
        {
            List<ChuyenDe> datalist = new List<ChuyenDe>();
            DataTable dt = getData("select *from CHUYENDENGUYENHAM");
            if (dt.Rows.Count == 0)
                datalist = null;
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ChuyenDe temp = new ChuyenDe();
                    temp.Title = dt.Rows[i][0].ToString();
                    temp.TenChuyenDe = dt.Rows[i][1].ToString();
                    temp.SoCau = int.Parse(dt.Rows[i][2].ToString());
                    datalist.Add(temp);
                }
            }
            return datalist;
        }


        [WebMethod]
        public List<ChuyenDe> GetChuyenDeSoPhuc()
        {
            List<ChuyenDe> datalist = new List<ChuyenDe>();
            DataTable dt = getData("select *from CHUYENDESOPHUC");
            if (dt.Rows.Count == 0)
                datalist = null;
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ChuyenDe temp = new ChuyenDe();
                    temp.Title = dt.Rows[i][0].ToString();
                    temp.TenChuyenDe = dt.Rows[i][1].ToString();
                    temp.SoCau = int.Parse(dt.Rows[i][2].ToString());
                    datalist.Add(temp);
                }
            }
            return datalist;
        }


        [WebMethod]
        public List<ChuyenDe> GetChuyenDeTheTich()
        {
            List<ChuyenDe> datalist = new List<ChuyenDe>();
            DataTable dt = getData("select *from CHUYENDETHETICH");
            if (dt.Rows.Count == 0)
                datalist = null;
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ChuyenDe temp = new ChuyenDe();
                    temp.Title = dt.Rows[i][0].ToString();
                    temp.TenChuyenDe = dt.Rows[i][1].ToString();
                    temp.SoCau = int.Parse(dt.Rows[i][2].ToString());
                    datalist.Add(temp);
                }
            }
            return datalist;
        }


        [WebMethod]
        public List<DapAnBoDe> GetDapAn(string title)
        {
            List<DapAnBoDe> datalist = new List<DapAnBoDe>();
            DataTable dt = getData("select* from DAPANBODE where Title='" + title + "'");

            if (dt.Rows.Count == 0)
                datalist = null;
            else
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    DapAnBoDe temp = new DapAnBoDe();
                    temp.DapAn = dt.Rows[0][i].ToString();
                    datalist.Add(temp);
                }
            }
            return datalist;
        }


        [WebMethod]
        public List<DapAnChuyenDe> GetDapAnHamSo(string title,int SoCau)
        {
            List<DapAnChuyenDe> datalist = new List<DapAnChuyenDe>();
            DataTable dt = getData("select* from DAPANCHUYENDEHAMSO where Title='" + title + "'");

            if (dt.Rows.Count == 0)
                datalist = null;
            else
            {
                for(int i=0;i<SoCau;i++)
                {
                    DapAnChuyenDe temp = new DapAnChuyenDe();
                    temp.DapAn = dt.Rows[0][i].ToString();
                    datalist.Add(temp);
                }
            }
            return datalist;
        }

        [WebMethod]
        public List<DapAnChuyenDe> GetDapAnLuyThua(string title,int SoCau)
        {
            List<DapAnChuyenDe> datalist = new List<DapAnChuyenDe>();
            DataTable dt = getData("select* from DAPANCHUYENDELUYTHUA  where Title='" + title + "'");

            if (dt.Rows.Count == 0)
                datalist = null;
            else
            {
                for (int i = 0; i < SoCau; i++)
                {
                    DapAnChuyenDe temp = new DapAnChuyenDe();
                    temp.DapAn = dt.Rows[0][i].ToString();
                    datalist.Add(temp);
                }
            }
            return datalist;
        }

        [WebMethod]
        public List<DapAnChuyenDe> GetDapAnNguyenHam(string title,int SoCau)
        {
            List<DapAnChuyenDe> datalist = new List<DapAnChuyenDe>();
            DataTable dt = getData("select* from DAPANCHUYENDENGUYENHAM where Title='" + title + "'");

            if (dt.Rows.Count == 0)
                datalist = null;
            else
            {
                for (int i = 0; i < SoCau; i++)
                {
                    DapAnChuyenDe temp = new DapAnChuyenDe();
                    temp.DapAn = dt.Rows[0][i].ToString();
                    datalist.Add(temp);
                }
            }
            return datalist;
        }


        [WebMethod]
        public List<DapAnChuyenDe> GetDapAnSoPhuc(string title,int SoCau)
        {
            List<DapAnChuyenDe> datalist = new List<DapAnChuyenDe>();
            DataTable dt = getData("select* from DAPANCHUYENDESOPHUC where Title='" + title + "'");

            if (dt.Rows.Count == 0)
                datalist = null;
            else
            {
                for (int i = 0; i < SoCau; i++)
                {
                    DapAnChuyenDe temp = new DapAnChuyenDe();
                    temp.DapAn = dt.Rows[0][i].ToString();
                    datalist.Add(temp);
                }
            }
            return datalist;
        }


        [WebMethod]
        public List<DapAnChuyenDe> GetDapAnTheTich(string title,int SoCau)
        {
            List<DapAnChuyenDe> datalist = new List<DapAnChuyenDe>();
            DataTable dt = getData("select* from DAPANCHUYENDETHETICH where Title='" + title + "'");

            if (dt.Rows.Count == 0)
                datalist = null;
            else
            {
                for (int i = 0; i <SoCau; i++)
                {
                    DapAnChuyenDe temp = new DapAnChuyenDe();
                    temp.DapAn = dt.Rows[0][i].ToString();
                    datalist.Add(temp);
                }
            }
            return datalist;
        }
      
      
        [WebMethod]
        public ThongTinNguoiDungClass GetNguoiDung(int nguoidungID)
        {
            ThongTinNguoiDungClass datalist = null;
            DataTable dt = getData("select * from THONGTINNGUOIDUNG where ID = " + nguoidungID + "");
            if (dt.Rows.Count == 0)
                datalist = null;
            else
            {
                datalist = new ThongTinNguoiDungClass();
                datalist.SoBaiKiemTraDaLam =int.Parse(dt.Rows[0][1].ToString());
                datalist.DiemTrungBinh = double.Parse(dt.Rows[0][2].ToString());
                datalist.XepLoai = dt.Rows[0][3].ToString();
                datalist.TyLeLamBaiDung_khaosathamso = double.Parse(dt.Rows[0][4].ToString());
                datalist.TyLeLamBaiDung_luythualogarit = double.Parse(dt.Rows[0][5].ToString());
                datalist.TyLeLamBaiDung_nguyenhamtichphan = double.Parse(dt.Rows[0][6].ToString());
                datalist.TyLeLamBaiDung_sophuc = double.Parse(dt.Rows[0][7].ToString());
                datalist.TyLeLamBaiDung_thetich = double.Parse(dt.Rows[0][8].ToString());
            }            
            return datalist;
        }
        [WebMethod]
        public List<LichSuLamBaiClass>GetLichSuLamBai(int nguoiDungID)
        {
            List<LichSuLamBaiClass> datalist = new List<LichSuLamBaiClass>();
            DataTable dt = getData("select *from LICHSULAMBAI where ID= "+nguoiDungID+"");
            if (dt.Rows.Count == 0)
                datalist = null;
            else
            {
                for(int i=0;i<dt.Rows.Count;i++)
                {
                    LichSuLamBaiClass temp = new LichSuLamBaiClass();
                    temp.DiemCuaBan = double.Parse(dt.Rows[i][1].ToString());
                    temp.ThoiGianLamBai = dt.Rows[i][2].ToString();
                    temp.TenDeThi = dt.Rows[i][3].ToString();
                    temp.DeThiCode = dt.Rows[i][4].ToString();
                    datalist.Add(temp);
                }
            }
            return datalist;
        }

        [WebMethod]
        public void InsertLichSuLamBai(int IDNguoiDung,double DiemNguoiDung,string ThoiGianLamBai,string TenDeThi,string DeThiCode)
        {
            executeSQL("insert into LICHSULAMBAI (ID,DiemNguoiDung,ThoiGianLamBai,TenDeThi,DeThiCode) VALUES (" + IDNguoiDung + "," + DiemNguoiDung + ",'"+ThoiGianLamBai+"','" + TenDeThi + "','" + DeThiCode + "')");
        }

        [WebMethod]
        public void CapNhatThongTinNguoiDung(int nguoiDungID,string DeThiCode)
        {
            List<LichSuLamBaiClass> datalist=GetLichSuLamBai(nguoiDungID);
            if (datalist == null)
                return;
            else
            {
                executeSQL("UPDATE THONGTINNGUOIDUNG  SET SoBaiKiemTra=" + datalist.Count + "  WHERE ID=" + nguoiDungID + "; ");
                double DiemTongAll = 0;
                for(int i=0;i<datalist.Count;i++)
                {
                    DiemTongAll += datalist[i].DiemCuaBan;
                }
                double DiemTrungBinhAll = DiemTongAll / datalist.Count;
                DiemTrungBinhAll= Math.Round(DiemTrungBinhAll, 2);
                executeSQL("UPDATE THONGTINNGUOIDUNG  SET DiemTrungBinh=" + DiemTrungBinhAll + "  WHERE ID=" + nguoiDungID + " ");
                if(DiemTrungBinhAll>=8)
                    executeSQL("UPDATE THONGTINNGUOIDUNG  SET XepLoai=" + "'Giỏi'" + "  WHERE ID=" + nguoiDungID + " ");
                else if(DiemTrungBinhAll<8 &&DiemTrungBinhAll>=6)
                    executeSQL("UPDATE THONGTINNGUOIDUNG  SET XepLoai=" + "'Khá'" + "  WHERE ID=" + nguoiDungID + " ");
                else if(DiemTrungBinhAll < 6 && DiemTrungBinhAll >= 5)
                     executeSQL("UPDATE THONGTINNGUOIDUNG  SET XepLoai=" + "'Trung bình'" + "  WHERE ID=" + nguoiDungID + " ");
                else
                    executeSQL("UPDATE THONGTINNGUOIDUNG  SET XepLoai=" + "'Yếu'" + "  WHERE ID=" + nguoiDungID + " ");
                switch (DeThiCode)
                {
                    case "kshs":
                        {
                            double count = 0;
                            double DiemTong = 0;
                            for (int i = 0; i < datalist.Count; i++)
                            {
                                if (datalist[i].DeThiCode == "kshs")
                                {
                                    Debug.WriteLine(datalist[i].DeThiCode);
                                    DiemTong += datalist[i].DiemCuaBan;
                                    count++;
                                }
                            }
                            if (count == 0)
                                return;
                            double DiemTrungBinh = DiemTong / count;
                            DiemTrungBinh = Math.Round(DiemTrungBinh, 0);                  
                            executeSQL("UPDATE THONGTINNGUOIDUNG  SET HamSo=" + DiemTong + "  WHERE ID=" + nguoiDungID + "; ");
                            break;
                        }
                    case "luythua":
                        {
                            double count = 0;
                            double DiemTong = 0;
                            for (int i = 0; i < datalist.Count; i++)
                            {
                                if (datalist[i].DeThiCode == "luythua")
                                {
                                    DiemTong += datalist[i].DiemCuaBan;
                                    count++;
                                }
                            }
                            if (count == 0)
                                return;
                            double DiemTrungBinh = DiemTong / count;
                            DiemTrungBinh = Math.Round(DiemTrungBinh, 0);
                            executeSQL("UPDATE THONGTINNGUOIDUNG  SET LuyThua=" + DiemTrungBinh + "  WHERE ID=" + nguoiDungID + "; ");
                            break;
                        }
                    case "tichphan":
                        {
                            double count = 0;
                            double DiemTong = 0;
                            for (int i = 0; i < datalist.Count; i++)
                            {
                                if (datalist[i].DeThiCode == "tichphan")
                                {
                                    DiemTong += datalist[i].DiemCuaBan;
                                    count++;
                                }
                            }
                            if (count == 0)
                                return;
                            double DiemTrungBinh = DiemTong / count;
                            DiemTrungBinh = Math.Round(DiemTrungBinh, 0);
                            executeSQL("UPDATE THONGTINNGUOIDUNG  SET NguyenHam=" + DiemTrungBinh + "  WHERE ID=" + nguoiDungID + "; ");
                           break;
                        }
                    case "sophuc":
                        {
                            double count = 0;
                            double DiemTong = 0;
                            for (int i = 0; i < datalist.Count; i++)
                            {
                                if (datalist[i].DeThiCode == "sophuc")
                                {
                                    DiemTong += datalist[i].DiemCuaBan;
                                    count++;
                                }
                            }
                            if (count == 0)
                                return;
                            double DiemTrungBinh = DiemTong / count;
                            DiemTrungBinh = Math.Round(DiemTrungBinh, 0);
                            executeSQL("UPDATE THONGTINNGUOIDUNG  SET SoPhuc=" + DiemTrungBinh + "  WHERE ID=" + nguoiDungID + "; ");
                            break;
                        }
                    case "thetich":
                        {
                            double count = 0;
                            double DiemTong = 0;
                            for (int i = 0; i < datalist.Count; i++)
                            {
                                if (datalist[i].DeThiCode == "thetich")
                                {
                                    DiemTong += datalist[i].DiemCuaBan;
                                    count++;
                                }
                            }
                            if (count == 0)
                                return;
                            double DiemTrungBinh = DiemTong / count;
                            DiemTrungBinh = Math.Round(DiemTrungBinh, 0);
                            executeSQL("UPDATE THONGTINNGUOIDUNG  SET TheTich=" + DiemTrungBinh + "  WHERE ID=" + nguoiDungID + "; ");
                            break;
                        }
                    default:
                        break;
                }

            }
        }

        public class LichSuLamBaiClass
        {
            public string DeThiCode { get; set; }
            public double DiemCuaBan { get; set; }
            public string TenDeThi { get; set; }
            public string ThoiGianLamBai { get; set; }
        }

        public class DapAnBoDe
        {
            public string DapAn { get; set; }
        }

        public class DapAnChuyenDe
        {
            public string DapAn { get; set; }
        }

          public  class ThongTinNguoiDungClass
        {
            public int SoBaiKiemTraDaLam { get; set; }
            public double DiemTrungBinh { get; set; }
            public string XepLoai { get; set; }
            public double TyLeLamBaiDung_khaosathamso { get; set; }
            public double TyLeLamBaiDung_luythualogarit { get; set; }
            public double TyLeLamBaiDung_nguyenhamtichphan { get; set; }
            public double TyLeLamBaiDung_sophuc { get; set; }
            public double TyLeLamBaiDung_thetich { get; set; }
        }


        public class ThongTinDangNhap
        {
          public int IDNguoiDung { get; set; }
            public string UserName { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string PassWord { get; set; }
        }

        public class ChuyenDe
        {
            public string Title { get; set; }
            public string TenChuyenDe { get; set; }
            public int SoCau { get; set; }
        }

        public class BoDe
        {
            public string Title { get; set; }
            public string TenBoDe { get; set; }
        }
    }
}
