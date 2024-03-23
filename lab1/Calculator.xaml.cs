using Microsoft.Maui.Layouts;
using System.Collections.Specialized;

namespace lab1;

public partial class Calculator : ContentPage
{
	double currNumber = 0;
	double memNumber = 0;
	bool isError = false;
	bool isBinaryOper = false;
	int binOperIndex = 0;

	public Calculator()
	{
		InitializeComponent();
	}

	private void OnNumberClicked(object sender, EventArgs e)
	{
		Button? button = (Button?)sender;

		if (Result.Text.Length < 10)
		{
			if (Double.TryParse(Result.Text, out currNumber))
			{
				if (currNumber == 0 && !Result.Text.Contains('.'))
				{
					Result.Text = button?.Text;
					return;
				}
			}
			else
			{
				Result.Text = "Error";
				return;
			}
			Result.Text += button?.Text;
		}
	}

	private void OnOperationClicked(object sender, EventArgs e)
	{
		Button? button = (Button?)sender;

		if (isError && button?.Text != "C")
		{
			return;
		}
		
		if (button?.Text == "Площадь круга")
		{
			try
			{
				Double.TryParse(Result.Text, out currNumber);
			}
			catch
			{
				Result.Text = "Error";
				isError = true;
				return;
			}
			Result.Text = Convert.ToString(Math.PI * Math.Pow(currNumber, 2));
		}
		else if (button?.Text == "C")
		{
			Result.Text = "0";
			isError = false;
			isBinaryOper = false;
			binOperIndex = 0;
		}
		else if (button?.Text == "Bcksp")
		{
			String tempStr = Result.Text;
			if (Result.Text.Length > 1)
			{
				Result.Text = tempStr.Substring(0, tempStr.Length - 1);
			}
			else
			{
				Result.Text = "0";
			}
		}
		else if (button?.Text == "1/x")
		{
			if (Result.Text == "0")
			{
				Result.Text = "Error";
				isError = true;
			}
			else
			{
				try
				{
					Double.TryParse(Result.Text, out currNumber);
				}
				catch
				{
					Result.Text = "Error";
					isError = true;
					return;
				}
				Result.Text = Convert.ToString(1 / currNumber);
			}
		}
		else if (button?.Text == "sq2")
		{
			try
			{
				currNumber = Double.Parse(Result.Text);
			}
			catch
			{
				Result.Text = "Error";
				isError = true;
				return;
			}
			Result.Text = Math.Pow(currNumber, 2).ToString();
		}
		else if (button?.Text == "sqrt2")
		{
			try
			{
				Double.TryParse(Result.Text, out currNumber);
			}
			catch
			{
				Result.Text = "Error";
				isError = true;
				return;
			}
			if (currNumber < 0)
			{
				Result.Text = "Error";
				isError = true;
				return;
			}
			Result.Text = Math.Sqrt(currNumber).ToString();
		}
		else if (button?.Text == "/" || button?.Text == "X" || button?.Text == "-" || button?.Text == "+")
		{
			try
			{
				Double.TryParse(Result.Text, out currNumber);
			}
			catch
			{
				Result.Text = "Error";
				isError = true;
				return;
			}
			memNumber = currNumber;
			switch (button?.Text)
			{
				case "/":
					binOperIndex = 1;
					break;
				case "X":
					binOperIndex = 2;
					break;
				case "-":
					binOperIndex = 3;
					break;
				case "+":
					binOperIndex = 4;
					break;
			}
			Result.Text = "0";
			isBinaryOper = true;
		}
		else if (button?.Text == ".")
		{
			try
			{
				Double.TryParse(Result.Text, out currNumber);
			}
			catch
			{
				Result.Text = "Error";
				isError = true;
				return;
			}
			var count = 0;
			for (var i = 0; i < Result.Text.Length; i++)
			{
				if (Result.Text[i] == '.')
				{
					count++;
				}
			}
			if (count == 0)
			{
				Result.Text += ".";
			}
			
		}
		else if (button?.Text == "+/-")
		{
			try
			{
				Double.TryParse(Result.Text, out currNumber);
			}
			catch
			{
				Result.Text = "Error";
				isError = true;
				return;
			}
			if (currNumber > 0)
			{
				Result.Text = "-" + Result.Text;
			} else if (currNumber < 0)
			{
				Result.Text = Result.Text.Substring(1);
			}
			
		}

	}

	private void OnEnterClicked(object sender, EventArgs e)
	{
		if (isBinaryOper)
		{
			switch (binOperIndex)
			{
				case 1:
					try
					{
						Double.TryParse(Result.Text, out currNumber);
					}
					catch
					{
						Result.Text = "Error";
						isError = true;
						return;
					}
					if (currNumber == 0)
					{
						Result.Text = "Error";
						isError = true;
						return;
					}
					Result.Text = Convert.ToString(memNumber / currNumber);
					break;

				case 2:
					try
					{
						Double.TryParse(Result.Text, out currNumber);
					}
					catch
					{
						Result.Text = "Error";
						isError = true;
						return;
					}
					Result.Text = Convert.ToString(memNumber * currNumber);
					break;

				case 3:
					try
					{
						Double.TryParse(Result.Text, out currNumber);
					}
					catch
					{
						Result.Text = "Error";
						isError = true;
						return;
					}
					Result.Text = Convert.ToString(memNumber - currNumber);
					break;

				case 4:
					try
					{
						Double.TryParse(Result.Text, out currNumber);
					}
					catch
					{
						Result.Text = "Error";
						isError = true;
						return;
					}
					Result.Text = Convert.ToString(memNumber + currNumber);
					break;
			}
		}
	}
}