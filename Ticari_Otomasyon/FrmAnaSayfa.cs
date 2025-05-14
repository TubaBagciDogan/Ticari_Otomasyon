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
using DevExpress.XtraGrid;
using System.Xml;
namespace Ticari_Otomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl=new sqlbaglantisi();

        void stoklar()
        {
            DataTable dt=new DataTable();
            SqlDataAdapter da=new SqlDataAdapter("Select Urunad, Sum(Adet) as 'Adet' From TBL_URUNLER group by URUNAD having Sum(adet)<=20 order by sum(adet)",bgl.baglanti());
            da.Fill(dt);
            GridControlStoklar.DataSource = dt;
        }


        void ajanda()
        {
            DataTable dt=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select top 10 tarıh,saat,baslık From TBL_NOTLAR order by ID desc ",bgl.baglanti());
            da.Fill(dt);
            gridControlAjanda.DataSource = dt;
        }

        void FirmaHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec FirmaHareket2 ", bgl.baglanti());
            da.Fill(dt);
            gridControlFirmaHareket.DataSource = dt;
        }

        void fihrist()
        {
            DataTable dt=new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Ad,Telefon1 From TBL_FIRMALAR",bgl.baglanti());
            da.Fill(dt);
            gridControlfihrist.DataSource = dt;
        }

        void haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while(xmloku.Read())
            {
                if(xmloku.Name=="title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }
        }
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            stoklar();
            ajanda();

            FirmaHareketleri();
            fihrist();

            webBrowser1.Navigate("https://www.tcmb.gov.tr/wps/wcm/connect/tr/tcmb+tr/main+page+site+area/bugun");

            haberler();
        }
    }
}
