using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp2.Interfaz
{
    public static class Images
    {

        public readonly static ImageSource Empty = LoadIamge(@"\Assets\Empty.png");
        public readonly static ImageSource Head = LoadIamge(@"\Assets\Head.png");
        public readonly static ImageSource Cuerpo = LoadIamge(@"\Assets\Body.png");
        public readonly static ImageSource Comida = LoadIamge(@"\Assets\Fruta.png");
        public readonly static ImageSource MScore = LoadIamge(@"\Assets\MenoScore.png");
        public readonly static ImageSource FoodN = LoadIamge(@"\Assets\FrutaN.png");
        public readonly static ImageSource Food2 = LoadIamge(@"\Assets\Fruta2.png");
        public readonly static ImageSource Pared = LoadIamge(@"\Assets\Pared.png");
        public readonly static ImageSource Multiplicador = LoadIamge(@"\Assets\Multiplicador.png");

        private static ImageSource LoadIamge(string filename) => new BitmapImage(new Uri(filename, UriKind.Relative));
    }
}
