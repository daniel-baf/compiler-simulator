using DocumentFormat.OpenXml.Bibliography;
using graphviz_cSharp.external;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace compiler_app
{
    class GraphvizDrawer
    {
        private List<Token> tokens;
        int counter = 1;

        public GraphvizDrawer(List<Token> tokens) {
            this.tokens = tokens;
        }

        public void createImg(SaveFileDialog saveFileDialog) {
            MessageBox.Show(tokens.Count.ToString() + " tokens generados. \nElige una ruta para guardar el arbol");


            string actions = "digraph G {\n  ";

            Archive archiver = new Archive();

            foreach (Token token in tokens) { 
                //
            }

            actions += "node1[label = \"1\"];\n  node2[label = \"2\"];\n  node3[label = \"3\"];\n  node1[labe4 = \"1\"];\n  node5[label = \"z\"];\n  node6[label = \"afda\"];\n  ";
            actions += "node1 -> node2;\n  node1 -> node3;\n  node2 -> node5;\n  node2 -> node3;\n  node2 -> node5;\n  node4 -> node6;\n  node5 -> node6;\n  ";
            actions += "}";
            /* 
             */
            saveFileDialog.RestoreDirectory = true;

            if (archiver.saveAsArchive(saveFileDialog, actions))
            {
                try
                {
                    String fileInputPath = archiver.getPath();
                    String filename = Path.GetFileName(fileInputPath);

                    String graphVizString = @"" + actions;
                    Bitmap bm = FileDotEngine.Run(graphVizString);

                    for (int x = 0; x < bm.Width; x++)
                    {
                        for (int y = 0; y < bm.Height; y++)
                        {
                            Color clr = bm.GetPixel(x, y);
                            Color newClr = Color.FromArgb(clr.R, 0, 0);
                        }
                    }
                    bm.Save("C:\\Users\\Daniel\\Desktop\\test\\" + @"graph.jpg");
                    MessageBox.Show("done");
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Error al generar archivos\n" + exception.Message);
                }
            }
        }
    }
}
