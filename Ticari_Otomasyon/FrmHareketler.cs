﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Ticari_Otomasyon
{
    public partial class FrmHareketler : Form
    {
        public FrmHareketler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl=new sqlbaglantisi();

        void FirmaHareketleri()
        {
            DataTable dt= new DataTable();
            SqlDataAdapter da= new SqlDataAdapter("Exec FirmaHareketler ",bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }
        void MusteriHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec MusteriHareketler ", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmHareketler_Load(object sender, EventArgs e)
        {
            FirmaHareketleri();
            MusteriHareketleri();
        }
    }
}
