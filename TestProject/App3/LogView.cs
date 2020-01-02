using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using TestApp.ViewModel;

namespace App3
{
    [Activity(Label = "Api examples", MainLauncher = true)]
    public class LogView : MvxActivity<MainViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.LogPage);
        }
    }

   [Activity(NoHistory = true)]
    public class MainPageView : MvxActivity<FirstViewModel>
    {
        
        protected override void OnCreate(Bundle bundle)
        {
            var setupSingleton = MvxAndroidSetupSingleton.EnsureSingletonAvailable(this);
            setupSingleton.EnsureInitialized();
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstLayout);
        }

    }

    [Activity(NoHistory = true)]
    public class EditPageView : MvxActivity<SecondViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SecondLayout);
        }
    }

    [Activity(NoHistory = true)]
    public class LogautPageView : MvxActivity<ThirdViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ThirdLayout);
        }
    }
}
