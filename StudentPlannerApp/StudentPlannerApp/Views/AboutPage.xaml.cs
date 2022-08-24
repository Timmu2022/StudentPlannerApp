using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentPlannerApp.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        //async void SingleButton_Clicked(System.Object sender, System.EventArgs e)
        //{
        //    await Image1.RelScaleTo(2, 500);

        //}

        //async void CompundButton_Clicked(System.Object sender, System.EventArgs e)
        //{
        //    await Image2.RelScaleTo(2, 500);
        //    await Image2.RelRotateTo(30, 1000);
        //}

        async void CompositeButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Task.WhenAll(Image3.FadeTo(0, 10000));
        }
        async void ShowButton_Clicked(System.Object sender, System.EventArgs e) 
        {
            await Task.WhenAll(Image3.FadeTo(1, 10000));
        }
    }
}