using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using App1;

namespace Phoneword
{
    [Activity(Label = "Fiets Info Rotterdam", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Our code will go here
            EditText phoneNumberText = FindViewById<EditText>(Resource.Id.PhoneNumberText);
            Button button1 = FindViewById<Button>(Resource.Id.Vraag1);
            Button button2 = FindViewById<Button>(Resource.Id.Vraag2);
            Button button3 = FindViewById<Button>(Resource.Id.Vraag3);
            Button button4 = FindViewById<Button>(Resource.Id.Vraag4);
            Button button5 = FindViewById<Button>(Resource.Id.Vraag5);
            Button button6 = FindViewById<Button>(Resource.Id.Vraag6);
            Button button7 = FindViewById<Button>(Resource.Id.Vraag7);

            button1.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(Vraag1_Activity));
                StartActivity(intent);
            };

            //// Disable the "Call" button
            //callButton.Enabled = false;

            //// Add code to translate number
            //string translatedNumber = string.Empty;

            //translateButton.Click += (object sender, EventArgs e) =>
            //{
            //    // Translate user's alphanumeric phone number to numeric
            //    translatedNumber = Core.PhonewordTranslator.ToNumber(phoneNumberText.Text);
            //    if (String.IsNullOrWhiteSpace(translatedNumber))
            //    {
            //        callButton.Text = "Call";
            //        callButton.Enabled = false;
            //    }
            //    else
            //    {
            //        callButton.Text = "Call " + translatedNumber;
            //        callButton.Enabled = true;
            //    }
            //};
        }
    }
}