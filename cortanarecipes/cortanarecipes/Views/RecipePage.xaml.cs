﻿using cortanarecipes.Models;
using cortanarecipes.ViewModels;
using Xamarin.Forms.Xaml;

namespace cortanarecipes.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : BasePage
    {

        RecipeViewModel viewModel;
        private Recipe _recipe;

        public RecipePage()
        {
            InitializeComponent();

            viewModel = new RecipeViewModel();
            BindingContext = viewModel;

            LstIngredients.IsVisible = false;
            LstInstructions.IsVisible = false;

            ToolbarItems.Remove(ToolbarItemNewIngredient);
            ToolbarItems.Remove(ToolbarItemNewInstruction);
            ToolbarItems.Remove(ToolbarItemRemove);
        }

        public RecipePage(Recipe recipe)
        {
            InitializeComponent();

            _recipe = recipe;

            viewModel = new RecipeViewModel(_recipe);
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.RefreshIngredientList();
            viewModel.RefreshInstructionsList();

            if (viewModel.Ingredients != null)
            {
                LstIngredients.IsVisible = viewModel.Ingredients.Count > 0;
            }

            if (viewModel.Instructions != null)
            {
                LstInstructions.IsVisible = viewModel.Instructions.Count > 0;
            }

        }

        private void EntDescription_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {
            EntNote.Focus();
        }

        private void EntNote_Unfocused(object sender, Xamarin.Forms.FocusEventArgs e)
        {

        }
    }
}
