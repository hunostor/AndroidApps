using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace LuckyNumber
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true, Icon = "@mipmap/launcher_icon")]
    public class MainActivity : AppCompatActivity
    {
        SeekBar seekBar;
        TextView resultTextView;
        Button rollButton;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            seekBar = FindViewById<SeekBar>(Resource.Id.seekBar1);
            resultTextView = FindViewById<TextView>(Resource.Id.resultTextView);
            resultTextView.Text = "9";
            rollButton = (Button)FindViewById(Resource.Id.RollButton);
            rollButton.Click += RollButton_Click;

            SupportActionBar.Title = "My Lucky Number App";
        }

        private void RollButton_Click(object sender, System.EventArgs e)
        {
            Random random = new Random();
            int luckyNumber = random.Next(seekBar.Progress) + 1;
            resultTextView.Text = luckyNumber.ToString();

            //if (seekBar.Progress == 10)
            //{                
            //    seekBar.Progress = 0;
            //    resultTextView.Text = "0";
            //}
            //else
            //{                
            //    seekBar.Progress += 1;
            //    resultTextView.Text = seekBar.Progress.ToString();
            //}
        }

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }
}