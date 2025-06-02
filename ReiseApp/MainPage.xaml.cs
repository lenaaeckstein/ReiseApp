namespace ReiseApp;

public partial class MainPage : ContentPage
{
    private readonly LocalDBService _dbService;
    private int _editReiseId;

    public MainPage(LocalDBService dBService)
    {
        InitializeComponent();
        _dbService = dBService;
        Task.Run(async () => listView.ItemsSource = await _dbService.GetReise());
        //Task.Run(async ()=> listView.ItemsSource = await _dbService.GetReise();
    }

    private async void saveButton(object sender, EventArgs e)
    {
        if (_editReiseId == 0)
        {
            //add Reise
            await _dbService.Create(new Reise
            {
                Vorname =vornameEntryField.Text,
                Nachname =nachnameEntryField.Text,
                Ort = ortEntryField.Text,
                Datum = datumEntryField.Text
            });
        }
        else
        {
            // edit Reise
            await _dbService.Update(new Reise
            {
                Id = _editReiseId,
                Vorname = vornameEntryField.Text,
                Nachname = nachnameEntryField.Text,
                Ort = ortEntryField.Text,
                Datum = datumEntryField.Text
            });

            _editReiseId = 0;
        }

        vornameEntryField.Text=string.Empty;
        nachnameEntryField.Text = string.Empty;
        ortEntryField.Text= string.Empty;
        datumEntryField.Text= string.Empty;

        listView.ItemsSource = await _dbService.GetReise();
    }
    private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
    { 
        var reise = (Reise)e.Item;
        var action = await DisplayActionSheet("Action", "Cancel", null, "Edit", "Delete");


        switch (action)
        {
            case "Edit":

                _editReiseId = reise.Id;
                vornameEntryField.Text=reise.Vorname;
                nachnameEntryField.Text=reise.Nachname;
                ortEntryField.Text=reise.Ort;
                datumEntryField.Text=reise.Datum;

                break;

            case "Delete":

                await _dbService.Delete(reise);
                listView.ItemsSource = await _dbService.GetReise();

                break;
        }
    }

}
