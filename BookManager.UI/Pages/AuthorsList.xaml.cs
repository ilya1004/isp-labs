using BookManager.UI.ViewModels;

namespace BookManager.UI.Pages;

public partial class AuthorsList : ContentPage
{
	public AuthorsList(AuthorsListViewModel authorsListViewModel)
	{
		InitializeComponent();

		BindingContext = authorsListViewModel;
	}
}