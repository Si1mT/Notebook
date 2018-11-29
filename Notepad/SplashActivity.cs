using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using Android.Support.V7.App;

namespace Notepad
{
    [Activity(Theme = "@style/AppTheme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        static readonly string TAG = "X:" + typeof(SplashActivity).Name;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SupportActionBar.Hide();
        }
        protected override void OnResume()
        {
            base.OnResume();
            Task startUp = new Task(() => { SimulateStartup(); });

        }

        async void SimulateStartup()
        {
            await Task.Delay(8000);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}