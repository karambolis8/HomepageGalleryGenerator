using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace HomepageGalleryGenerator
{
    static class Program
    {
/*
podaje sie liste plików (mozna przegladac folder)
uwzglednic przypadki reszty z dzielenia przez 3

title modelu (model, skala, producent osobno - bedzie elastycznie)

sam dodaje _small. jak w folderze jest plik ze small, to go nie dodaje do listy.
sprawdzic regexpem "_small."
*/

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
