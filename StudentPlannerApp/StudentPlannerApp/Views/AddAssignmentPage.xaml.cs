using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StudentPlannerApp.Models;
using StudentPlannerApp.ViewModels;

namespace StudentPlannerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddAssignmentPage : ContentPage
    {
        public AssignmentInfo assignmentInfo { get; set; }
        public AddAssignmentPage()
        {
            InitializeComponent();
            BindingContext = new AddAssignmentViewModel();
        }

        public AddAssignmentPage(AssignmentInfo assignmentInfo)
        {
            InitializeComponent();
            BindingContext = new AddAssignmentViewModel();

            if (assignmentInfo != null)
            {
                ((AddAssignmentViewModel)BindingContext).AssignmentInfo = assignmentInfo;
            }
        }

        async void Upload_AssignmentNotes(System.Object sender, System.EventArgs e)
        {
            var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
            {
                Title = "Please Pick a Photo"
            });

            var stream = await result.OpenReadAsync();

            //resultImage.Source = ImageSource.FromStream(() => stream);

            //Get the full path of the current photo
            string path = result.FullPath;

            var editor = new Editor { Text = path };

            var text = editor.Text;

            EditorPath.Text = text;
        }
    }
}