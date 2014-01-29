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
using Microsoft.WindowsAzure.MobileServices;
using System.Net.Http;
using Android.Webkit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvolveListView
{
    [Activity(Label = "Login")]
    public class ActivityLogin : Activity
    {
        private MobileServiceClient client; // Mobile Service Client reference
        private MobileServiceUser user; // Mobile Service logged in user
        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // set our layout to be the home screen
           // this.SetContentView(Resource.Layout.login);

            //var web = FindViewById<WebView>(Resource.Id.aboutwebview);
            //web.LoadUrl("file:///android_asset/about.html");
           // web.LoadUrl("https://lruvalcontosolife.azurewebsites.net/");

            //C1


      client = new MobileServiceClient(
                    Constants.ApplicationURL,
                    Constants.ApplicationKey);

                await Authenticate();
     

            
        }


        private async Task Authenticate()
        {
            try
            {
                user = await client.LoginAsync(this, "aad");
                CreateAndShowDialog(string.Format("you are now logged in - {0}", user.UserId), "Logged in!");
            }
            catch (Exception ex)
            {
                CreateAndShowDialog(ex, "Authentication failed");
            }
        }
        void CreateAndShowDialog(Exception exception, String title)
        {
            CreateAndShowDialog(exception.Message, title);
            var intent = new Intent(this, typeof(ActivityMain));
            StartActivity(intent);
        }

        void CreateAndShowDialog(string message, string title)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);

            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();
        }

      
                  }

}

