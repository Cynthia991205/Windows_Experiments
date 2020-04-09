using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows;
using System.Reflection;

namespace ExcelSQL
{
    public class Student
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
    }

    public class Students : List<Student> { }

    public class ExportToExcel<T, U> where T : class where U : List<T>
    {
        public List<T> DataToPrint; // Excel 对象实例. 
        private Excel.Application _excelApp = null;
        private Excel.Workbooks _books = null;
        private Excel._Workbook _book = null;
        private Excel.Sheets _sheets = null;
        private Excel._Worksheet _sheet = null;
        private Excel.Range _range = null;
        private Excel.Font _font = null; 
       
        // 可选 参数 
        private object _optionalValue = Missing.Value; 
        // 生成报表，和其他功能 
        public int GenerateReport() {
            int result = 0;
            try {
                if (DataToPrint != null)
                {
                    if (DataToPrint.Count != 0)
                   {
                        CreateExcelRef();
                        FillSheet();
                        OpenReport();
                    }
                }
            }
            catch (Exception e)
            {
                result = 1; //("Excel导出失敗！\n", e.Message); 
                MessageBox.Show(e.Message.ToString());
            }
            finally
            {
                ReleaseObject(_sheet);
                ReleaseObject(_sheets);
                ReleaseObject(_book);
                ReleaseObject(_books);
                ReleaseObject(_excelApp);
            }
            return result;
        }
        // 展示 Excel 程序
        private void OpenReport()
        {
            _excelApp.Visible = true;
        } 

        private void FillSheet()
        {
            object[] header = CreateHeader();
            WriteData(header);
        } // 将数据写入 Excel sheet 

        private void WriteData(object[] header)
        {
            object[,] objData = new object[DataToPrint.Count, header.Length];

            for (int j = 0; j < DataToPrint.Count; j++)
            {
                var item = DataToPrint[j];
                for (int i = 0; i < header.Length; i++)
                {
                    var y = typeof(T).InvokeMember(header[i].ToString(), 
                        BindingFlags.GetProperty, null, item, null);
                    objData[j, i] = (y == null) ? "" : y.ToString();
                }
            }
            AddExcelRows("A2", DataToPrint.Count, header.Length, objData);
            AutoFitColumns("A1", DataToPrint.Count, header.Length);
        }
        
        // 根据数据拟合列 
        private void AutoFitColumns(string startRange, int rowCount, int colCount)
        {
            _range = _sheet.get_Range(startRange, _optionalValue);
            _range = _range.get_Resize(rowCount, colCount);
            _range.Columns.AutoFit();
        } 
        
        // 根据属性名创建列标题 
        private object[] CreateHeader()
        {
            PropertyInfo[] headerInfo = typeof(T).GetProperties();
            // 为标头创建 Array 
            // 开始从 A1 处添加 
            List<object> objHeaders = new List<object>();
            for (int n = 0; n < headerInfo.Length; n++)
            {
                objHeaders.Add(headerInfo[n].Name);
            }
            var headerToAdd = objHeaders.ToArray();
            AddExcelRows("A1", 1, headerToAdd.Length, headerToAdd);
            SetHeaderStyle();
            return headerToAdd;
        }
       
        // 列标题设置为加粗字体 
        private void SetHeaderStyle()
        {
            _font = _range.Font;
            _font.Bold = true;
        } 

        // 添加行 
        private void AddExcelRows(string startRange, int rowCount, int colCount, object values)
        {
            _range = _sheet.get_Range(startRange, _optionalValue);
            _range = _range.get_Resize(rowCount, colCount);
            _range.set_Value(_optionalValue, values);
        } 

        // 创建 Excel 传递的参数实例
        private void CreateExcelRef()
        {
            _excelApp = new Excel.Application();
            _books = (Excel.Workbooks)_excelApp.Workbooks;
            _book = (Excel._Workbook)(_books.Add(_optionalValue));
            _sheets = (Excel.Sheets)_book.Worksheets;
            _sheet = (Excel._Worksheet)(_sheets.get_Item(1));
        } 

        // 释放未使用的对象 
        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
