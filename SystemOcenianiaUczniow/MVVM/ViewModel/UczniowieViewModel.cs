using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SystemOcenianiaUczniow.MVVM.Model;

namespace SystemOcenianiaUczniow.MVVM.ViewModel
{
    public class UczniowieViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Uczen> uczniowie;
        public ObservableCollection<Uczen> Uczniowie
        {
            get => uczniowie;
            set
            {
                uczniowie = value;
                OnPropertyChanged();
            }
        }

        public UczniowieViewModel()
        {
            // Przyk³adowe dane
            Uczniowie = new ObservableCollection<Uczen>
            {
                new Uczen
                {
                    Imie = "Jan",
                    Nazwisko = "Kowalski",
                    Klasa = "3A",
                    Oceny = new List<Ocena>
                    {
                        new Ocena { Przedmiot = "Matematyka", Wartosc = 5, Komentarz = "Bardzo dobry", Data = "15.01.2025" }
                    }
                },
                new Uczen
                {
                    Imie = "Anna",
                    Nazwisko = "Nowak",
                    Klasa = "3B",
                    Oceny = new List<Ocena>
                    {
                        new Ocena { Przedmiot = "Matematyka", Wartosc = 4, Komentarz = "Dobry", Data = "20.01.2025" }
                    }
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
