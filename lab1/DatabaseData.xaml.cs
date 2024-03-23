using System.Reflection.PortableExecutable;
//using AndroidX.ConstraintLayout.Core.Widgets.Analyzer;
using lab1.Entities;
using lab1.Services;

namespace lab1;

public partial class DatabaseData : ContentPage
{
    private List<Group>? _listGroups = null;
    private List<Song>? _listSongs = null;
    private IDbService? _database = null;

    public DatabaseData()
    {
        InitializeComponent();
        _database = MauiProgram.database;

        //var settingsService = this.Handler.MauiContext.Services.GetServices<IDbService>();

        _listGroups = new List<Group>();
        _listSongs = new List<Song>();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (_listGroups?.Count == 0 && _listSongs?.Count == 0)
        {
            _listGroups = (List<Group>)_database.GetAllGroups();
            for (var i = 0; i < _listGroups.Count; i++)
            {
                _listSongs.AddRange(_database.GetSongsByGroup(i + 1));
            }
        }

        foreach (var group in _listGroups)
        {
            PickerGroups.Items.Add(group.GroupName);
        }
    }

    void PickerSelectedIndexChanged(object sender, EventArgs e)
    {
        string groupName = PickerGroups.Items[PickerGroups.SelectedIndex];
        var list = new List<SongForList>();
        for (var i = 0; i < _listSongs.Count; i++)
        {
            if (_listSongs[i].GroupName == groupName)
            {
                list.Add(new SongForList { 
                    SongName = _listSongs[i].SongName, 
                    PublicationYear = _listSongs[i].PublicationYear 
                });
            }
        }
        ListSongs.ItemsSource = list;
    }
}