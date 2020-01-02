using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using TestApp.Extensions;
using TestApp.Services;

namespace TestApp.ViewModel
{
   public class FirstViewModel : Notifier
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly IDataService _dataService;
        private ObservableCollection<Kitten> _kittens;
        public FirstViewModel(IMvxNavigationService navigationService, IDataService dataService)
        {
            _navigationService = navigationService;
            _dataService = dataService;
            GetAll();
        }
        private MvxCommand _navigateToEditCommand;
        public System.Windows.Input.ICommand NavigateToEditCommand
        {
            get
            {
                _navigateToEditCommand = _navigateToEditCommand ?? new MvxCommand(Navigate);
                return _navigateToEditCommand;
            }
        }

        private MvxCommand _navigateToThirdPageCommand;
        public System.Windows.Input.ICommand NavigateToThirdPageCommand
        {
            get
            {
                _navigateToThirdPageCommand = _navigateToThirdPageCommand ?? new MvxCommand(NavigateSecond);
                return _navigateToThirdPageCommand;
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
            _navigationService.Navigate<SecondViewModel>();
        }
        private void NavigateSecond()
        {
            _navigationService.Navigate<ThirdViewModel>();
        }
    }
}
