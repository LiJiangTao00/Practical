using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PC.Common.Helpers
{
    public class ExcelOperator
    {
        /// <summary>
        /// 导入excel到DataTable
        /// </summary>
        /// <param name="filePath">文件地址</param>
        /// <param name="success">读取excel文件成功的行号</param>
        /// <param name="fail">读取excel文件失败的行号</param>
        /// <returns>DataTable</returns>
        public static DataTable ImportToDataTable(string filePath, out ICollection<int> success, out ICollection<int> fail)
        {
            success = new List<int>();//成功的行号
            fail = new List<int>();//失败的行号
            DataTable table = new DataTable();
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                IWorkbook workBook = null;
                if (Path.GetExtension(filePath).ToLower() == ".xlsx")
                    workBook = new XSSFWorkbook(fs);
                else if (Path.GetExtension(filePath).ToLower() == ".xls")
                    workBook = new HSSFWorkbook(fs);
                else
                    throw new Exception("文件类型错误！");
                try
                {
                    //获取第一个sheet
                    ISheet sheet = workBook.GetSheetAt(0);
                    if (sheet != null)
                    {
                        int cellCount = sheet.GetRow(0).Cells.Count;
                        //处理列头
                        for (int i = 0; i < cellCount; i++)
                        {
                            ICell cell = sheet.GetRow(0).GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue.Trim();
                                if (cellValue != null)
                                {
                                    DataColumn column = new DataColumn(cellValue);
                                    table.Columns.Add(column);
                                }
                            }
                        }
                        //最后一列记录行号
                        table.Columns.Add(new DataColumn("行号"));

                        //跳过表头（第一行） 读取数据行
                        int rowCount = sheet.LastRowNum;
                        for (int row = 1; row <= rowCount; row++)
                        {
                            IRow currentRow = sheet.GetRow(row);

                            if (currentRow == null || currentRow.Cells.Count == 0)
                            { fail.Add(row + 1); continue; }

                            DataRow dataRow = table.NewRow();
                            //读取单元格 
                            //int preColumnIndex = -1;
                            for (int cell = 0; cell < cellCount; cell++)
                            {
                                try
                                {
                                    ICell currentCell = currentRow.GetCell(cell);
                                    if (currentCell != null)
                                    {
                                        currentCell.SetCellType(CellType.String);
                                        int columnIndex = currentCell.ColumnIndex;
                                        dataRow[columnIndex] = currentCell.StringCellValue;
                                    }
                                    else
                                    {
                                        dataRow[cell] = string.Empty;
                                    }
                                }
                                catch { }
                            }
                            dataRow[cellCount] = row + 1;//行号
                            table.Rows.Add(dataRow);
                            success.Add(row + 1);
                        }
                    }
                    return table;
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    fs.Close();
                }
            }
        }

        /// <summary>
        /// 导入excel到类
        /// </summary>
        /// <typeparam name="T">继承BaseImport并有构造函数的类</typeparam>
        /// <param name="filePath">文件地址</param>
        /// <param name="success">读取excel文件成功的行号</param>
        /// <param name="fail">读取excel文件失败的行号</param>
        /// <returns>T类集合</returns>
        public static ICollection<T> ImportToCollection<T>(string filePath, out ICollection<int> success, out ICollection<int> fail) where T : BaseImport, new()
        {
            ICollection<T> t_List = new List<T>();

            DataTable table = ImportToDataTable(filePath, out success, out fail);

            IEnumerable<PropertyInfo> propertyInfos = typeof(T).GetProperties().Where(t => System.Attribute.GetCustomAttribute(t, typeof(DescriptionAttribute)) != null);

            IDictionary<string, string> propertyColumnMap = new Dictionary<string, string>();

            foreach (PropertyInfo pi in propertyInfos)
            {
                DescriptionAttribute attribute = System.Attribute.GetCustomAttribute(pi, typeof(DescriptionAttribute)) as DescriptionAttribute;
                propertyColumnMap.Add(pi.Name, attribute.Description);
            }

            foreach (DataRow row in table.Rows)
            {
                T instance = new T();
                foreach (PropertyInfo pi in propertyInfos)
                {
                    pi.SetValue(instance, row[propertyColumnMap[pi.Name]] ?? string.Empty);
                }
                t_List.Add(instance);
            }
            return t_List;
        }
    }
}