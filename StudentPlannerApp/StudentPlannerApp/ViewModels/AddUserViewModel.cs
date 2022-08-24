using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using StudentPlannerApp.Models;

namespace StudentPlannerApp.ViewModels
{
    public class AddUserViewModel : BaseUserViewModel
    {
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public AddUserViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);

            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();

            UserInfo = new UserInfo();
        }

        private async void OnSave()
        {
            var user = UserInfo;
            await App.UserService.AddUserAsync(user);

            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
