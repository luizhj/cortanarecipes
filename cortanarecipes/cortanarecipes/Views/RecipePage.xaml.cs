﻿using cortanarecipes.Models;
using cortanarecipes.ViewModels;
using Xamarin.Forms.Xaml;

namespace cortanarecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : BasePage
    {

        RecipeViewModel viewModel;

        public RecipePage()
        {
            InitializeComponent();

            viewModel = new RecipeViewModel();
            BindingContext = viewModel;

            ToolbarItems.Remove(TollbarItemIngredientsList);
            ToolbarItems.Remove(TollbarItemInstructionsList);
        }

        public RecipePage(Recipe _recipe)
        {
            InitializeComponent();

            viewModel = new RecipeViewModel(_recipe);
            BindingContext = viewModel;

        }

    }
}
