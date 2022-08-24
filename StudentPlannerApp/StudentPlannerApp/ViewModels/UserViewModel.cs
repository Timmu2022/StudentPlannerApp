using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using StudentPlannerApp.Models;
using StudentPlannerApp.Views;

namespace StudentPlannerApp.ViewModels
{
    public class UserViewModel : BaseUserViewModel
    {
        public Command LoadUserCommand { get; }
        public ObservableCollection<UserInfo> UserInfos { get; }
        public Command AddUserCommand { get; }

        public Command UserTappedEdit { get; }

        public Command UserTappedDelete { get; }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        public UserViewModel(INavigation navigation)
        {
            LoadUserCommand = new Command(async () => await ExecuteLoadUserCommand());
            UserInfos = new ObservableCollection<UserInfo>();
            AddUserCommand = new Command(OnAddUser);
            UserTappedEdit = new Command<UserInfo>(OnEditUser);
            UserTappedDelete = new Command<UserInfo>(OnDeleteUser);
            Navigation = navigation;
        }

        async Task ExecuteLoadUserCommand()
        {
            IsBusy = true;
            try
            {

                UserInfos.Clear();
                var assignList = await App.UserService.GetUserAsync(); 
                foreach (var assign in assignList)
                {
                    UserInfos.Add(assign);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async void OnAddUser(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddUserPage));
        }

        private async void OnEditUser(UserInfo assign)
        {
            await Navigation.PushAsync(new AddUserPage(assign));
        }

        private async void OnDeleteUser(UserInfo assign)
        {
            if (assign == null)
            {
                return;
            }

            await App.UserService.DeleteUserAsync(assign.UserID); 
            await ExecuteLoadUserCommand();
        }
    }
}
