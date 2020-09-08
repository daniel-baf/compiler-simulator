using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;//using needed, calls the library
using System.Windows.Forms;

namespace compiler_app
{
    class Archive
    {

        private String textFound = null;
        private String path = null;

        public Archive () { 
            
        }

        public Boolean openArchive(OpenFileDialog openFileDialog) {
            try {

                openFileDialog.InitialDirectory = "c:\\";//main window
                openFileDialog.FilterIndex = 1;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(openFileDialog.FileName))//the name of the archive
                    {
                        using (Stream streamer = openFileDialog.OpenFile())//strats reading
                        {
                            readArchive(openFileDialog.FileName);
                            this.path = openFileDialog.FileName;
                            return true;
                        }
                    }
                }
            } catch (Exception e){
                MessageBox.Show("El archivo no se abrió correctamente " + e.Message);
                //TODO, ADD TO ERROR TABLE
                return false;
            }
            return false;
        }

        public void readArchive(String archiveName) {
            String text;//the archive info
            StreamReader reader = new StreamReader(archiveName, System.Text.Encoding.Default);//Default encoding 'cause idk how to configure a UTF-8
            text = reader.ReadToEnd();//read all, we need no a while like in java
            reader.Close();//i don´t need the reader anymore
            this.textFound = text;
        }

        public Boolean saveAsArchive(SaveFileDialog saveFileDialog, String information) {
            try {
                if (saveFileDialog.ShowDialog() == DialogResult.OK) {//if press OK

                    if (File.Exists(saveFileDialog.FileName)){//if exists a name
                        this.path = saveFileDialog.FileName;//save the name on the Dialog

                        StreamWriter textToSave = File.CreateText(this.path);

                        textToSave.Write(information);
                        textToSave.Flush();
                        textToSave.Close();
                    } else {
                        this.path = saveFileDialog.FileName;//save the name on the Dialog

                        StreamWriter textToSave = File.CreateText(this.path);

                        textToSave.Write(information);
                        textToSave.Flush();
                        textToSave.Close();
                    }
                    MessageBox.Show(this.path);
                }
            }
            catch { }
            return false;
        }

        public Boolean saveArchive(String info) {
            try
            {
                StreamWriter textToSave = File.CreateText(this.path);

                textToSave.Write(info);
                textToSave.Flush();
                textToSave.Close();
                
            }
            catch { }
            return false;

        }

        //----------------GETTER AND SETTER
        public String getTextFound() {
            return this.textFound;
        }

        public String getPath() {
            return this.path;
        }
    }
}
