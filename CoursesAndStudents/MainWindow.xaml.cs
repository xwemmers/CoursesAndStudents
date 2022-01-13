using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.EntityFrameworkCore;

namespace CoursesAndStudents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        CoursesContext context = new();

        private void ShowStudents(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = context.Students!.ToList();
        }

        private void ShowCourses(object sender, RoutedEventArgs e)
        {
            dg.ItemsSource = context.Courses!.ToList();
        }

        private void AddStudents2Courses(object sender, RoutedEventArgs e)
        {
            var st = cbxStudents.SelectedItem as Student;
            var course = cbxCourses.SelectedItem as Course;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxCourses.DisplayMemberPath = "Name";
            cbxStudents.DisplayMemberPath = "Firstname";

            cbxCourses.ItemsSource = context.Courses!.ToList();
            cbxStudents.ItemsSource = context.Students!.ToList();
        }

        private void ShowEnrollments(object sender, RoutedEventArgs e)
        {
        }

        private void TestLazyLoading(object sender, RoutedEventArgs e)
        {
        }
    }
}
