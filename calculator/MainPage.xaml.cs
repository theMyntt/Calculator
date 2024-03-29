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
        private Boolean plusMinus = false;

        private String mathMethod = "";
        private String textResult = "";

        private Double? firstNum = null;
        private Double? secondNum = null;


        public MainPage()
        {
            InitializeComponent();
        }
        void AddNumber(Object sender, EventArgs e)
        {
            result.Text = "";
            

            Button BtnDown = (Button)sender;

            String BtnText = BtnDown.Text;
            if (result.Text.Length == 7)
            {
                result.FontSize -= 10;
            }

            if (result.Text.Length < 9)
            {
                this.textResult += BtnText;
            }

            result.Text = this.textResult;
            
        }
        void ClearNumber(Object sender, EventArgs e)
        {
            result.Text = "0";
            result.FontSize = 56;

            this.mathMethod = null;
            this.textResult = null;
        }
        void PlusMinus(Object sender, EventArgs e)
        {
            if (this.plusMinus)
            {
                this.textResult = this.textResult.Substring(1);
                this.plusMinus = false;
            }else
            {
                this.textResult = "-" + this.textResult;
                this.plusMinus = true;
            }

            result.Text = this.textResult;
        }
        void SetMathMethod(Object sender, EventArgs e)
        {
            Button BtnDown = (Button)sender;
            String BtnText = BtnDown.Text;

            try
            {
                this.firstNum = double.Parse(this.textResult);
                this.mathMethod = BtnText;

                this.textResult = null;
            } catch (Exception)
            {
                DisplayAlert("Erro", "Não foi possivel concluir esta ação", "OK");
            }
        }
        void MakeCalculation(Object sender, EventArgs e)
        {
            try
            {
                this.secondNum = double.Parse(result.Text);

                switch (this.mathMethod)
                {
                    case "+":
                        result.Text = (this.firstNum + this.secondNum).ToString();
                        break; 
                    case "−":
                        result.Text = (this.firstNum - this.secondNum).ToString();
                        break;
                    case "×":
                        result.Text = (this.firstNum * this.secondNum).ToString();
                        break;
                    case "÷":
                        if (this.firstNum != 0 || this.secondNum != 0)
                        {
                            result.Text = (this.firstNum / this.secondNum).ToString();
                        }else
                        {
                            result.Text = "Indefinido";
                        }
                        break;
                }

                this.firstNum = 0;
                this.secondNum = 0;
            } catch (Exception)
            {
                DisplayAlert("Erro", "Não foi possivel concluir esta ação", "OK");
            }
        }
        void Percent(Object sender, EventArgs e)
        {
            if (firstNum != null)
            {
                this.secondNum = this.secondNum / 100;

                result.Text = this.secondNum.ToString();
            }
            else
            {
                this.firstNum = this.firstNum / 100;

                result.Text = this.firstNum.ToString();
            }
        }
    }
}
