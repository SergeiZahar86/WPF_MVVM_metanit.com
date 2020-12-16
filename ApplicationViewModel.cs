using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MVVM_metanit.com
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        System.Windows.Threading.DispatcherTimer dispatcherTimer;   // Таймер
        private static ApplicationViewModel instance;

        private Phone selectedPhone;

        public ObservableCollection<Phone> Phones { get; set; }

        // команда добавления нового объекта
        private RelayCommand addCommand;
        public RelayCommand AddCommand // если этот класс синглентон, то команда не работает
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Phone phone = new Phone();
                      Phones.Insert(0, phone);
                      SelectedPhone = phone;
                  }));
            }
        }

        public static ApplicationViewModel getInstance()
        {
            if(instance == null)
            {
                instance = new ApplicationViewModel();
                return instance;
            }
            else
            {
                return instance;
            }
        }
        private void OnTimedEvent(Object source, EventArgs e)      // Получение вагонов с сервера по таймеру
        {
            Phone phone = new Phone { Title = "iPhone 7", Company = "Apple", Price = 56000 };
            Phone phone1 = new Phone("sdf", "sdf", 444);
            Phones.Insert(0, phone1);
            Phones.Insert(0, phone);

        }

        public Phone SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }
        public ApplicationViewModel()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone { Title="iPhone 7", Company="Apple", Price=56000 },
                new Phone {Title="Galaxy S7 Edge", Company="Samsung", Price =60000 },
                new Phone {Title="Elite x3", Company="HP", Price=56000 },
                new Phone {Title="Mi5S", Company="Xiaomi", Price=35000 }
            };

            // Таймер ///////////////////////////////////////
            dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(OnTimedEvent);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);
            dispatcherTimer.Start();                    // Стартуем таймер
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
