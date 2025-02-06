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
            Uczniowie.Add(new Uczen { Imie = "Jan", Nazwisko = "Kowalski" });
            Uczniowie.Add(new Uczen { Imie = "Anna", Nazwisko = "Nowak" });
            Uczniowie.Add(new Uczen { Imie = "Piotr", Nazwisko = "Wiœniewski" });

            WyswietlUczniaCommand = new RelayCommand<Uczen>(WyswietlUcznia);
            DodajOceneCommand = new RelayCommand<Ocena>(DodajOcene);
            ObliczSredniaCommand = new RelayCommand(ObliczSrednia);
        }

        private void WyswietlUcznia(Uczen uczen)
        {
            WybranyUczen = uczen;
        }

        private void DodajOcene(Ocena ocena)
        {
            if (WybranyUczen != null && ocena != null)
            {
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
