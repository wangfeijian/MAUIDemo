namespace Exercise1;

public partial class MainPage : ContentPage
{
	string _fileName = Path.Combine(FileSystem.AppDataDirectory, "note.txt");
	public MainPage()
	{
		InitializeComponent();

		if(File.Exists(_fileName))
		{
			editor.Text = File.ReadAllText(_fileName);
		}
	}

	private void OnSaveButtonClicked(object sender, EventArgs e)
	{

	}

	private void OnDeleteButtonClicked(object sender, EventArgs e)
	{

	}
}

