using Microsoft.Practices.Prism.Mvvm;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismTestV2.ViewModels.Customers
{
    public class CustomerItemViewModel : ViewModel
    {

        public CustomerItemViewModel(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set { SetProperty(ref _surname, value); }
        }

        private int myVar;
        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
    }
}
