using System;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Reflection;

namespace Script.FileManage
{
    public class CsvReader
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr _lopen(string lpPathName, int iReadWrite);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);
        
        public const int OF_READWRITE = 2;
        public const int OF_SHARE_DENY_NONE = 0x40;
        public static readonly IntPtr HFILE_ERROR = new IntPtr(-1);

        public static List<T> CSVToList<T>(string filePath) where T:class, new()
        {
            return FileSet.DataTableToList<T>(FileSet.ReadCsvFile(filePath));
        }
        
        /// <summary>
        /// 检查文件是否存在以及是否被占用
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <param name="msg">返回消息</param>
        /// <returns>0：没被占用 1：文件不存在 2：被占用</returns>
        public static int CheckFileStates(string fileName, out string msg)
        {
            msg = "文件没被占用!";
            if (!File.Exists(fileName))
            {
                msg = "文件不存在";
                return 1;
            }
            IntPtr vHandle = _lopen(fileName, OF_READWRITE | OF_SHARE_DENY_NONE);
            if (vHandle == HFILE_ERROR)
            {
                msg = "文件被占用!";
                return 2;
            }
            CloseHandle(vHandle);
            return 0;
        }
    }
}