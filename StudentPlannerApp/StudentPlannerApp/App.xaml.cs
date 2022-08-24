using StudentPlannerApp.Services;
using StudentPlannerApp.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StudentPlannerApp
{
    public partial class App : Application
    {
        static AssignmentService assignmentService;

        static UserService userService;

        public static AssignmentService AssignmentService
        {
            get
            {
                if (assignmentService == null)
                {
                    assignmentService = new AssignmentService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Assignment.db3"));
                }
                return assignmentService;
            }
        }

        public static UserService UserService
        {
            get
            {
                if (userService == null)
                {
                    userService = new UserService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "User.db3"));
                }
                return userService;
            }
        }
        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
