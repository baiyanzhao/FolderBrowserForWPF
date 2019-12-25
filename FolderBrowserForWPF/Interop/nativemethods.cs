using System;
using System.Runtime.InteropServices;

namespace Interop
{
	internal static class NativeMethods
	{
		#region General Definitions

		// Various helper constants
		internal static IntPtr NO_PARENT = IntPtr.Zero;

		// Various important window messages
		internal const int WM_USER = 0x0400;
		internal const int WM_ENTERIDLE = 0x0121;

		// FormatMessage constants and structs
		internal const int FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;

		#endregion


		#region File Operations Definitions
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 4)]
		internal struct COMDLG_FILTERSPEC
		{
			[MarshalAs(UnmanagedType.LPWStr)]
			internal string pszName;
			[MarshalAs(UnmanagedType.LPWStr)]
			internal string pszSpec;
		}

		internal enum FDAP
		{
			BOTTOM = 0x00000000,
			TOP = 0x00000001,
		}

		// wpffb used
		internal enum FDE_SHAREVIOLATION_RESPONSE
		{
			FDESVR_DEFAULT = 0x00000000,
			FDESVR_ACCEPT = 0x00000001,
			FDESVR_REFUSE = 0x00000002
		}

		//wpffb used
		internal enum FDE_OVERWRITE_RESPONSE
		{
			FDEOR_DEFAULT = 0x00000000,
			FDEOR_ACCEPT = 0x00000001,
			FDEOR_REFUSE = 0x00000002
		}

		internal enum SIATTRIBFLAGS
		{
			AND = 0x00000001, // if multiple items and the attirbutes together.
			OR = 0x00000002, // if multiple items or the attributes together.
			APPCOMPAT = 0x00000003, // Call GetAttributes directly on the ShellFolder for multiple attributes
		}

		// wpffb used
		internal enum SIGDN : uint
		{
			NORMALDISPLAY = 0x00000000,           // SHGDN_NORMAL
			PARENTRELATIVEPARSING = 0x80018001,   // SHGDN_INFOLDER | SHGDN_FORPARSING
			DESKTOPABSOLUTEPARSING = 0x80028000,  // SHGDN_FORPARSING
			PARENTRELATIVEEDITING = 0x80031001,   // SHGDN_INFOLDER | SHGDN_FOREDITING
			DESKTOPABSOLUTEEDITING = 0x8004c000,  // SHGDN_FORPARSING | SHGDN_FORADDRESSBAR
			FILESYSPATH = 0x80058000,             // SHGDN_FORPARSING
			URL = 0x80068000,                     // SHGDN_FORPARSING
			PARENTRELATIVEFORADDRESSBAR = 0x8007c001,     // SHGDN_INFOLDER | SHGDN_FORPARSING | SHGDN_FORADDRESSBAR
			PARENTRELATIVE = 0x80080001           // SHGDN_INFOLDER
		}

		//wpffb used
		[Flags]
		internal enum FOS : uint
		{
			OVERWRITEPROMPT = 0x00000002,
			STRICTFILETYPES = 0x00000004,
			NOCHANGEDIR = 0x00000008,
			PICKFOLDERS = 0x00000020,
			FORCEFILESYSTEM = 0x00000040, // Ensure that items returned are filesystem items.
			ALLNONSTORAGEITEMS = 0x00000080, // Allow choosing items that have no storage.
			NOVALIDATE = 0x00000100,
			ALLOWMULTISELECT = 0x00000200,
			PATHMUSTEXIST = 0x00000800,
			FILEMUSTEXIST = 0x00001000,
			CREATEPROMPT = 0x00002000,
			SHAREAWARE = 0x00004000,
			NOREADONLYRETURN = 0x00008000,
			NOTESTFILECREATE = 0x00010000,
			HIDEMRUPLACES = 0x00020000,
			HIDEPINNEDPLACES = 0x00040000,
			NODEREFERENCELINKS = 0x00100000,
			DONTADDTORECENT = 0x02000000,
			FORCESHOWHIDDEN = 0x10000000,
			DEFAULTNOMINIMODE = 0x20000000
		}
		#endregion

		#region KnownFolder Definitions
		// Property System structs and consts
		[StructLayout(LayoutKind.Sequential, Pack = 4)]
		internal struct PROPERTYKEY
		{
			internal Guid fmtid;
			internal uint pid;
		}
		#endregion


		[DllImport("shell32.dll", CharSet = CharSet.Unicode, PreserveSig = false)]
		internal static extern void SHCreateItemFromParsingName([In, MarshalAs(UnmanagedType.LPWStr)] string pszPath, [In] IntPtr pbc, [In, MarshalAs(UnmanagedType.LPStruct)] Guid iIdIShellItem, [Out, MarshalAs(UnmanagedType.Interface, IidParameterIndex = 2)] out IShellItem iShellItem);
	}

}

