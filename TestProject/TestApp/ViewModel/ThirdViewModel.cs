using MvvmCross.Commands;
using MvvmCross.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TestApp.Extensions;
using TestApp.Services;

namespace TestApp.ViewModel
{
    public class ThirdViewModel : Notifier
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IDataService _dataService;
        private ObservableCollection<Kitten> _kittens;
        public ThirdViewModel(IMvxNavigationService navigationService, IDataService dataService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            GetAll();
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
        private MvxCommand _navigateToEditCommand;
        public System.Windows.Input.ICommand NavigateToEditCommand
        {
            get
            {
                _navigateToEditCommand = _navigateToEditCommand ?? new MvxCommand(NavigateSecond);
                return _navigateToEditCommand;
            }
        }
        private MvxCommand _navigateToLogCommand;
        public System.Windows.Input.ICommand NavigateToLogCommand
        {
            get
            {
                _navigateToLogCommand = _navigateToLogCommand ?? new MvxCommand(NavigateThird);
                return _navigateToLogCommand;
            }
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

        private async void GetAll()
        {
            Kittens = (await _dataService.GetAll()).ToObservableCollection();
        }
        private void Navigate()
        {
            _navigationService.Navigate<FirstViewModel>();
        }
        private void NavigateSecond()
        {
            _navigationService.Navigate<SecondViewModel>();
        }

        private void NavigateThird()
        {
            _navigationService.Navigate<MainViewModel>();
        }
    }
}
