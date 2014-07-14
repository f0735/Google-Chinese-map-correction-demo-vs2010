using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string lng="";
            string lat="";
            ConvertLngLat(txtLng.Text, txtLat.Text, out lng, out lat);
            MessageBox.Show(lng + "," + lat);
        }

        public void ConvertLngLat(string lng,string lat,out string newlng,out string newlat) 
        {
            string olng = lng;
            string olat=lat;
            lng = lng.Substring(0, lng.IndexOf(".") + 2);
            lat = lat.Substring(0, lat.IndexOf(".") + 2);
            gps gpsbll = new gps();
            int i = 0;
            string lngtemp = lng;
            string lattemp = lat;
            double j = 0.1;
            gps model = null;
            model = gpsbll.GetModel(lngtemp, lattemp);
            while (model == null)
            {
                switch (i)
                {
                    case 0:
                        lngtemp=(Convert.ToDouble(lng)+j)+"";
                        i++;
                        break;
                    case 1:
                        lattemp = (Convert.ToDouble(lat) + j) + "";
                        i++;
                        break;
                    case 2:
                        lngtemp = (Convert.ToDouble(lng) - j) + "";
                        i++;
                        break;
                    case 3:
                        lattemp = (Convert.ToDouble(lat) - j) + "";
                        i++;
                        break;
                    case 4:
                        lngtemp = (Convert.ToDouble(lng) + j) + "";
                        lattemp = (Convert.ToDouble(lat) + j) + "";
                        i++;
                        break;
                    case 5:
                        lngtemp = (Convert.ToDouble(lng) - j) + "";
                        lattemp = (Convert.ToDouble(lat) - j) + "";
                        i++;
                        break;
                   case 6:
                        lngtemp = (Convert.ToDouble(lng) + j) + "";
                        lattemp = (Convert.ToDouble(lat) - j) + "";
                        i++;
                        break;
                   case 7:
                        lngtemp = (Convert.ToDouble(lng) - j) + "";
                        lattemp = (Convert.ToDouble(lat) + j) + "";
                        i=0;
                        j = j + 0.1;
                        break;
                    default:
                        break;
                }
                model = gpsbll.GetModel(lngtemp, lngtemp);
           }
            newlng = (Convert.ToDouble(olng)+Convert.ToDouble(model.offset_lng))+"";
            newlat = (Convert.ToDouble(olat) + Convert.ToDouble(model.offset_lat))+"";
        } 
    }


}
