using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab1_POMS
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void Button_Clicked(object sender, EventArgs e)
        {
            float growth = Convert.ToSingle(gInput.Text) / 100;
            float weight = Convert.ToSingle(wInput.Text);

            float result = IndexCalculation(growth, weight);

            if (growth == 0 || weight == 0)
            {
                DisplayAlert("Точно?", "0!?", "Ок");
                return;
            }

            string res = "";
            if (result > 25)
            {
                res = "избыточная масса тела";
            }
            else if (result < 20)
            {
                res = "недостаточная масса тела";
            }
            else
            {
                res = " нормальный вес";
            }
            DisplayAlert("Результат", "Ваш индекс массы равен: " + Convert.ToInt32(result).ToString() + "\n У вас " + res, "Ok");
            DependencyService.Get<IMessage>().LongAlert("Вычисленно");


        }

        private void ButtonWhat_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Что?", "Расчет идеального веса через индекс массы тела. Индекс массы тела равен отношению массы тела в килограммах к квадрату росту в метрах. \n ", "OK");
        }

        private float IndexCalculation(float growth, float weight)
        {
            float res = weight / (growth * growth);
            return res;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            changeOrintationMaket(height < width);
        }
        private void changeOrintationMaket(bool isHorizontal)
        {
            if (Device.Idiom == TargetIdiom.Phone)
            {
                inputLayout.Orientation = isHorizontal ? StackOrientation.Horizontal : StackOrientation.Vertical;
            }
            else
            {
                inputLayout.Orientation = StackOrientation.Horizontal;
            }

        }

    }
}
