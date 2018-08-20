﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;

namespace DRC.WordAddIn.BarcodeLabels
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        public void OpenLabels(string dataSource)
        {
            Word.Document activeDocument = Application.ActiveDocument;

            try
            {
                activeDocument.MailMerge.CreateDataSource(dataSource,
                                                          missing, missing, missing, missing,
                                                          missing, missing, missing, missing);
                Application.MailingLabel.LabelOptions();
            } catch (Exception e)
            {
				MessageBox.Show(e.StackTrace);
            }
        }

        public void ProcessDataSource()
        {
            Word.Document activeDocument = Application.ActiveDocument;

            try
            {
                activeDocument.MailMerge.OpenDataSource("datasource.csv",
                                                        missing, missing, missing, missing,
                                                        missing, missing, missing, missing);
            }
            catch (Exception e)
            {
				MessageBox.Show(e.StackTrace);
            }
        }

        public void DisplayStatus()
        {
            Word.Document activeDocument = this.Application.ActiveDocument;
            string status = "";

            status += "Mail Merge State: " + activeDocument.MailMerge.State.ToString() + "\n";
            status += "Data Source: " + activeDocument.MailMerge.DataSource.Type.ToString() + "\n";

            MessageBox.Show(status);
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
