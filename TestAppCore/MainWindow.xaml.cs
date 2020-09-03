using System.Windows;

namespace TestAppCore
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var dlg = new FolderBrowserForWPF.Dialog();
			if(dlg.ShowDialog() == true)
			{
				DirText.Text = dlg.FileName;
			}
		}
	}
}
