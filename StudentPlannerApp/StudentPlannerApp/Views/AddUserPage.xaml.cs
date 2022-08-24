using StudentPlannerApp.Models;
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
    public partial class AddUserPage : ContentPage
    {
        public UserInfo userInfo { get; set; } 

        public AddUserPage()
        {
            InitializeComponent();
            BindingContext = new AddUserViewModel();
        }

        public AddUserPage(UserInfo userInfo)
        {
            InitializeComponent();
            BindingContext = new AddUserViewModel();

            if (userInfo != null)
            {
                ((AddUserViewModel)BindingContext).UserInfo = userInfo;
            }
        }
    }
}