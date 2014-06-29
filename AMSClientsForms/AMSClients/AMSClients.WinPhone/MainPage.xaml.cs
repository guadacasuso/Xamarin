using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Xamarin.Forms;
using AMSClients;
using System.Threading.Tasks;


namespace AMSClients.WinPhone
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            Forms.Init();
            Content = AMSClients.App.GetMainPage().ConvertPageToUIElement(this);

           
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
           UpdateListView();
        }

        public async void UpdateListView()
        {
            var recipes = await new VideosData().GetRecipeDataItemsAsync();
            itemListView.Items.Add(recipes);

           //foreach (var receipe in recipes)
            //{
             //  itemListView.Items.Add(receipe.Title);
          // }

        }

    }
}
