using Plugin.LocalNotification;
using Plugin.LocalNotification.AndroidOption;
using StudentPlannerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentPlannerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AssignmentPage : ContentPage
    {
        AssignmentViewModel assignmentViewModel;

        public AssignmentPage()
        {
            InitializeComponent();
            BindingContext = assignmentViewModel = new AssignmentViewModel(Navigation);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            assignmentViewModel.OnAppearing();
        }

        async void ShareButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Subject = "Mobile Development",
                Text = "What is Xamarin?",
                Title = "Mobile Development",
                Uri = "https://www.youtube.com/watch?v=JH8ekYJrFHs"
            });

        }

        async void ShareButton_Clicked1(System.Object sender, System.EventArgs e)
        {
            var image = await MediaPicker.PickPhotoAsync();

            if (image == null)
            {
                return;
            }
            await Share.RequestAsync(new ShareFileRequest
            {
                Title = "Mobile Development",
                File = new ShareFile(image)
            });

        }

         void ReminderButton_Clicked(System.Object sender, System.EventArgs e)
        {
            var notification = new NotificationRequest
            {

                BadgeNumber = 1,
                Description = "Study Reminder",
                Title = "Study Reminder Notification",
                ReturningData = "Study for Mobile Development",
                NotificationId = 1337,
                Schedule =
                {
                    NotifyTime = DateTime.Now.AddSeconds(5) // Used for Scheduling local notification, if not specified notification will show immediately.
                },
                Android = new AndroidOptions
                {
                    VisibilityType = AndroidVisibilityType.Public
                }
            };
            
            NotificationCenter.Current.Show(notification);
        }
    }
}
