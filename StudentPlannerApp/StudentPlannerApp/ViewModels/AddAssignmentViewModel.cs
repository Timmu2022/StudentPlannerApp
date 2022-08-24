using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using StudentPlannerApp.Models;

namespace StudentPlannerApp.ViewModels
{
    public class AddAssignmentViewModel:BaseAssignmentViewModel
    {
        public Command SaveCommand { get; }
        public Command CancelCommand { get; } 
        public AddAssignmentViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);

            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();

            AssignmentInfo = new AssignmentInfo();
        }

        private async void OnSave()
        {
            var assignment = AssignmentInfo;
            await App.AssignmentService.AddAssignmentAsync(assignment);

            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancel() 
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
