﻿using cortanarecipes.Helpers;
using cortanarecipes.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cortanarecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipesListPage : BasePage
    {

        RecipesListViewModel viewModel;

        public RecipesListPage()
        {
            InitializeComponent();

            viewModel = new RecipesListViewModel();
            BindingContext = viewModel;

        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.RefreshRecipesList();

        }
    }
}
