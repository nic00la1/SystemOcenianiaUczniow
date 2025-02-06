using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SystemOcenianiaUczniow.MVVM.Model;

namespace SystemOcenianiaUczniow.MVVM.ViewModel
{
    public class UczenViewModel : ObservableObject
    {
        public ObservableCollection<Uczen> Uczniowie { get; set; } = new ObservableCollection<Uczen>();

        private Uczen _wybranyUczen;
        public Uczen WybranyUczen
        {
            get => _wybranyUczen;
            set => SetProperty(ref _wybranyUczen, value);
        }

        private Ocena _nowaOcena = new Ocena { Data = DateTime.Now };
        public Ocena NowaOcena
        {
            get => _nowaOcena;
            set => SetProperty(ref _nowaOcena, value);
        }

        private double _sredniaOcena;
        public double SredniaOcena
        {
            get => _sredniaOcena;
            set => SetProperty(ref _sredniaOcena, value);
        }

        public ICommand WyswietlUczniaCommand { get; }
        public ICommand DodajOceneCommand { get; }
        public ICommand ObliczSredniaCommand { get; }

        public UczenViewModel()
        {
            // Przyk³adowe dane
            var uczen1 = new Uczen { Imie = "Jan", Nazwisko = "Kowalski", Przedmiot = "Matematyka" };
            uczen1.Oceny.Add(new Ocena { Przedmiot = "Matematyka", Wartosc = 5, Komentarz = "Bardzo dobrze", Data = DateTime.Now });
            uczen1.Oceny.Add(new Ocena { Przedmiot = "Matematyka", Wartosc = 4, Komentarz = "Dobrze", Data = DateTime.Now });

            var uczen2 = new Uczen { Imie = "Anna", Nazwisko = "Nowak", Przedmiot = "Fizyka" };
            uczen2.Oceny.Add(new Ocena { Przedmiot = "Fizyka", Wartosc = 3, Komentarz = "Œrednio", Data = DateTime.Now });

            var uczen3 = new Uczen { Imie = "Piotr", Nazwisko = "Wiœniewski", Przedmiot = "Chemia" };
            uczen3.Oceny.Add(new Ocena { Przedmiot = "Chemia", Wartosc = 2, Komentarz = "S³abo", Data = DateTime.Now });

            Uczniowie.Add(uczen1);
            Uczniowie.Add(uczen2);
            Uczniowie.Add(uczen3);

            WyswietlUczniaCommand = new RelayCommand<Uczen>(WyswietlUcznia);
            DodajOceneCommand = new RelayCommand<Ocena>(DodajOcene);
            ObliczSredniaCommand = new RelayCommand(ObliczSrednia);
        }

        private void WyswietlUcznia(Uczen uczen)
        {
            WybranyUczen = uczen;
            NowaOcena.Przedmiot = uczen.Przedmiot; // Ustawienie przedmiotu dla nowej oceny
        }

        private void DodajOcene(Ocena ocena)
        {
            if (WybranyUczen != null && ocena != null)
            {
                ocena.Przedmiot = WybranyUczen.Przedmiot; // Przypisanie przedmiotu do oceny
                WybranyUczen.Oceny.Add(ocena);
                NowaOcena = new Ocena { Data = DateTime.Now }; // Resetowanie formularza
            }
        }

        private void ObliczSrednia()
        {
            if (WybranyUczen != null)
            {
                SredniaOcena = WybranyUczen.ObliczSrednia();
            }
        }
    }
}
