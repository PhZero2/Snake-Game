using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp2.Interfaz;
using WpfApp2.Codigo;
using System.Threading;
using WpfApp2.Variante;

namespace WpfApp2
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<State, ImageSource> valueImages = new Dictionary<State, ImageSource>()
        {
            {State.Vacio, Images.Empty },
            {State.Snake, Images.Cuerpo},
            {State.Food, Images.Comida },
            {State.MenoScore, Images.MScore },
            {State.FoodN,Images.FoodN },
            {State.Food2, Images.Food2 },
            {State.Pared, Images.Pared },
            {State.Multi, Images.Multiplicador }
        };
        Dictionary<Direction, int> rotaciones = new Dictionary<Direction, int>()
        {
            {Direction.Up, 0 },
            {Direction.Rigth, 90 },
            {Direction.Left, 270 },
            {Direction.Down, 180 }
        };

        private Image cabeza;

        GameState gameState;

        bool running = false;

        private readonly int x = 15, y = 15;
        private ICondition p;
        private readonly Image[,] images;
        private readonly State[] spawneable = { State.Food2, State.FoodN, State.MenoScore, State.Pared, State.Multi };

        public MainWindow()
        {
            InitializeComponent();

            images = SetUp();
            p = ConditionCreator.Get();
            gameState = CreateGameState();
        }

        private void Inicializar(Location location, GameState gameState)
        {
            for(int i = 0; i < 3; i++)
            {
                Location locationz = new Location(location.X, location.Y + 1);

                gameState.Mapa.Add(locationz, State.Snake);
                gameState.Snake.Grow(locationz);
            }

            gameState.Mapa.Colocar(State.Food);
        }

        private GameState CreateGameState()
        {
            var mapa = new Mapa(x, y);
            GameState gameState = new GameState(p, new Snake(), mapa, new Colocador(mapa, spawneable), new Movimiento(Direction.Rigth), new PotenciadorExcecutor());

            gameState.Mapa.ActionEventHandler += (obj, e) =>
            {
                images[e.Location.X, e.Location.Y].Source = valueImages[e.State];
                images[e.Location.X, e.Location.Y].RenderTransform = Transform.Identity;
            };

            return gameState;
        }

        private void AgregarEntrada(Direction dir)
        {
            gameState.AddDirection(dir);
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (gameState.GameOver)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.Left:
                    AgregarEntrada(Direction.Left);
                    break;

                case Key.Right:
                    AgregarEntrada(Direction.Rigth);
                    break;

                case Key.Up:
                    AgregarEntrada(Direction.Up);
                    break;

                case Key.Down:
                    AgregarEntrada(Direction.Down);
                    break;
            }
        }


        private async Task Run()
        {
            await CountDown();

            Inicializar(new Location(x / 2, 1), gameState);
            DrawGrid();
            AddHead();
            OverLay.Visibility = Visibility.Hidden;

            await GameLoop();
            await GameOver();

            gameState = CreateGameState();
            cabeza = null;
        }
        private async Task GameLoop()
        {
            while (!gameState.GameOver)
            {
                await Task.Delay(70);
                gameState.Ejecutar();
                AddHead();
                ScoreText.Text = $"Score {gameState.Score}";
            }
        }
        private Image[,] SetUp()
        {
            Image[,] images = new Image[x, y];

            GameGrid.Rows = x;
            GameGrid.Columns = y;

            for (int i = 0; i < x; i++)
            {
                for (int k = 0; k < y; k++)
                {
                    Image img = new Image()
                    {
                        Source = Images.Empty,
                        RenderTransformOrigin = new Point(0.5, 0.5)
                    };

                    images[i, k] = img;

                    GameGrid.Children.Add(img);
                }
            }
            return images;
        }

        private async void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (OverLay.Visibility == Visibility.Visible)
            {
                e.Handled = true;
            }

            if (!running)
            {
                running = true;
                await Run();
                running = false;
            }
        }

        private void DrawGrid()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    var img = valueImages[gameState.Mapa[i, j]];
                    images[i, j].Source = img;
                    images[i, j].RenderTransform = Transform.Identity;
                }
            }

        }
        private void AddHead()
        {
            if (cabeza != null)
                cabeza.Source = Images.Cuerpo;

            var pos = gameState.Head;
            var img = images[pos.X, pos.Y];

            img.Source = Images.Head;
            cabeza = img;

            var rotacion = rotaciones[gameState.Movimiento.Direction];

            img.RenderTransform = new RotateTransform(rotacion);
        }

        private async Task CountDown()
        {
            for (int i = 3; i > 0; i--)
            {
                OverlayText.Text = i.ToString();
                await Task.Delay(500);
            }
        }
        private async Task GameOver()
        {
            await Task.Delay(500);
            OverLay.Visibility = Visibility.Visible;
            OverlayText.Text = "Game Over";
        }
    }
}
