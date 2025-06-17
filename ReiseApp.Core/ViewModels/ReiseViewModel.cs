using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ReiseApp.Data.Models;
using ReiseApp.Data.Services;
using ReiseApp.Core.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;

namespace ReiseApp.Core.ViewModels;

public partial class ReiseViewModel : ObservableObject
{
    private readonly IRepository _repository;
    private bool IsLoaded = false;

    [ObservableProperty]
    private Reise? _selectedReise = null;

    [ObservableProperty]
    private ObservableCollection<Reise> _reise = new ObservableCollection<Reise>();

    // Aufgabe 1
    //[ObservableProperty]
    //private int _anzahlReisen = 0;

    //Aufgabe 2 mit Multibinder
    //[ObservableProperty]
    //private string _multitext = string.Empty;
    public ReiseViewModel(IRepository repository)
    {
        _repository = repository;

        WeakReferenceMessenger.Default.Register<ReiseMessages>(this, (r, m) =>
        {
            // Neue Reise aus der Nachricht hinzufügen
            Reise.Add(m.Value);
        });
    }

    [RelayCommand]
    public void Load()
    {
        if (!IsLoaded)
        {
            var reise = _repository.All();
         
            foreach (var reisen in reise)
            {
                Reise.Add(reisen);
            }
            IsLoaded = true;

            
        }
    }

    [RelayCommand]
    public void AddReise(Reise neueReise)
    {
        if (_repository.Insert(neueReise))
        {
            Reise.Add(neueReise);
            // Aufgabe 1
           // AnzahlReisen = Reise.Count();
            WeakReferenceMessenger.Default.Send(new ReiseRefresh("refresh"));
        }
    }

    [RelayCommand]
    public void Delete(Reise reise)
    {
        if (reise != null && _repository.Delete(reise))
        {
            Reise.Remove(reise);
            // Aufgabe 1
           // AnzahlReisen = Reise.Count();
            WeakReferenceMessenger.Default.Send(new ReiseRefresh("refresh"));
        }
    }



    [RelayCommand]
    public void DeleteAll()
    {
        if (_repository.DeleteAll())
        {
            Reise.Clear();
            //Aufgabe 1
            //_anzahlReisen = 0;
            WeakReferenceMessenger.Default.Send(new ReiseRefresh("refresh"));
        }
    }
    //Aufgabe 2 mit Multibinder
    /* private void UpdateAnzeigeText()
     {
         if (SelectedReise != null)
         {
             Multitext = $"{SelectedReise.Ort} – {SelectedReise.Datum:dd.MM.yyyy}";
         }
         else
         {
             Multitext = string.Empty;
         }
     }
    partial void OnSelectedReiseChanged(Reise? value)
 {
     UpdateAnzeigeText();
 }

    */


}
