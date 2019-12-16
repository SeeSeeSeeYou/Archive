using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ScanArchiving
{
     public class HttpServerHelper
    { 
        [DllImport(@"DllCodesign.dll", EntryPoint = "C_DownloadFile", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern bool DownLoadFile([MarshalAs(UnmanagedType.LPWStr)] string remote, [MarshalAs(UnmanagedType.LPWStr)] string local);

        [DllImport(@"DllCodesign.dll", EntryPoint = "C_UploadFile", ExactSpelling = false, CallingConvention = CallingConvention.StdCall)]
        public static extern bool UpLoadFile([MarshalAs(UnmanagedType.LPWStr)] string local, [MarshalAs(UnmanagedType.LPWStr)] string remote);
    }
}
