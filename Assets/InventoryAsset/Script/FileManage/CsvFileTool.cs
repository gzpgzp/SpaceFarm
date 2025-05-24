using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Reflection;

namespace Script.FileManage
{
    public class FileSet
    {
        public static List<T> DataTableToList<T>(DataTable dt) where T : class, new()
        {
            List<T> ts = new List<T>();
            string tempname = String.Empty;
            
            foreach (DataRow dr in dt.Rows)
            {
                T t = ExtensionClass.ToObject<T>();
                var a = t.GetType();
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    try
                    {
                        tempname = pi.Name;
                        if (dt.Columns.Contains(tempname))
                        {
                            object value = dr[tempname];
                            if (value != DBNull.Value)
                            {
                                if (pi.PropertyType.ToString().ToLower().Contains("bool"))
                                {
                                    value = value.ToString().ToLower() == "true" || value.ToString().ToLower() == "1";
                                }
                                else if (pi.PropertyType.ToString().ToLower().Contains("int"))
                                {
                                    int temp = 0;
                                    value = int.TryParse(value.ToString(), out temp) ? temp : 0;
                                }
                                else if (pi.PropertyType.ToString().ToLower().Contains("float"))
                                {
                                    float temp = 0;
                                    value = float.TryParse(value.ToString(), out temp) ? temp : 0;
                                }
                                else if (pi.PropertyType.ToString().ToLower().Contains("double"))
                                {
                                    double temp = 0;
                                    value = double.TryParse(value.ToString(), out temp) ? temp : 0;
                                }
                                else if (pi.PropertyType.ToString().ToLower().Contains("datetime"))
                                {
                                    DateTime temp;
                                    value = DateTime.TryParse(value.ToString(), out temp) ? temp : DateTime.MinValue;
                                }
                                pi.SetValue(t, value, null);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
                ts.Add(t);
            }

            return ts;
        }
        
        public static DataTable ReadCsvFile(string filePath)
        {
            DataTable table = new DataTable();
            int libeNum = 0;
            using (CsvFileTool tool = new CsvFileTool(filePath, encoding: Encoding.Default))
            {
                CsvRow row = new CsvRow();
                while (tool.ReadRow(row))
                {
                    if (0 == libeNum)
                    {
                        foreach (string s in row)
                        {
                            table.Columns.Add(s.Replace("\"", ""));
                        }
                    }
                    else
                    {
                        int index = 0;
                        DataRow dr = table.NewRow();
                        foreach (string s in row)
                        {
                            dr[index] = s.Replace("\"", "").Trim();
                            index++;
                        }
                        table.Rows.Add(dr);
                    }
                    libeNum++;
                }
            }

            return table;
        }
    }
    
    public static class ExtensionClass
    {
        public static T ToObject<T>() where T : new()
        {
            return CreationObject<T>.New();
        }
    }
    
    public class CsvFileTool:StreamReader
    {
         public CsvFileTool(Stream stream)
            : base(stream)
        {
        }

        public CsvFileTool(string filename)
            : base(filename)
        {
        }
        public CsvFileTool(string filename, Encoding encoding)
    : base(filename, encoding)
        {
        }

        /// <summary>  
        /// Reads a row of data from a CSV file  
        /// </summary>  
        /// <param name="row"></param>  
        /// <returns></returns>  
        public bool ReadRow(CsvRow row)
        {
            row.LineText = ReadLine();
            if (String.IsNullOrEmpty(row.LineText))
                return false;

            int pos = 0;
            int rows = 0;

            while (pos < row.LineText.Length)
            {
                string value;

                if (row.LineText[pos] == '"')
                {
                    pos++;
                    int start = pos;
                    while (pos < row.LineText.Length)
                    {
                        if (row.LineText[pos] == '"')
                        {
                            pos++;
                            if (pos >= row.LineText.Length || row.LineText[pos] != '"')
                            {
                                pos--;
                                break;
                            }
                        }
                        pos++;
                    }
                    value = row.LineText.Substring(start, pos - start);
                    value = value.Replace("\"\"", "\"");
                }
                else
                {
                    int start = pos;
                    while (pos < row.LineText.Length && row.LineText[pos] != ',')
                        pos++;
                    value = row.LineText.Substring(start, pos - start);
                }
                if (rows < row.Count)
                    row[rows] = value;
                else
                    row.Add(value);
                rows++;
                while (pos < row.LineText.Length && row.LineText[pos] != ',')
                    pos++;
                if (pos < row.LineText.Length)
                    pos++;
            }
            while (row.Count > rows)
                row.RemoveAt(rows);
            return (row.Count > 0);
        }
    }
    
    public class CsvRow : List<string>
    {
        public string LineText { get; set; }
    }
}