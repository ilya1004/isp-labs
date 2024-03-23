using BookManager.UI.ViewModels;

namespace BookManager.UI.Pages;

public partial class AddBook : ContentPage
{
	public AddBook(AddBookViewModel addBookViewModel)
	{
		InitializeComponent();

		BindingContext = addBookViewModel;
	}
}