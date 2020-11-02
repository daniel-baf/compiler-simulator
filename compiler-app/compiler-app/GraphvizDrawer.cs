using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace compiler_app
{
    class GraphvizDrawer
    {
        public GraphvizDrawer(List<Token> tokens) {
            
        }

        public void createImg(SaveFileDialog saveFileDialog1) {
            Archive archiver = new Archive();
            String actions = "digraph G {\n  node1 [lanel=\"A\"];\n  node2 [label = \"SI\"];\n  node3[label=\"E\"]\n  node4[label=\"(\"]\n  node5[label=\"X\"]\n  node6[label=\")\"]\n  ";
            actions += "node7 [label=\"a\"];\n  node8 [label=\">\"];\n  node9 [label=\"12\"];\n";

            actions += "\n  node1->node2;\n  node1 -> node3;\n  node3 -> node4;\n  node3 -> node5;\n  node3 -> node6;\n node5 -> node7;\n  node5 -> node8;\n  node5 -> node9;";
            actions += "\n}";

            saveFileDialog1.RestoreDirectory = true;

            if (archiver.saveAsArchive(saveFileDialog1, actions))
            {
                try
                {
                    String fileInputPath = archiver.getPath();
                    String filename = Path.GetFileName(fileInputPath);
                    MessageBox.Show(filename);

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
