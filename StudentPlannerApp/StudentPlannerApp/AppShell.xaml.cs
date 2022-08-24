using StudentPlannerApp.ViewModels;
using StudentPlannerApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StudentPlannerApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(AddAssignmentPage), typeof(AddAssignmentPage));
            Routing.RegisterRoute(nameof(AddUserPage), typeof(AddUserPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
