using System.Windows;

namespace TestApp
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
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