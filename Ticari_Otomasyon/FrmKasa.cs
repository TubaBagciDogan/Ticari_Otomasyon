using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;
namespace Ticari_Otomasyon
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl=new sqlbaglantisi();

        void musterihareket()
        {
           DataTable dt = new DataTable();
            SqlDataAdapter da= new SqlDataAdapter("Execute MusteriHareketler",bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        void firmahareket()
        {
            DataTable dt2= new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Execute FirmaHareketler",bgl.baglanti());
            da2.Fill(dt2);  
            gridControl3.DataSource = dt2;
        }
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            musterihareket();
            firmahareket();


            //Toplam Tutarı Hesaplama
            SqlCommand komut1 = new SqlCommand("Select Sum(Tutar) From TBL_FATURADETAY",bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblKasaToplam.Text = dr1[0].ToString() + " ₺";
            }
            bgl.baglanti().Close();

            // son ayın faturaları
            SqlCommand komut2 = new SqlCommand("Select (ELEKTRIK+SU+DOGALGAZ+INTERNET+EKSTRA) from TBL_GIDERLER order by ID asc",bgl.baglanti());
            SqlDataReader dr2= komut2.ExecuteReader();
            while(dr2.Read())
            {
                LblOdemeler.Text = dr2[0].ToString() + " ₺";
            }
            bgl.baglanti().Close();
        }
    }
}
