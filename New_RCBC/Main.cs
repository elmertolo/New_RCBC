using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using New_RCBC.Models;
using New_RCBC.Services;
using System.IO;

namespace New_RCBC
{
    public partial class Main : Form
    {
        public string batchfile = "";
        public DateTime deliveryDate;
        DateTime dateTime;
        List<BranchModel> branch = new List<BranchModel>();
        List<OrderModel> orderList = new List<OrderModel>();
        DbConServices con = new DbConServices();
        public static string batch = "";
        Int64 startsSN = 0;
        Int64 endSN = 0;
        public static string _fileName = "";
        int TotalA = 0;
        int TotalB = 0;
        public Main()
        {
            InitializeComponent();
            dateTime = dateTimePicker1.MinDate = DateTime.Now; //Disable selection of backdated dates to prevent errors  
        }

        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            encodeToolStripMenuItem.Enabled = false;
            string errorMessage = "";
            batchfile = txtBatch.Text;
            con.GetAllBranches(branch);// get all details in branch database
            deliveryDate = dateTimePicker1.Value;
            if (txtBatch.Text == "")
            {
                MessageBox.Show("Please Enter Batch Number!!!");
            }
            else
            {
                if (deliveryDate == dateTime)
                {
                    MessageBox.Show("Please set Delivery Date!");
                }
                else
                {


                    deliveryDate = dateTimePicker1.Value;
                    if (Directory.GetFiles(Application.StartupPath + "\\Head\\").Length == 0) // if the path folder is empty
                        MessageBox.Show("No files found in directory path", "***System Error***");
                    else
                    {
                        string[] list = Directory.GetFiles(Application.StartupPath + "\\Head\\");

                        string Extension = "";

                        foreach (string FileName in list)
                        {
                            //Get the Extension Name
                            int LoopCount = FileName.ToString().Length - 2;
                            while (LoopCount > 0)
                            {

                                if (FileName.ToString().Substring(LoopCount, 1) == "." && Extension == "")
                                {
                                    Extension = FileName.ToString().Substring(LoopCount + 1, FileName.ToString().Length - LoopCount - 1).ToUpper();
                                }

                                LoopCount = LoopCount - 1;
                            }
                            //MessageBox.Show(Extension);
                            string Cont = "";
                            if (Extension == "XLS" || Extension == "XLSX")
                            {
                                if (list != null)
                                {
                                    for (int i = 0; i < list.Length; i++)
                                    {
                                        Excel.Application xlApp = new Excel.Application();
                                        Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(FileName, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                                        int SheetsCount = xlWorkbook.Sheets.Count;
                                        for (int b = 0; b < SheetsCount; b++)
                                        {
                                            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[b + 1];
                                            Excel.Range xlRange = xlWorksheet.UsedRange;

                                            int rowCount = xlRange.Rows.Count;
                                            int colCount = xlRange.Columns.Count;
                                            string SheetName = xlWorksheet.Name.ToUpper();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
