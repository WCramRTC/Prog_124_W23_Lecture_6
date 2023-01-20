using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Prog_124_W23_Lecture_6.Examples.Inheirtance_Display
{
    /// <summary>
    /// Interaction logic for Inheritance_Example.xaml
    /// </summary>
    public partial class Inheritance_Example : Window
    {

        ObservableCollection<object> objectCollection = new ObservableCollection<object>();
        ObservableCollection<Transportation> transportationCollection = new ObservableCollection<Transportation>();
        ObservableCollection<Car> carCollection = new ObservableCollection<Car>();
        ObservableCollection<Boat> boatCollection = new ObservableCollection<Boat>();
        ObservableCollection<Plane> planeCollection = new ObservableCollection<Plane>();

        List<ListBox> listBoxes = new List<ListBox>();

        public Inheritance_Example()
        {
            InitializeComponent();
            ConnectCollections();
            UpdateCount();
        }

        public void ConnectCollections()
        {
            lbObject.ItemsSource = objectCollection;
            lbTransportation.ItemsSource = transportationCollection;
            lbCar.ItemsSource = carCollection;
            lbBoat.ItemsSource = boatCollection;
            lbFly.ItemsSource = planeCollection;

            listBoxes.Add(lbObject);
            listBoxes.Add(lbTransportation);
            listBoxes.Add(lbCar);
            listBoxes.Add(lbBoat);
            listBoxes.Add(lbFly);
        }

        public void ClearListBoxes(object selectedItem)
        {
            foreach (ListBox item in listBoxes)
            {
                if(item.SelectedItem != selectedItem)
                {
                    item.UnselectAll();
                }         
            }
        }

        public void AddToCollection(object obj)
        {

            if(obj is object)
            {
                objectCollection.Add(obj);
            }

            if(obj is Transportation)
            {
                Transportation t = (Transportation)obj;
                transportationCollection.Add(t);
            }

            if (obj is Car)
            {
                Car t = (Car)obj;
                carCollection.Add(t);
            }

            if (obj is Boat)
            {
                Boat t = (Boat)obj;
                boatCollection.Add(t);
            }

            if (obj is Plane)
            {
                Plane t = (Plane)obj;
                planeCollection.Add(t);
            }


        }

        public void UpdateCount()
        {
            lblObjectCount.Content = objectCollection.Count;
            lblTransportationCount.Content = transportationCollection.Count;
            lblCarCount.Content = carCollection.Count;
            lblBoatCount.Content = boatCollection.Count;
            lblPlaneCount.Content = planeCollection.Count;
        }

        private void btnMakeVehicle_Click(object sender, RoutedEventArgs e)
        {
     

            bool isTransportation = rbTransportation.IsChecked.Value;
            bool isCar = rbCar.IsChecked.Value;
            bool isBoat = rbBoat.IsChecked.Value;
            bool isPlane = rbPlane.IsChecked.Value;

            if(isTransportation)
            {
                AddToCollection(new Transportation("Transportation"));
            }
            else if(isBoat)
            {
                AddToCollection(new Boat("Boat"));

            }
            else if (isCar)
            {
                AddToCollection(new Car("Car"));

            }
            else if (isPlane)
            {
                AddToCollection(new Plane("Plane"));

            }
            else
            {
                AddToCollection(new object());
            }

            UpdateCount();

        }

        private void SelectAllOfTypes(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            object selectedItem = listBox.SelectedItem;

            ClearListBoxes(selectedItem);

            SelectListItem(selectedItem);

            UpdateCount();
        }

        public void SelectListItem(object selectedItem)
        {
            foreach (ListBox item in listBoxes)
            {

                item.SelectedItem = selectedItem;
            }
        }
    }
}
