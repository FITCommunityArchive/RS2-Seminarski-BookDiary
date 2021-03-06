﻿using BookDiary.Mobile.Models;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace BookDiary.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Books, Title="Books" },
                new HomeMenuItem {Id = MenuItemType.CurrentlyReading, Title="My Reading List" },
                new HomeMenuItem {Id = MenuItemType.History, Title="My History" },
                new HomeMenuItem {Id = MenuItemType.Trending, Title="Trending" }
            };

            ListViewMenu.ItemsSource = menuItems;

            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}