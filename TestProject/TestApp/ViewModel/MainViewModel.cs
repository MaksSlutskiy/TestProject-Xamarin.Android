using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestApp.Extensions;

namespace TestApp.ViewModel
{
    public class MainViewModel : Notifier
    {
        private readonly IMvxNavigationService _navigationService;
        public MainViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

        }

        void CheckLogin()
        {
            if (Password == "demo" && Login == "demo")
            {
                _navigationService.Navigate<FirstViewModel>();

            }
            else if(Password == "" && Login == "")
            {
                Message = "Validation error";
            }
            else
            {
                Message = "Incorrected login or password";
            }
        }


        public IMvxCommand NavigateCommand
        {
            get { return new MvxCommand(CheckLogin); }
        }

        private string login="";
        public string Login
        {
            get => login;
            set
            {
                login = value;
                Notify();
            }
        }
        private string password="" ;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                Notify();
            }
        }
        private string message ;
        public string Message
        {
            get => message;
            set
            {
                message = value;
                Notify();
            }
        }
    }
}
