using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        void AddNumber(Object sender, EventArgs e)
        {
            if (result.Text == "0") {
                result.Text = "";
            }

            Button BtnDown = (Button)sender;

            String BtnText = BtnDown.Text;
            if (result.Text.Length > 7)
            {
                result.FontSize -= 10;
            }
            result.Text += BtnText;
            
        }
        void ClearNumber(Object sender, EventArgs e)
        {
            result.Text = "0";
            result.FontSize = 56;
        }
    }
}
