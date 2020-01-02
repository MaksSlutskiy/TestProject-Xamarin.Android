using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TestApp.Extensions;
using TestApp.Services;

namespace TestApp.ViewModel
{
    public class SecondViewModel : Notifier
    {
        private readonly IDataService _dataService;
        private readonly IMvxNavigationService _navigationService;
        private ObservableCollection<Kitten> _kittens;
        private Kitten kitten = new Kitten
        {
            Name = "Cat",
        };

        public SecondViewModel(IMvxNavigationService navigationService, IDataService dataService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
            GetAll();
        }

        public ObservableCollection<Kitten> Kittens
        {
            get => _kittens;
            set
            {
                _kittens = value;
                Notify();
            }
        }

        private MvxCommand _navigateToMainPageCommand;
        public System.Windows.Input.ICommand NavigateToMainPageCommand
        {
            get
            {
                _navigateToMainPageCommand = _navigateToMainPageCommand ?? new MvxCommand(Navigate);
                return _navigateToMainPageCommand;
            }
        }

        private MvxCommand _navigateToTherdPageCommand;
        public System.Windows.Input.ICommand NavigateToTherdPageCommand
        {
            get
            {
                _navigateToTherdPageCommand = _navigateToTherdPageCommand ?? new MvxCommand(NavigateThird);
                return _navigateToTherdPageCommand;
            }
        }

        private MvxCommand _insertCommand;
        public System.Windows.Input.ICommand InsertCommand
        {
            get
            {
                _insertCommand = _insertCommand ?? new MvxCommand(DoInsert);
                return _insertCommand;
            }
        }

        private MvxCommand _deleteCommand;
        public System.Windows.Input.ICommand DeleteCommand
        {
            get
            {
                _deleteCommand = _deleteCommand ?? new MvxCommand(Delete);
                return _deleteCommand;
            }
        }

        public object NavigationService { get; private set; }

        private void Delete()
        {
            _dataService.Delete(Kittens[0]);
            Kittens.Remove(Kittens[0]);
        }

        private void DoInsert()
        {
            _dataService.Insert(kitten);
            Kittens.Add(kitten);
        }

        private async void GetAll()
        {
            Kittens = (await _dataService.GetAll()).ToObservableCollection();
        }

        private void Navigate()
        {
            _navigationService.Navigate<FirstViewModel>();
        }
        private void NavigateThird()
        {
            _navigationService.Navigate<ThirdViewModel>();
        }
    }
}
