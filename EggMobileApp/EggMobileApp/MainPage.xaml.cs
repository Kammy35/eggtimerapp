using EggMobileApp.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EggMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public static TimeSpan EggTime;

        private EggPageViewModel _viewModel;
        public MainPage()
        {
            InitializeComponent();
            _viewModel = new EggPageViewModel();
            BindingContext = _viewModel;

            


            EggSize.Items.Add("Small");
            EggSize.Items.Add("Medium");
            EggSize.Items.Add("Large");

            EggTexture.Items.Add("Soft");
            EggTexture.Items.Add("Medium");
            EggTexture.Items.Add("Hard");

            EggTexture.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                if (EggTexture.SelectedItem == "Soft")
                {
                    EggTime = CheckEggTexture("Soft");
                    _viewModel.StartTime = EggTime;
                    _viewModel.Duration = _viewModel.StartTime.ToString();

                } else if (EggTexture.SelectedItem == "Medium")
                {
                    EggTime = CheckEggTexture("Medium");
                    _viewModel.StartTime = EggTime;
                    _viewModel.Duration = _viewModel.StartTime.ToString();
                }
                else
                {
                    EggTime = CheckEggTexture("Hard");
                    _viewModel.StartTime = EggTime;
                    _viewModel.Duration = _viewModel.StartTime.ToString();

                }
            };

        }


        public static TimeSpan CheckEggTexture(string EggTexture)
        {
            if (EggTexture == "Soft")
            {
                return  TimeSpan.FromSeconds(180);

            }
            else if (EggTexture == "Medium")
            {
                return TimeSpan.FromSeconds(360); ;
            }
            else  
            {
                return TimeSpan.FromSeconds(900);
            }
        }

       


        private void startButton_Clicked(object sender, EventArgs e)
        {

        }

        private void resetButton_Clicked(object sender, EventArgs e)
        {
            _viewModel.StartTime = TimeSpan.FromSeconds(0);
            _viewModel.Duration = _viewModel.StartTime.ToString();
        }

       
    }


}