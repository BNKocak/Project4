using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.OS;
using Android.Widget;
using Android.Locations;
using Android.Util;
using System.Threading.Tasks;

namespace sBike
{
    [Activity(Label = "sBike")]
    public class Activity5 : Activity, ILocationListener
    {
        static readonly string TAG = "X:" + typeof(Activity5).Name;
        TextView _addressText;
        TextView savedAddress;
        Location _currentLocation;
        LocationManager _locationManager;

        DataModel dataModel = new DataModel();
        string _locationProvider;
        TextView _locationText;

        public async void OnLocationChanged(Location location)
        {
            _currentLocation = location;
            if (_currentLocation == null)
            {
                _locationText.Text = "Unable to determine your location. Try again in a short whilez.";
            }
            else
            {
                _locationText.Text = string.Format("{0:f6},{1:f6}", _currentLocation.Latitude, _currentLocation.Longitude);
                Address address = await ReverseGeocodeCurrentLocation();
                DisplayAddress(address);
            }
        }
        public void OnProviderDisabled(string provider) { }
        public void OnProviderEnabled(string provider) { }
        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {
            Log.Debug(TAG, "{0}, {1}", provider, status);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Question5_layout);
            // Create your application here

            savedAddress = FindViewById<TextView>(Resource.Id.DBAddressText);
            Button btnSaveAddress = FindViewById<Button>(Resource.Id.btnSaveAddress);
            Button btnDeleteAddress = FindViewById<Button>(Resource.Id.btnDeleteAddress);
            Button btnShowAddress = FindViewById<Button>(Resource.Id.btnShowLocation);

            _addressText = FindViewById<TextView>(Resource.Id.address_text);
            _locationText = FindViewById<TextView>(Resource.Id.location_text);
            FindViewById<TextView>(Resource.Id.get_address_button).Click += AddressButton_OnClick;

            btnSaveAddress.Click += btnSaveAddress_OnClick;
            btnDeleteAddress.Click += btnDeleteAddress_OnClick;
            btnShowAddress.Click += btnShowAddress_OnClick;

            InitializeLocationManager();
        }

        void InitializeLocationManager()
        {
            _locationManager = (LocationManager)GetSystemService(LocationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Fine
            };
            IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

            if (acceptableLocationProviders.Any())
            {
                _locationProvider = acceptableLocationProviders.First();
            }
            else
            {
                _locationProvider = string.Empty;
            }
            Log.Debug(TAG, "Using " + _locationProvider + ".");
        }

        protected override void OnResume()
        {
            base.OnResume();
            _locationManager.RequestLocationUpdates(_locationProvider, 0, 0, this);
            Log.Debug(TAG, "Listening for location updates using " + _locationProvider + ".");
        }

        protected override void OnPause()
        {
            base.OnPause();
            _locationManager.RemoveUpdates(this);
            Log.Debug(TAG, "No longer listening for location updates.");
        }

        async void AddressButton_OnClick(object sender, EventArgs eventArgs)
        {
            if (_currentLocation == null)
            {
                _addressText.Text = "Can't determine the current address. Try again in a few minutes.";
                return;
            }

            Address address = await ReverseGeocodeCurrentLocation();
            DisplayAddress(address);
        }

        async Task<Address> ReverseGeocodeCurrentLocation()
        {
            Geocoder geocoder = new Geocoder(this);
            IList<Address> addressList =
                await geocoder.GetFromLocationAsync(_currentLocation.Latitude, _currentLocation.Longitude, 10);

            Address address = addressList.FirstOrDefault();
            return address;
        }

        void DisplayAddress(Address address)
        {
            if (address != null)
            {
                StringBuilder deviceAddress = new StringBuilder();
                for (int i = 0; i < address.MaxAddressLineIndex; i++)
                {
                    deviceAddress.AppendLine(address.GetAddressLine(i));
                }
                // Remove the last comma from the end of the address.
                _addressText.Text = deviceAddress.ToString();
            }
            else
            {
                _addressText.Text = "Unable to determine the address. Try again in a few minutes.";
            }
        }

        void btnSaveAddress_OnClick(object sender, EventArgs e)
        {
            if (_addressText.Text == "Address (when available)")
            {
                Toast.MakeText(this, "Unable to save location", ToastLength.Short).Show();
            }
            else if (_addressText.Text == "Can't determine the current address. Try again in a few minutes.")
            {
                Toast.MakeText(this, "Unable to save location", ToastLength.Short).Show();
            }
            else
            {
                var result = dataModel.InsertAddress(_addressText.Text);
                Toast.MakeText(this, result, ToastLength.Short).Show();
            }
        }

        void btnDeleteAddress_OnClick(object sender, EventArgs e)
        {
            var result = dataModel.DeleteLocation();
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }

        void btnShowAddress_OnClick(object sender, EventArgs e)
        {
            savedAddress.Text = dataModel.GetLocation();
        }
    }
}