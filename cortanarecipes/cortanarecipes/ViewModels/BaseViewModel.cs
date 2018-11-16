using cortanarecipes.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace cortanarecipes.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        // indicador de atividade
        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            // atualiza o valor
            set { SetProperty(ref _isBusy, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        public async Task PushAsync<TViewModel>(params object[] args) where TViewModel : BaseViewModel
        {
            var pastaview = "Views";
            var sufixoview = "Page";
            var pastaviewmodels = "ViewModels";

            var viewModelType = typeof(TViewModel);
            var viewModelTypeName = viewModelType.Name;
            var viewModelWordLength = "ViewModel".Length;
            var viewTypeName = $"{pastaview}.{viewModelTypeName.Substring(0, viewModelTypeName.Length - viewModelWordLength)}{sufixoview}";
            var viewType = Type.GetType(viewModelType.Namespace.Replace(pastaviewmodels, "") + viewTypeName);

            if (viewType == null)
            {
                return;
            }

            var page = Activator.CreateInstance(viewType,args) as Page;

            var viewModel = Activator.CreateInstance(viewModelType, args);
            if (page != null)
            {
                page.BindingContext = viewModel;
            }
            // se master detail
            if (Application.Current.MainPage is MasterDetailPage masterDetailPage)
            {
                await masterDetailPage.Detail.Navigation.PushAsync(page);
            }
            // se navegacao simples
            else
            {
                await Application.Current.MainPage.Navigation.PushAsync(page);
            }
        }

        public virtual Task LoadAsync()
        {
            return Task.FromResult(0);
        }

        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task DisplayAlert(string title, string message, string accept, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }
    }
}
