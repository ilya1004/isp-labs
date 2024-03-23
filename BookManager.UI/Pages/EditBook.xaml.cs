using BookManager.UI.ViewModels;

namespace BookManager.UI.Pages;

public partial class EditBook : ContentPage
{
	public EditBook(EditBookViewModel editBookViewModel)
	{
		InitializeComponent();

		BindingContext = editBookViewModel;
	}
}