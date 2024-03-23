using BookManager.UI.ViewModels;

namespace BookManager.UI.Pages;

public partial class BookDetails : ContentPage
{
	public BookDetails(BookDetailsViewModel bookDetailsViewModel)
	{
		InitializeComponent();

		BindingContext = bookDetailsViewModel;
	}
}