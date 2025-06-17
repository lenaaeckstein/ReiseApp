using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ReiseApp.Core.Messages;
using ReiseApp.Data.Models;
using ReiseApp.Data.Services;
using System;

namespace ReiseApp.Core.ViewModels
{
    public partial class AddPageViewModel : ObservableObject
    {
        private readonly IRepository _repository;

        [ObservableProperty]
        private DateTime _selectedDate = DateTime.Now;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private string _ort = string.Empty;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(SaveCommand))]
        private string _nachname = string.Empty;

        public AddPageViewModel(IRepository repository)
        {
            _repository = repository;
        }

        private bool CanSave => !string.IsNullOrWhiteSpace(Ort) && !string.IsNullOrWhiteSpace(Nachname);

       
       [RelayCommand(CanExecute = nameof(CanSave))]
        private void Save()
        {
            var date = new DateOnly(SelectedDate.Year, SelectedDate.Month, SelectedDate.Day);
            var reise = new Reise(date, Ort, Nachname);
            _repository.Insert(reise);

            // Nachricht senden, dass sich Daten geändert haben
            WeakReferenceMessenger.Default.Send(new ReiseMessages(reise));

            // Felder zurücksetzen
            SelectedDate = DateTime.Now;
            Ort = string.Empty;
            Nachname = string.Empty;
        }


    }
}
