using MaterialDesignThemes.Wpf;
using Moodify.ViewModel;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace Moodify.View
{
	/// <summary>
	/// Interaction logic for CreatePlaylist.xaml
	/// </summary>
	public partial class CreatePlaylistView : Window
	{
		private CreatePlaylistVM createPlaylistVM;

		public CreatePlaylistView()
		{
			InitializeComponent();
			this.createPlaylistVM = new CreatePlaylistVM();
			this.DataContext = this.createPlaylistVM;
		}

		/// <summary>
		/// Handle submit click button
		/// the function parse all the user inputs and check if they are valid.
		/// </summary>
		private void SubmitClick(object sender, RoutedEventArgs e)
		{
			int i = 0;
			var dialogContent = new TextBlock
			{
				Margin = new Thickness(80),
				FontSize = 25
			};
			try
			{
				Tuple<float, float> t = GetValues(tempoMax.Text, tempoMin.Text, 262, 0);
				float tMax = t.Item1;
				float tMin = t.Item2;
				i++;
				t = GetValues(popularityMax.Text, popularityMin.Text, 100, 0);
				float pMax = t.Item1;
				float pMin = t.Item2;
				i++;
				t = GetValues(loudnessMax.Text, loudnessMin.Text, 1, -52);
				float lMax = t.Item1;
				float lMin = t.Item2;

				createPlaylistVM.VM_TempoMax = tMax;
				createPlaylistVM.VM_TempoMin = tMin;
				createPlaylistVM.VM_PopularityMax = pMax;
				createPlaylistVM.VM_PopularityMin = pMin;
				createPlaylistVM.VM_LoudnessMax = lMax;
				createPlaylistVM.VM_LoudnessMin = lMin;

				// ask from the VM to generate a new playlist
				this.createPlaylistVM.GenerateCustomPlaylist();
				this.Close();
				ShowSongsView songsView = new ShowSongsView(-1);
				songsView.ShowDialog();
			}
			//if exception is thrown, the window will show the error
			catch (ArgumentException ex)
			{
				dialogContent.Text = ex.Message + FromIndexToValue(i);
				object x = DialogHost.Show(dialogContent);
			}
			catch
			{
				dialogContent.Text = "Error parsing values from items: " + FromIndexToValue(i);
				object x = DialogHost.Show(dialogContent);
			}

		}

		/// <summary>
		/// Froms the index to value where was the error.
		/// </summary>
		/// <param name="i">The index of the current check</param>
		/// <returns></returns>
		private string FromIndexToValue(int i)
		{
			if(i== 0)
			{
				return "Tempo";
			} else if (i == 1)
			{
				return "Popularity";
			} else if (i == 2)
			{
				return "Loudness";
			}
			else
			{
				return "unknown";
			}
		}

		/// <summary>
		/// Gets the values from string given by the users and parse them.
		/// </summary>
		/// <param name="textMax">The value given in maximum text box</param>
		/// <param name="textMin">The value given in minimum text box</param>
		/// <param name="maxValue">The maximum value allowed</param>
		/// <param name="minValue">The minimum value allowed</param>
		/// <returns></returns>
		/// <exception cref="ArgumentException">
		/// Error: maximum value is lower than minimum value given:
		/// or
		/// Error: maximum value is higher than minimum value allowed:
		/// or
		/// Error: minimum value is lower than minimum value allowed:
		/// </exception>
		private Tuple<float, float> GetValues(string textMax, string textMin, float maxValue, float minValue)
		{
			float min = float.Parse(textMin, CultureInfo.InvariantCulture.NumberFormat);
			float max = float.Parse(textMax, CultureInfo.InvariantCulture.NumberFormat);
			if (max < min)
			{
				throw new ArgumentException("Error: maximum value is lower than minimum value given: ");
			}
			if (max > maxValue)
			{
				throw new ArgumentException("Error: maximum value is higher than minimum value allowed: ");
			}
			if (min < minValue)
			{
				throw new ArgumentException("Error: minimum value is lower than minimum value allowed: ");
			}

			return Tuple.Create(max, min);
		}

		/// <summary>
		/// Close the window and cancel the custom process.
		/// </summary>
		private void CancelClick(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
