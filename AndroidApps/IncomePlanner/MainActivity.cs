using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace IncomePlanner
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText incomePerHourEditText;
        EditText workHourEditText;
        EditText taxRateEditText;
        EditText savingRateEditText;

        TextView workSummaryView;
        TextView grossSummaryView;
        TextView annualTaxView;
        TextView annualSavingsView;
        TextView spendableIncomeView;

        Button calculateButton;
        RelativeLayout resultLayout;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            ConnectViews();
        }

        void ConnectViews()
        {
            incomePerHourEditText = FindViewById<EditText>(Resource.Id.incomePerHourEditText);
            workHourEditText = FindViewById<EditText>(Resource.Id.workHourEditText);
            taxRateEditText = FindViewById<EditText>(Resource.Id.taxRateEditText);
            savingRateEditText = FindViewById<EditText>(Resource.Id.savingRateEditText);

            workSummaryView = FindViewById<TextView>(Resource.Id.workSummaryView);
            grossSummaryView = FindViewById<TextView>(Resource.Id.grossSummaryView);
            annualTaxView = FindViewById<TextView>(Resource.Id.annualTaxView);
            annualSavingsView = FindViewById<TextView>(Resource.Id.annualSavingsView);
            spendableIncomeView = FindViewById<TextView>(Resource.Id.spendableIncomeView);

            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            resultLayout = FindViewById<RelativeLayout>(Resource.Id.resultLayout);

            calculateButton.Click += CalculateButton_Click;
        }

        private void CalculateButton_Click(object sender, System.EventArgs e)
        {
            // Take input from user
            double incomePerHour = double.Parse(incomePerHourEditText.Text);
            double workHourPerDay = double.Parse(workHourEditText.Text);
            double taxRate = double.Parse(taxRateEditText.Text);
            double savingsRate = double.Parse(savingRateEditText.Text);

            // business logic
            double annualWorkHourSummary = workHourPerDay * 5 * 50;
            double annualIncome = incomePerHour * workHourPerDay * 5 * 50;
            double taxPayable = (taxRate / 100) * annualIncome;
            double annualSavings = (savingsRate / 100) * annualIncome;
            double spendableIncome = annualIncome = annualSavings - taxPayable;

            // Display resutl of the calculation
            this.grossSummaryView.Text = annualIncome.ToString("#,##") + " USD";
            this.workSummaryView.Text = annualWorkHourSummary.ToString("#,##") + " HRS";
            this.annualTaxView.Text = taxPayable.ToString("#,##") + " USD";
            this.annualSavingsView.Text = annualSavings.ToString("#,##") + " USD";
            this.spendableIncomeView.Text = spendableIncome.ToString("#,##") + " USD";

            resultLayout.Visibility = Android.Views.ViewStates.Visible;
        }

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }
}