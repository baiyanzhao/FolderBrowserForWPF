using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Interop
{
    internal static class ErrorHelper
    {
        private const int FACILITY_WIN32 = 7;
        
        internal const int IGNORED = (int)HRESULT.S_OK;

        // From macro in winerror.h:
        // #define __HRESULT_FROM_WIN32(x) 
        //     ((HRESULT)(x) <= 0 ? ((HRESULT)(x)) : ((HRESULT) (((x) & 0x0000FFFF) | (FACILITY_WIN32 << 16) | 0x80000000)))
        internal static int HResultFromWin32(int win32ErrorCode)
        {
            if (win32ErrorCode > 0)
            {
                win32ErrorCode =
                    (int)((win32ErrorCode & 0x0000FFFF) | (FACILITY_WIN32 << 16) | 0x80000000);
            }
            return win32ErrorCode;

        }

        internal static int HResultFromWin32(Win32ErrorCode error)
        {
            return HResultFromWin32((int)error);
        }

        internal static bool Matches(int hresult, Win32ErrorCode win32ErrorCode)
        {
            return (hresult == HResultFromWin32(win32ErrorCode));
        }
    }

    // Win32 error codes
    internal enum Win32ErrorCode
    {
        ERROR_CANCELLED = 1223
    }

    internal enum HRESULT : long
    {
        S_FALSE = 0x0001,
        S_OK = 0x0000,
        E_INVALIDARG = 0x80070057,
        E_OUTOFMEMORY = 0x8007000E
    }


    
}
