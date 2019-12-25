using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using Interop;

namespace FolderBrowserForWPF
{
	public class Dialog
	{
		#region Public API
		public string Title { get; set; }

		/// <summary>
		/// set,InitialDirectory; get,Folder
		/// </summary>
		public string FileName { get; set; }

		public bool? ShowDialog()
		{
			var openDialogCoClass = new INativeFileOpenDialog(); // Template method to allow derived dialog to create actual specific COM coclass (e.g. FileOpenDialog or FileSaveDialog)
			try
			{
				ApplyNativeSettings(openDialogCoClass); // Apply outer properties to native dialog instance
				var parentWindow = Helpers.GetDefaultOwnerWindow();
				int hresult = openDialogCoClass.Show(GetHandleFromWindow(parentWindow));
				if(ErrorHelper.Matches(hresult, Win32ErrorCode.ERROR_CANCELLED)) // Create return information
					return false;

				openDialogCoClass.GetResults(out var resultsArray);
				resultsArray.GetCount(out var count);
				if(count > 0)
				{
					resultsArray.GetItemAt(0, out var shellItem);
					shellItem.GetDisplayName(NativeMethods.SIGDN.SIGDN_DESKTOPABSOLUTEPARSING, out var file);
					FileName = file;
				}
				return true;
			}
			finally
			{
				Marshal.ReleaseComObject(openDialogCoClass);
			}
		}
		#endregion

		#region Helpers
		private void ApplyNativeSettings(IFileDialog dialog)
		{
			dialog.SetTitle(Title);
			dialog.SetOptions(NativeMethods.FOS.FOS_NOTESTFILECREATE | NativeMethods.FOS.FOS_FORCEFILESYSTEM | NativeMethods.FOS.FOS_PICKFOLDERS);  // Apply option bitflags

			string directory = string.IsNullOrEmpty(FileName) ? null : System.IO.Path.GetDirectoryName(FileName);
			if(directory != null)
			{
				try
				{
					SHCreateItemFromParsingName(directory, IntPtr.Zero, new System.Guid(IIDGuid.IShellItem), out var folder);
					if(folder != null)
						dialog.SetFolder(folder);

					dialog.SetFileName(System.IO.Path.GetFileName(FileName));
				}
				catch
				{ }
			}
		}

		private IntPtr GetHandleFromWindow(Window window)
		{
			if(window == null)
				return NativeMethods.NO_PARENT;
			return (new WindowInteropHelper(window)).Handle;
		}

		[DllImport("shell32.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
		private static extern void SHCreateItemFromParsingName([In, MarshalAs(UnmanagedType.LPWStr)] string pszPath, [In] IntPtr pbc, [In, MarshalAs(UnmanagedType.LPStruct)] Guid iIdIShellItem, [Out, MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out IShellItem iShellItem);
		#endregion
	}
}
