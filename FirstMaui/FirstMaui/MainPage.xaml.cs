namespace FirstMaui;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	string translateNumber;

	private void OnTranslate(object sender, EventArgs e)
	{
		string enteredNumber = PhoneNumberText.Text;
		translateNumber = Core.PhonewordTranslator.ToNumber(enteredNumber);

		if (!string.IsNullOrEmpty(translateNumber))
		{
			CallButton.IsEnabled = true;
			CallButton.Text = "Call" + translateNumber;
		}
		else
		{
			CallButton.IsEnabled = false;
			CallButton.Text = "Call";
		}
	}

	async void OnCall(object sender, EventArgs e)
	{
		if(await DisplayAlert("Dial a Number", "Would you like to call " + translateNumber +　"?", "Yes","No"))
		{
			try
			{
				PhoneDialer.Default.Open(translateNumber);
			}
			catch (ArgumentException)
			{
				await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
			}
			catch(FeatureNotSupportedException)
			{
				await DisplayAlert("Unable to dial", "Phone dialing not supported.", "OK");
			}
			catch(Exception)
			{
				await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
			}
		}
	}
}

