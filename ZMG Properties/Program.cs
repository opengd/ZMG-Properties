using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace ZMG_Properties
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] argv)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

    public class ZMGData
    {

        private string strType = null;
        private string strDescription = null;
        private string strComputer = null;
        private string strAuthor = null;
        private string strChipset = null;
        private string strGraphic = null;
        private string strNetwork = null;
        private string strAudio = null;
        private string strDisk = null;

        public string Type
        {
            get
            {
                strType = GetZMGData(4, 30);
                return strType;
            }
            //set
            //{
            //    strType = value;
            //    SetZMGData(value, 4, 176);
            //}
        }

        public string Description 
        {
            get {
                strDescription = GetZMGData(180, 256);
                return strDescription; }
            set {
                strDescription = value;
                SetZMGData(value, 180, 256);
            }
        }
        public string Computer
        {
            get {
                strComputer = GetZMGData(436, 128);
                return strComputer; }
            set {
                strComputer = value;
                SetZMGData(value, 436, 128);
            }
        }
        public string Author
        {
            get {
                strAuthor = GetZMGData(564, 128);
                return strAuthor; }
            set {
                strAuthor = value;
                SetZMGData(value, 564, 128);
            }
        }
        public string Chipset
        {
            get {
                strChipset = GetZMGData(2104, 256);
                return strChipset;
            }
            set {
                strChipset = value;
                SetZMGData(value, 2104, 256);
            }
        }
        public string Graphic
        {
            get {
                strGraphic = GetZMGData(2360, 256);
                return strGraphic; }
            set { 
                strGraphic = value;
                SetZMGData(value, 2360, 256);
            }
        }
        public string Network
        {
            get {
                strNetwork = GetZMGData(2616, 256);
                return strNetwork; }
            set {
                strNetwork = value;
                SetZMGData(value, 2616, 256);
            }
        }
        public string Audio
        {

            get {
                strAudio = GetZMGData(2872, 256);
                return strAudio; }
            set {
                strAudio = value;
                SetZMGData(value, 2872, 256);
            }
        }
        
        public string Disk
        {
            get {
                strDisk = GetZMGData(3128, 256);
                return strDisk; }
            set {
                strDisk = value;
                SetZMGData(value, 3128, 256);
            }
        }

        private string strFilename = null;

        private string strZMGFile;
        public void SetFile(string inFilename)
        {
            this.strFilename = inFilename;
        }
        byte[] buffbyte;

        
        public void Load()
        {
            this.Read(strFilename, 3743, "Error - Could not load file");            
        }
        public void Save()
        {
            this.Write(strFilename, 3743, "Error - Could not save file");
        }

        public void ImportProperties(string filename, bool prop, bool hard)
        {
            if (hard == true)
            {
                this.Read(filename, 3743, "Error - Could not import file");
            }
            else
            {
                this.Read(filename, 692, "Error - Could not import file");
            }
            }

        public void ExportProperties(string filename, bool prop, bool hard) 
        {
            if (hard == true)
            {
                this.Write(filename, 3743, "Error - Could not export file");
            }
            else
            { this.Write(filename, 692, "Error - Could not export file"); }
        }

        private string GetZMGData(int offset, int lenght)
        {
            string tmpStr = "";
            int i = offset;
            while (i < (offset + lenght))
            {
                if (buffbyte[i] != 0) { tmpStr += Char.ConvertFromUtf32(buffbyte[i]); }
                i++;
            }
            return tmpStr;
        }

        private void SetZMGData(string data, int offset, int lenght)
        {
            char[] charArray = data.ToCharArray();
            int i = 0;
            int chari = 0;
            while ((offset + i) < (offset + lenght))
            {
                if (chari < charArray.Length)
                {
                    buffbyte[offset + i] = Convert.ToByte(charArray[chari]);
                    chari++;
                }
                else
                {
                    buffbyte[offset + i] = 0;
                }
                i++;
                buffbyte[offset + i] = 0;
                i++;              
            }
        }

        private void Read(string filename, int lenght, string exception)
        {
            try
            {
                BinaryReader zmgfile = new BinaryReader(File.Open(filename, FileMode.Open));
                buffbyte = new byte[lenght];
                int i = 0;
                while (i < lenght)
                {
                    buffbyte[i] = zmgfile.ReadByte();

                    strZMGFile += Char.ConvertFromUtf32(buffbyte[i]);

                    i++;
                }
                zmgfile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), exception, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Write(string filename, int lenght, string exception)
        {
            try
            {
                BinaryWriter zmgfile = new BinaryWriter(File.Open(filename, FileMode.OpenOrCreate));
                int i = 0;
                while (i < lenght)
                {
                    zmgfile.Write(buffbyte[i]);
                    i++;
                }
                zmgfile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), exception, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
