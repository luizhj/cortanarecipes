﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using cortanarecipes.ViewModels;

namespace cortanarecipes.Views : BasePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstructionPage : ContentPage
    {
        InstructionViewModel ViewModel = new InstructionViewModel();

        public InstructionPage()
        {
            InitializeComponent();

            BindingContext = ViewModel;
        }
    }
}
