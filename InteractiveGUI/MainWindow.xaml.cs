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

namespace InteractiveGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        Controller controller = Controller.GetInstance();
        public MainWindow()
        {
            InitializeComponent();
            PersonCounter();
            DisableButtons();
        }

        private void PersonCounter()
        {
            PersonCount.Content = "Person Count: " + controller.PersonCount;
            IndexCount.Content = "Index: " + controller.PersonIndex;
        }

        private void DisableButtons()
        {
            if (controller.PersonCount == 0)
            {
                FirstName.IsEnabled = false;
                LastName.IsEnabled = false;
                Age.IsEnabled = false;
                PhoneNr.IsEnabled = false;
                DeletePerson.IsEnabled = false;
                ScrollUp.IsEnabled = false;
                ScrollDown.IsEnabled = false;
            }
        }

        private void EnableButtons()
        {
            FirstName.IsEnabled = true;
            LastName.IsEnabled = true;
            Age.IsEnabled = true;
            PhoneNr.IsEnabled = true;
            DeletePerson.IsEnabled = true;
            ScrollUp.IsEnabled = true;
            ScrollDown.IsEnabled = true;
        }

        private void ClearBoxes()
        {
            if (controller.PersonCount == 0)
            {
                FirstName.Text = "";
                LastName.Text = "";
                Age.Text = "";
                PhoneNr.Text = "";
            }
            else
            {
                FirstName.Text = controller.CurrentPerson.FirstName;
                LastName.Text = controller.CurrentPerson.LastName;
                Age.Text = controller.CurrentPerson.Age.ToString();
                PhoneNr.Text = controller.CurrentPerson.TelephoneNo;
            }
        }

        private void NewPerson_Click(object sender, RoutedEventArgs e)
        {
            controller.AddPerson();
            ClearBoxes();
            EnableButtons();
            PersonCounter();
        }

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.PersonCount != 0)
            {
                controller.CurrentPerson.FirstName = FirstName.Text;
            }
        }

        private void LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.PersonCount != 0)
            {
                controller.CurrentPerson.LastName = LastName.Text;
            }
        }

        private void Age_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.PersonCount != 0)
            {
                int.TryParse(Age.Text, out int age);
                controller.CurrentPerson.Age = age;
            }
        }

        private void PhoneNr_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.PersonCount != 0)
            {
                controller.CurrentPerson.TelephoneNo = PhoneNr.Text;
            }
        }

        private void DeletePerson_Click(object sender, RoutedEventArgs e)
        {
            controller.DeletePerson();
            PersonCounter();
            DisableButtons();
            ClearBoxes();
        }

        private void ScrollUp_Click(object sender, RoutedEventArgs e)
        {
            controller.NextPerson();
            PersonCounter();
            ClearBoxes();
            
        }

        private void ScrollDown_Click(object sender, RoutedEventArgs e)
        {
            controller.PrevPerson();
            PersonCounter();
            ClearBoxes();
        }
    }
}
