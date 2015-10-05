using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LocationHelper
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage : Page
	{
		public MainPage()
		{
			this.InitializeComponent();
		}

		//Detect enter key to press button
		private async void enterDown(object sender, KeyRoutedEventArgs e)
		{

			if (e.Key == Windows.System.VirtualKey.Enter)
			{
				searchButton_Click(sender, e);
			}
		}
		// Search button click event. Calls method to grab and set data to xaml view
		private void searchButton_Click(object sender, RoutedEventArgs e)
		{
			getGeo(SearchText.Text);
		}

		//Gets all the location data and sets the textblocks of xaml to said data
		private async void getGeo(string location)
		{
			try
			{
				HttpClient client = new HttpClient();
				var data = await client.GetStringAsync(string.Format("http://api.geonames.org/searchJSON?q={0}&maxRows=10&username=pandazzz", location));
				GeoData.Rootobject rootObject = JsonConvert.DeserializeObject<GeoData.Rootobject>(data);

				if (rootObject.totalResultsCount == 0)
				{
					var noResult = new Windows.UI.Popups.MessageDialog("No results. Please search for something else");
					await noResult.ShowAsync();
				}

				Name1.Text = rootObject.geonames[0].toponymName;
				Name2.Text = rootObject.geonames[1].toponymName;
				Name3.Text = rootObject.geonames[2].toponymName;
				Name4.Text = rootObject.geonames[3].toponymName;
				Name5.Text = rootObject.geonames[4].toponymName;
				Name6.Text = rootObject.geonames[5].toponymName;
				Name7.Text = rootObject.geonames[6].toponymName;
				Name8.Text = rootObject.geonames[7].toponymName;
				Name9.Text = rootObject.geonames[8].toponymName;
				Name10.Text = rootObject.geonames[9].toponymName;

				Code1.Text = rootObject.geonames[0].countryCode;
				Code2.Text = rootObject.geonames[1].countryCode;
				Code3.Text = rootObject.geonames[2].countryCode;
				Code4.Text = rootObject.geonames[3].countryCode;
				Code5.Text = rootObject.geonames[4].countryCode;
				Code6.Text = rootObject.geonames[5].countryCode;
				Code7.Text = rootObject.geonames[6].countryCode;
				Code8.Text = rootObject.geonames[7].countryCode;
				Code9.Text = rootObject.geonames[8].countryCode;
				Code10.Text = rootObject.geonames[9].countryCode;

				Country1.Text = rootObject.geonames[0].countryName;
				Country2.Text = rootObject.geonames[1].countryName;
				Country3.Text = rootObject.geonames[2].countryName;
				Country4.Text = rootObject.geonames[3].countryName;
				Country5.Text = rootObject.geonames[4].countryName;
				Country6.Text = rootObject.geonames[5].countryName;
				Country7.Text = rootObject.geonames[6].countryName;
				Country8.Text = rootObject.geonames[7].countryName;
				Country9.Text = rootObject.geonames[8].countryName;
				Country10.Text = rootObject.geonames[9].countryName;

				Pop1.Text = rootObject.geonames[0].population.ToString();
				Pop2.Text = rootObject.geonames[1].population.ToString();
				Pop3.Text = rootObject.geonames[2].population.ToString();
				Pop4.Text = rootObject.geonames[3].population.ToString();
				Pop5.Text = rootObject.geonames[4].population.ToString();
				Pop6.Text = rootObject.geonames[5].population.ToString();
				Pop7.Text = rootObject.geonames[6].population.ToString();
				Pop8.Text = rootObject.geonames[7].population.ToString();
				Pop9.Text = rootObject.geonames[8].population.ToString();
				Pop10.Text = rootObject.geonames[9].population.ToString();


			}
			catch (Exception e)
			{

			}
		}
	}

	// All in one file. Can be put in another file later for eaiser readability. Do later
}
