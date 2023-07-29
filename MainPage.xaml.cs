using ColorUtility;
using System.Runtime.InteropServices;

namespace CodeQuotes;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

    List<string> quotes = new();


	protected override async void OnAppearing()
	{
		base.OnAppearing();
		await LoadMauiAsset();
	}

	async Task LoadMauiAsset()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
        using var reader = new StreamReader(stream);

		//while the reader can still read (the read method does not return a -1).. while there is still a line to read, or is not prohibited
		while (reader.Peek() != -1)            //the peek method returns the next character but does not consume it
		{
			quotes.Add(reader.ReadLine());
		}
    }

    Random random = new Random();

	private void generateQuoteButton_Clicked(object sender, EventArgs e)
	{ 
		// the colors we'll need to provide for start and end colors for the ColorUtility class
		var startColor = System.Drawing.Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));

		var endColor = System.Drawing.Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));


		//generates gradient colors for us, within a range, and how many shades we want
		var colors = ColorUtility.ColorControls.GetColorGradient(startColor, endColor, 7);

		//a collection of gradient stops. We'll add the above colors generated gradients to it for use
		var stops = new GradientStopCollection();

		var stopOffset = 0f;

		foreach (var c in colors)
		{
			stops.Add(new GradientStop(Color.FromArgb(c.Name), stopOffset));

			stopOffset += .2f; //the offset is incremented by 0.2 each time, so our gradient looks dynamic
		}

		//finally, we generate the gradient..
		var gradient = new LinearGradientBrush(stops, new Point(0,0), new Point(1,1));

		//then change the background color of our page, to the gradients..
		pageBackground.Background = gradient;


		//create a random number, within 1 and the number of lines in our quotes list
		int index = random.Next(quotes.Count);

		//change the text in the label to any quote in a random line in the quotes list ~ a random quote
		quotesLabel.Text = quotes[index];
    }
}

