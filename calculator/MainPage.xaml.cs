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
        public void AddNumber(Object sender, EventArgs e)
        {
            Button BtnDown = (Button)sender;

            String BtnText = BtnDown.Text;
            result.Text += BtnText;
        }
    }
}
