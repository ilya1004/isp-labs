using lab1.Entities;
using lab1.Services;
using System;

namespace lab1;

public partial class CurrencyConverter : ContentPage
{
	IRateService _rateService;
    List <Rate>? ratesList = null;

    public CurrencyConverter(IRateService rateService)
	{
		InitializeComponent();
        _rateService = rateService;
        datePicker.MinimumDate = new DateTime(2000, 1, 1);
        datePicker.MaximumDate = new DateTime(2024, 3, 15);
        ratesList = new List<Rate>();
    }

    private async void ButtonShow_Clicked(object sender, EventArgs e)
    {
        DateTime dateTime = datePicker.Date;
        if (!decimal.TryParse(numberEntry.Text, out decimal number))
        {
            return;
        }
        if (ratesList?.Count == 0)
        {
            ratesList = (List<Rate>?)await _rateService.GetRates(dateTime);
        }
        if (ratesList == null)
        {
            await DisplayAlert("Error", "Ошибка получения данных", "ok");
        }
        if (0 <= pickerCurrency.SelectedIndex && pickerCurrency.SelectedIndex <= 5)
        {
            var res = ratesList[pickerCurrency.SelectedIndex].Cur_Scale * number / ratesList[pickerCurrency.SelectedIndex].Cur_OfficialRate;
            resultLabel.Text = $"{res:F3}";
        }
    }

    private async void PickerCurrency_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ratesList?.Count == 0)
        {
            ratesList = (List<Rate>?)await _rateService.GetRates(datePicker.Date);
        }
        if (ratesList == null)
        {
            await DisplayAlert("Error", "Ошибка получения данных", "ok");
        }
    }

    private async void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        try
        {
            ratesList = (List<Rate>?)await _rateService.GetRates(datePicker.Date);
        }
        catch
        {
            await DisplayAlert("Error", "Ошибка получения данных", "ok");
        }
        
        if (ratesList == null)
        {
            await DisplayAlert("Error", "Ошибка получения данных", "ok");
        }

        var list = new List<string>();
        foreach (var rate in ratesList)
        {
            list.Add($"{rate.Cur_Scale:F0} {rate.Cur_Abbreviation}  =  {rate.Cur_Scale / rate.Cur_OfficialRate:F3} BYN");
        }

        listCur.ItemsSource = list;
    }

}