using StudentPlannerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentPlannerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        UserViewModel userViewModel;
        public UserPage()
        {
            InitializeComponent();
            BindingContext = userViewModel = new UserViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            userViewModel.OnAppearing();
        }
    }
}