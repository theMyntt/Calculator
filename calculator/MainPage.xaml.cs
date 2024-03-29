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

            if (mathMethod == "")
            {
                this.firstNum = double.Parse(result.Text);
            }
            else
            {
                this.secondNum = double.Parse(result.Text);
            }
        }
        void ClearNumber(Object sender, EventArgs e)
        {
            result.Text = "0";
            result.FontSize = 56;

            this.mathMethod = "";
            this.textResult = "";
            this.firstNum = null;
            this.secondNum = null;
        }
        void PlusMinus(Object sender, EventArgs e)
        {
            if (this.plusMinus)
            {
                this.textResult = this.textResult.Substring(1);
                this.plusMinus = false;
            }
            else
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
                this.mathMethod = BtnText;

                this.textResult = "";
            }
            catch (Exception)
            {
                DisplayAlert("Erro", "Não foi possível concluir esta ação", "OK");
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
                        if (this.secondNum != 0)
                        {
                            result.Text = (this.firstNum / this.secondNum).ToString();
                        }
                        else
                        {
                            result.Text = "Indefinido";
                        }
                        break;
                }

                this.firstNum = double.Parse(result.Text);
                this.secondNum = null;
            }
            catch (Exception)
            {
                DisplayAlert("Erro", "Não foi possível concluir esta ação", "OK");
            }
        }
        void Percent(Object sender, EventArgs e)
        {
            if (this.firstNum != null)
            {
                this.firstNum /= 100;
                result.Text = this.firstNum.ToString();
            }
            else if (this.secondNum != null)
            {
                this.secondNum /= 100;
                result.Text = this.secondNum.ToString();
            }
            else
            {
                DisplayAlert("Erro", "Apenas um número deve ser definido para calcular a porcentagem", "OK");
            }
        }
    }
}
