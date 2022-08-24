using StudentPlannerApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace StudentPlannerApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}