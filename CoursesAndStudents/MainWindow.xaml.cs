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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbxCourses.DisplayMemberPath = "Name";
            cbxStudents.DisplayMemberPath = "Firstname";

            cbxCourses.ItemsSource = context.Courses!.ToList();
            cbxStudents.ItemsSource = context.Students!.ToList();
        }


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

            if (st == null)
                return;

            if (course == null)
                return;

            var enr = new Enrollment { Student = st, Course = course };
            
            context.Enrollments!.Add(enr);
            
            context.SaveChanges();
        }

        private void ShowEnrollments(object sender, RoutedEventArgs e)
        {
            var query = from enr in context.Enrollments
                        select new
                        {
                            enr.Student!.Firstname,
                            enr.Student.Lastname,
                            enr.Course!.Name
                        };

            dg.ItemsSource = query.ToList();
        }

        private void TestLazyLoading(object sender, RoutedEventArgs e)
        {
            // Dit is zonder gerelateerde data
            var st = context.Students!.First(x => x.Firstname == "Koen");

            // Dit is Eager Loading
            //var st = context.Students!.Include(st => st.Enrollments).First(x => x.Firstname == "Koen");

            MessageBox.Show(st.Firstname);
            MessageBox.Show("Het aantal is: " + st.Enrollments.Count());
        }

        private void TestLazyLoading2(object sender, RoutedEventArgs e)
        {
            var students = context.Students!.ToList();

            foreach (var st in students)
            {
                if (st.Firstname == "Koen")
                {
                    // Zonder lazy loading kun je als volgt gerelateerde data ophalen:
                    context.Entry(st).Collection(x => x.Enrollments).Load();

                    MessageBox.Show("Het aantal is: " + st.Enrollments.Count());
                }
            }
        }

        private void TestLazyLoading3(object sender, RoutedEventArgs e)
        {
            var query = from st in context.Students
                        where st.Enrollments.Count() == 0
                        select new
                        {
                            st.Firstname,
                            st.Lastname,
                            Count = st.Enrollments.Count()
                        };

            var result = query.ToList();

            dg.ItemsSource = result;
        }

    }
}
