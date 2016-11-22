using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System;

namespace XamarinBatteryCheck
{
    [Activity(Label = "XamarinBatteryCheck", MainLauncher = true, Icon = "@drawable/icon", Theme ="@style/Theme.AppCompat.Light.NoActionBar")]
    public class MainActivity : AppCompatActivity
    {
        public TextView txtBatteryStatus, txtBatteryPlug, txtBatteryLevel, txtBatteryHealth, txtBatteryVoltage;
        public TextView txtBatteryTemp, txtBatteryTechnology;

        private IntentFilter intentFilter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            //Views
            txtBatteryStatus = FindViewById<TextView>(Resource.Id.txtStatus);
            txtBatteryPlug = FindViewById<TextView>(Resource.Id.txtPlug);
            txtBatteryLevel = FindViewById<TextView>(Resource.Id.txtLevel);
            txtBatteryHealth = FindViewById<TextView>(Resource.Id.txtHealth);
            txtBatteryVoltage = FindViewById<TextView>(Resource.Id.txtVoltage);
            txtBatteryTemp = FindViewById<TextView>(Resource.Id.txtTemp);
            txtBatteryTechnology = FindViewById<TextView>(Resource.Id.txtTech);

            //Intent Filter
            intentFilter = new IntentFilter(Intent.ActionBatteryChanged);

            MyBroadCastReceiver broadCastReceiver = new MyBroadCastReceiver(this);

            RegisterReceiver(broadCastReceiver, intentFilter);
        }
    }

    internal class MyBroadCastReceiver : BroadcastReceiver
    {
        private MainActivity mainActivity;

        public MyBroadCastReceiver(MainActivity mainActivity)
        {
            this.mainActivity = mainActivity;
        }

        public override void OnReceive(Context context, Intent intent)
        {
            //status
            int status = intent.GetIntExtra(BatteryManager.ExtraStatus, -1);
            if (status == (int)Android.OS.BatteryStatus.Charging)
                mainActivity.txtBatteryStatus.Text = "Battery Status : Charging";
            else if (status == (int)Android.OS.BatteryStatus.Full)
                mainActivity.txtBatteryStatus.Text = "Battery Status : Full";
            else if (status == (int)Android.OS.BatteryStatus.Discharging)
                mainActivity.txtBatteryStatus.Text = "Battery Status : DisCharging";
            else if (status == (int)Android.OS.BatteryStatus.NotCharging)
                mainActivity.txtBatteryStatus.Text = "Battery Status : NotCharging";
            else if (status == (int)Android.OS.BatteryStatus.Unknown)
                mainActivity.txtBatteryStatus.Text = "Battery Status : Unknown";

            //Power Plug
            int chargePlug = intent.GetIntExtra(BatteryManager.ExtraPlugged, -1);
            if (chargePlug == (int)Android.OS.BatteryPlugged.Ac)
                mainActivity.txtBatteryPlug.Text = "Power source : AC";
            else if (chargePlug == (int)Android.OS.BatteryPlugged.Usb)
                mainActivity.txtBatteryPlug.Text = "Power source : USB";
            else if (chargePlug == (int)Android.OS.BatteryPlugged.Wireless)
                mainActivity.txtBatteryPlug.Text = "Power source : Wireless";

            //Level
            int level = intent.GetIntExtra(BatteryManager.ExtraLevel, -1);
            int scale = intent.GetIntExtra(BatteryManager.ExtraScale, -1);
            float batteryPct = (level / (float)scale) * 100;
            mainActivity.txtBatteryLevel.Text = "Battery Level : " + batteryPct + " %";

            //Voltage
            int voltage = intent.GetIntExtra(BatteryManager.ExtraVoltage, -1);
            mainActivity.txtBatteryVoltage.Text = "Battery Voltage : " + voltage + " mV";

            //Temperature
            int temp = intent.GetIntExtra(BatteryManager.ExtraTemperature, -1);
            mainActivity.txtBatteryTemp.Text = "Battery Temperature : " + temp + " *C";

            //Technology
            String tech = intent.GetStringExtra(BatteryManager.ExtraTechnology);
            mainActivity.txtBatteryTechnology.Text = "Battery Technology : " + tech;

            //Health
            int health = intent.GetIntExtra(BatteryManager.ExtraHealth, -1);
            switch (health)
            {
                case (int)Android.OS.BatteryHealth.Cold:
                    mainActivity.txtBatteryHealth.Text = "Battery Health : COLD";
                    break;

                case (int)Android.OS.BatteryHealth.Dead:
                    mainActivity.txtBatteryHealth.Text = "Battery Health : DEAD";
                    break;

                case (int)Android.OS.BatteryHealth.Good:
                    mainActivity.txtBatteryHealth.Text = "Battery Health : GOOD";
                    break;

                case (int)Android.OS.BatteryHealth.Overheat:
                    mainActivity.txtBatteryHealth.Text = "Battery Health : OVERHEAT";
                    break;

                case (int)Android.OS.BatteryHealth.OverVoltage:
                    mainActivity.txtBatteryHealth.Text = "Battery Health : OVER VOLTAGE";
                    break;

                case (int)Android.OS.BatteryHealth.Unknown:
                    mainActivity.txtBatteryHealth.Text = "Battery Health : UNKNOWN";
                    break;

                case (int)Android.OS.BatteryHealth.UnspecifiedFailure:
                    mainActivity.txtBatteryHealth.Text = "Battery Health : FAILURE";
                    break;

                default:
                    break;
            };
        }
    }
}