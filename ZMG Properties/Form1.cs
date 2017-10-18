using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ZMG_Properties
{
    public partial class Form1 : Form
    {
        ZMGData zmgData = new ZMGData();

        private string inFilename = null;

        public Form1()
        {
            InitializeComponent();
            InitZMGData();
            PopulateProperties();
            PopulateHardware();
            GUIOptions();
        }

        private void InitZMGData()
        {
            inFilename = Environment.GetCommandLineArgs()[1];
            this.zmgData.SetFile(inFilename);
            this.zmgData.Load();

            //textBoxGraphic.Text = Environment.GetCommandLineArgs()[1];

            
            //this.zmgData.SetFile("C:\\Blocks.zmg");

            //this.Text = this.Text + " - " + inFilename; 
        }

        private void GUIOptions()
        {
            buttonApply.Enabled = false;
        }

        private void PopulateProperties()
        {
            textBoxFilename.Text = inFilename;
            textBoxType.Text = this.zmgData.Type;
            textBoxDescription.Text = this.zmgData.Description;
            textBoxAuthor.Text = this.zmgData.Author;
            textBoxComputer.Text = this.zmgData.Computer;
        }
        private void PopulateHardware() 
        {
            textBoxChipset.Text = this.zmgData.Chipset;
            textBoxGraphic.Text = this.zmgData.Graphic;
            textBoxNetwork.Text = this.zmgData.Network;
            textBoxAudio.Text = this.zmgData.Audio;
            textBoxDisk.Text = this.zmgData.Disk;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (buttonApply.Enabled == true) 
            { 
                this.SaveZMG();
            }
            Application.Exit();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void buttonApply_Click(object sender, EventArgs e)
        {
            this.SaveZMG();
            buttonApply.Enabled = false;
        }
        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.Filter = "ZenWorks Image Files,(*.zmg)|*.zmg";
            filedialog.ShowDialog();
            textBoxChooseFile.Text = filedialog.FileName;
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            if (this.textBoxChooseFile.Text != "")
            {
                this.zmgData.ImportProperties(textBoxChooseFile.Text, true, this.checkBoxImportHardware.Checked);          
                this.PopulateProperties();
                if (this.checkBoxImportHardware.Checked == true) { this.PopulateHardware(); }
                buttonApply.Enabled = true;
                this.labelImportStatus.Text = "Properties successfully imported!";
            }
            else {
                this.labelImportStatus.Text = "No file to import is selected";
            }
        }
        private void buttonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog filedialog = new SaveFileDialog();
            filedialog.Filter = "ZenWorks Image Files,(*.zmg)|*.zmg";
            filedialog.ShowDialog();
            this.zmgData.ExportProperties(filedialog.FileName, true, this.checkBoxExportHardware.Checked);
            this.labelExportStatus.Text = "Properties successfully exported!";

        }
        private void checkBoxReadOnly_CheckedChanged(object sender, EventArgs e)
        {
            textBoxChipset.ReadOnly = checkBoxReadOnly.Checked;
            textBoxGraphic.ReadOnly = checkBoxReadOnly.Checked;
            textBoxNetwork.ReadOnly = checkBoxReadOnly.Checked;
            textBoxAudio.ReadOnly = checkBoxReadOnly.Checked;
            textBoxDisk.ReadOnly = checkBoxReadOnly.Checked;
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void On_TextChanged(object sender, EventArgs e)
        {
            buttonApply.Enabled = true;
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void SaveZMG()
        {
            if (textBoxDescription.Modified) { this.zmgData.Description = textBoxDescription.Text; }
            if (textBoxAuthor.Modified) { this.zmgData.Author = textBoxAuthor.Text; }
            if (textBoxComputer.Modified) { this.zmgData.Computer = textBoxComputer.Text; }
            
            if (textBoxChipset.Modified) {this.zmgData.Chipset = textBoxChipset.Text;}
            if (textBoxGraphic.Modified) { this.zmgData.Graphic = textBoxGraphic.Text; }
            if (textBoxNetwork.Modified) { this.zmgData.Network = textBoxNetwork.Text; }
            if (textBoxAudio.Modified) { this.zmgData.Audio = textBoxAudio.Text; }
            if (textBoxDisk.Modified) { this.zmgData.Disk = textBoxDisk.Text; }

            this.zmgData.Save();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxImport_Enter(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
