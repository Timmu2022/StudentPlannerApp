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
    public class AssignmentViewModel : BaseAssignmentViewModel
    {
        public Command LoadAssignmentCommand { get; }
        public ObservableCollection<AssignmentInfo> AssignmentInfos { get; }
        public Command AddAssignmentCommand { get; }

        public Command AssignmentTappedEdit { get; }

        public Command AssignmentTappedDelete { get; }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        public AssignmentViewModel(INavigation navigation)
        {
            LoadAssignmentCommand = new Command(async () => await ExecuteLoadAssignmentCommand());
            AssignmentInfos = new ObservableCollection<AssignmentInfo>();
            AddAssignmentCommand = new Command(OnAddAssignment);
            AssignmentTappedEdit = new Command<AssignmentInfo>(OnEditAssignment);
            AssignmentTappedDelete = new Command<AssignmentInfo>(OnDeleteAssignment);
            Navigation = navigation;
        }

        async Task ExecuteLoadAssignmentCommand()
        {
            IsBusy = true;
            try
            {

                AssignmentInfos.Clear();
                var assignList = await App.AssignmentService.GetAssignmentAsync();
                foreach (var assign in assignList)
                {
                    AssignmentInfos.Add(assign);
                }
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async void OnAddAssignment(object obj)
        {
            await Shell.Current.GoToAsync(nameof(AddAssignmentPage));
        }

        private async void OnEditAssignment(AssignmentInfo assign)
        {
            await Navigation.PushAsync(new AddAssignmentPage(assign));
        }

        private async void OnDeleteAssignment(AssignmentInfo assign)
        {
            if (assign == null)
            {
                return;
            }

            await App.AssignmentService.DeleteAssignmentAsync(assign.AssignmentID);
            await ExecuteLoadAssignmentCommand();
        }
    }
}
