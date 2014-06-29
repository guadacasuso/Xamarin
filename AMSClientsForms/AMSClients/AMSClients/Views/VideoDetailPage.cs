using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;
using AMSClients.Model;
using AMSClients.Style;

namespace AMSClients.Views
{
    class VideoDetailPage : ContentPage
    {
        readonly ICommand _deleteCommand;
        readonly Video _video;

        public VideoDetailPage(Video video)
        {
            _video = video;

            #region Initialize some properties on the Page
            Padding = new Thickness(20);
            BindingContext = video;
            #endregion


            _deleteCommand = new Command(() =>
            {
                App.Videos.Remove(_video);
                Navigation.PopAsync();
            });



            // Put the two buttons inside a grid
            Grid buttonsLayout = new Grid
                                 {
                                     ColumnDefinitions =
                                     {
                                         new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                                         new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) },
                                     },
                                     Children =
                                     {
                                         { CreateDeleteButton(), 0, 0 },
                                         { CreateSaveButton(), 1, 0 }
                                     }
                                 };

            // Create a grid to hold the Labels & Entry controls.
            Grid inputGrid = new Grid
                             {
                                 ColumnDefinitions =
                                 {
                                     new ColumnDefinition { Width = GridLength.Auto },
                                     new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                                 },
                                 Children =
                                 {
                                     { new Label { Text = "Url:", Font = Fonts.SmallTitle, TextColor = Colours.SubTitle }, 0, 0 },
                                     { CreateEntryFor("Url"), 1, 0}
                                     }
                             };


            // Add the controls to a StackLayout 
            Content = new StackLayout
                      {
                          Children =
                          {
                              inputGrid,
                              buttonsLayout
                          }
                      };
        }

        /// <summary>
        ///   This is the command to invoke when the user wants to delete a video.
        /// </summary>
        /// <value>The delete Video command.</value>
        public ICommand DeleteVideoCommand { get { return _deleteCommand; } }

        /// <summary>
        ///   Create the save button and assing an event handler to the Clicked event.
        /// </summary>
        /// <returns>The save button.</returns>
        View CreateSaveButton()
        {
            Button saveButton = new Button
                                {
                                    Text = "Save",
                                    BorderRadius = 5,
                                    TextColor = Color.White,
                                    BackgroundColor = Colours.BackgroundGrey
                                };

            saveButton.Clicked += async (sender, e) => Navigation.PopAsync();
            return saveButton;
        }


        /// <summary>
        ///   Create the delete button and setup the data binding to invoke the DeleteVideoCommand.
        /// </summary>
        /// <returns>The delete button.</returns>
        View CreateDeleteButton()
        {
            // First create the button.
            Button deleteButton = new Button
                                  {
                                      Text = "Delete",
                                      BorderRadius = 5,
                                      TextColor = Color.White,
                                      BackgroundColor = Colours.NegativeBackground
                                  };

            // Setup data binding.
            deleteButton.SetBinding(Button.CommandProperty, "DeleteVideoCommand");
            deleteButton.BindingContext = this;
            return deleteButton;
        }

        /// <summary>
        ///   Helper method that will create a Xmaarin.Forms Entry control on the screen.
        /// </summary>
        /// <returns>A Xamarin.Forms Entry control.</returns>
        /// <param name="propertyName">The name of the property to bind to.</param>
        View CreateEntryFor(string propertyName)
        {
            Entry input = new Entry
                          {
                              HorizontalOptions = LayoutOptions.FillAndExpand
                          };
            input.SetBinding(Entry.TextProperty, propertyName);
            return input;
        }
    }
}
