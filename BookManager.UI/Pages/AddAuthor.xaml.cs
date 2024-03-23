using BookManager.UI.ViewModels;

namespace BookManager.UI.Pages;

public partial class AddAuthor : ContentPage
{
	public AddAuthor(AddAuthorViewModel addAuthorViewModel)
	{
		InitializeComponent();

        BindingContext = addAuthorViewModel;
    }
}