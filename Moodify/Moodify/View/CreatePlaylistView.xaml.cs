using MaterialDesignThemes.Wpf;
using Moodify.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
				createPlaylistVM.VM_LoudnessMin = lMax;


				this.createPlaylistVM.GenerateCustomPlaylist();
				this.Close();
				ShowSongsView songsView = new ShowSongsView(-1);
				songsView.ShowDialog();

			}
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

		private void CancelClick(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
