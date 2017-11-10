using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarshallsRevenueGUI
{
    public partial class MarshallsRevenueGUI : Form
    {
        public MarshallsRevenueGUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int defaultExteriorPrice = 750;
            int defaultInteriorPrice = 500;

            String monthText = textBox1.Text;
            String interiorMuralText = textBox2.Text;
            String exteriorMuralText = textBox3.Text;

            int monthNumber = Convert.ToInt32(monthText);
            int interiorMuralNumber = Convert.ToInt32(interiorMuralText);
            int exteriorMuralNumber = Convert.ToInt32(exteriorMuralText);
            

            Boolean exteriorGreater = interiorMuralNumber < exteriorMuralNumber;
            Boolean interiorGreater = interiorMuralNumber > exteriorMuralNumber;

            




            






            switch (monthNumber)
            {
                case 1:
                    exteriorMuralNumber = 0;
                    
                    break;
                case 2:
                    exteriorMuralNumber = 0;
                    break;
                case 4:
                    defaultExteriorPrice = 699;
                    break;
                case 5:
                    defaultExteriorPrice = 699;
                    break;
                case 7:
                    defaultInteriorPrice = 450;
                    break;
                case 8:
                    defaultInteriorPrice = 450;
                    break; 
                case 9:
                    defaultExteriorPrice = 699;
                    break;
                case 10:
                    defaultExteriorPrice = 699;
                    break;
                case 12:
                    exteriorMuralNumber = 0;
                    break;
                default:
                    defaultExteriorPrice = 750;
                    defaultInteriorPrice = 500;
                    
                    break; 

            }

            int totalExteriorMuralPrice = defaultExteriorPrice * exteriorMuralNumber;
            int totalInteriorMuralPrice = defaultInteriorPrice * interiorMuralNumber;
            int totalExpectedRevenue = totalExteriorMuralPrice + totalInteriorMuralPrice;

            label5.Text = "Total Expected Revenue: $" + totalExpectedRevenue;


            if (exteriorGreater)
            {
                label4.Text = "Exterior Murals > Interior Murals"; 
            }
            else if(interiorGreater)
            {
                label4.Text = "Exterior Murals < Interior Murals"; 
            }
            else
            {
                label4.Text = "Exterior Murals = Interior Murals"; 
            }



        }
    }
}
