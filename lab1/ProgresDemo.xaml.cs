namespace lab1;

public partial class ProgresDemo : ContentPage
{
	CancellationTokenSource? cancellationTokenSource = null;

    public ProgresDemo()
	{
		InitializeComponent();
		progresText.BindingContext = progresBar;
		progresText.SetBinding(Label.TextProperty, "Progress", converter: new ProgresBarConventer());
    }

    private async void OnStartClicked(object sender, EventArgs e) 
	{
        if (cancellationTokenSource == null)
        {
            cancellationTokenSource = new CancellationTokenSource();
            try
            {
                labelStatus.Text = "Вычисление...";
                await Task.Run(() =>
                {
                    double h = 0.000_1;
                    int n = 10_000;
                    double s = 0;
                    int q = 0;
                    for (var i = 0; i < n; i++)
                    {
                        if (cancellationTokenSource.Token.IsCancellationRequested)
                        {
                            MainThread.BeginInvokeOnMainThread(() =>
                            {
                                labelStatus.Text = "Задание отменено";
                            });
                            return;
                        }
                        s += Math.Sin((i + 0.5) * h);
                        if (i % 10 == 0)
                        {
                            MainThread.BeginInvokeOnMainThread(() =>
                            {
                                progresBar.Progress = Convert.ToDouble(i) / 10_000;
                                //progresText.Text = $"{Convert.ToDouble(i) / 100}%";
                            });
                        }

                        for (int j = 0; j < 10000; j++)
                        {
                            q = 55 * 55;
                        }
                        cancellationTokenSource.Token.ThrowIfCancellationRequested();
                    }
                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        labelStatus.Text = $"Выполнено. Результат = {s * h}";
                    });
                }, cancellationTokenSource.Token);
            }
            catch (OperationCanceledException)
            {
                labelStatus.Text = "Выполнение было отменено";
            }
            finally
            {
                cancellationTokenSource.Dispose();
                cancellationTokenSource = null;
            }
        }
    }

	private void OnCancelClicked(object sender, EventArgs e)
	{
		cancellationTokenSource!.Cancel();
        //cancellationTokenSource = null;
    }
}