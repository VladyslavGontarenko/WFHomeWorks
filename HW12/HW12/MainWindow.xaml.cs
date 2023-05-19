using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace HW12
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Создание 3D-сцены
            var viewport = new Viewport3D();

            // Создание камеры
            var camera = new PerspectiveCamera(new Point3D(0, 0, 5), new Vector3D(0, 0, -1), new Vector3D(0, 1, 0));
            viewport.Camera = camera;

            // Создание освещения
            var ambientLight = new AmbientLight(Colors.White);
            var directionalLight = new DirectionalLight(Colors.White, new Vector3D(0, 0, -1));

            // Создание моделей объектов
            var chairModel = CreateChairModel();
            var tableModel = CreateTableModel();
            var tvModel = CreateTVModel();
            var laptopModel = CreateLaptopModel();

            // Создание контейнеров для моделей объектов
            var modelContainer = new Model3DGroup();
            modelContainer.Children.Add(chairModel);
            modelContainer.Children.Add(tableModel);
            modelContainer.Children.Add(tvModel);
            modelContainer.Children.Add(laptopModel);

            // Добавление моделей и освещения на сцену
            var scene = new ModelVisual3D();
            scene.Content = new Model3DGroup { ambientLight, directionalLight, modelContainer };
            viewport.Children.Add(scene);

            // Установка сцены как содержимого окна
            Content = viewport;
        }

        private Model3D CreateChairModel()
        {
            // Создание геометрии стула
            var chairGeometry = new MeshGeometry3D
            {
                Positions = new Point3DCollection(new[]
                {
                    new Point3D(-0.5, -0.5, 0),
                    new Point3D(0.5, -0.5, 0),
                    new Point3D(0, 0.5, 0),
                    new Point3D(0, 0, -0.5),
                }),
                TriangleIndices = new Int32Collection(new[] { 0, 1, 2, 0, 2, 3 })
            };

            // Создание материала стула
            var chairMaterial = new DiffuseMaterial(Brushes.Red);

            // Создание модели стула
            var chairModel = new GeometryModel3D(chairGeometry, chairMaterial);

            return chairModel;
        }

        private Model3D CreateTableModel()
        {
            // Создание геометрии стола
            var tableGeometry = new MeshGeometry3D
            {
                Positions = new Point3DCollection(new[]
                {
                    new Point3D(-0new Point3D(-0.5, -0.5, 0),
                    new Point3D(0.5, -0.5, 0),
                    new Point3D(0.5, 0.5, 0),
                    new Point3D(-0.5, 0.5, 0),
                    new Point3D(-0.5, -0.5, -0.5),
                    new Point3D(0.5, -0.5, -0.5),
                    new Point3D(0.5, 0.5, -0.5),
                    new Point3D(-0.5, 0.5, -0.5)
                }),
                TriangleIndices = new Int32Collection(new[]
                {
                    0, 1, 2, 2, 3, 0, // Top
                    4, 5, 6, 6, 7, 4, // Bottom
                    0, 4, 7, 7, 3, 0, // Left
                    1, 5, 6, 6, 2, 1, // Right
                    3, 7, 6, 6, 2, 3, // Front
                    0, 4, 5, 5, 1, 0  // Back
                })
            };

            // Создание материала стола
            var tableMaterial = new DiffuseMaterial(Brushes.Blue);

            // Создание модели стола
            var tableModel = new GeometryModel3D(tableGeometry, tableMaterial);

            return tableModel;
        }

        private Model3D CreateTVModel()
        {
            // Создание геометрии телевизора
            var tvGeometry = new MeshGeometry3D
            {
                Positions = new Point3DCollection(new[]
                {
                    new Point3D(-0.75, -0.5, 0.25),
                    new Point3D(0.75, -0.5, 0.25),
                    new Point3D(0.75, 0.5, 0.25),
                    new Point3D(-0.75, 0.5, 0.25),
                    new Point3D(-0.75, -0.5, -0.25),
                    new Point3D(0.75, -0.5, -0.25),
                    new Point3D(0.75, 0.5, -0.25),
                    new Point3D(-0.75, 0.5, -0.25)
                }),
                TriangleIndices = new Int32Collection(new[]
                {
                    0, 1, 2, 2, 3, 0, // Front
                    4, 5, 6, 6, 7, 4, // Back
                    0, 4, 7, 7, 3, 0, // Left
                    1, 5, 6, 6, 2, 1, // Right
                    3, 7, 6, 6, 2, 3, // Top
                    0, 4,new Point3D(5, -0.5, 0),
                    new Point3D(5, 0.5, 0),
                    new Point3D(4.5, 0.5, 0),
                    new Point3D(4.5, -0.5, 0),
                    new Point3D(5, -0.5, -0.25),
                    new Point3D(5, 0.5, -0.25),
                    new Point3D(4.5, 0.5, -0.25),
                    new Point3D(4.5, -0.5, -0.25)
                }),
                TriangleIndices = new Int32Collection(new[]
                {
                    0, 1, 2, 2, 3, 0, // Front
                    4, 5, 6, 6, 7, 4, // Back
                    0, 4, 7, 7, 3, 0, // Left
                    1, 5, 6, 6, 2, 1, // Right
                    3, 7, 6, 6, 2, 3, // Top
                    0, 4, 5, 5, 1, 0  // Bottom
                })
            };

            // Создание материала ноутбука
            var laptopMaterial = new DiffuseMaterial(Brushes.Gray);

            // Создание модели ноутбука
            var laptopModel = new GeometryModel3D(laptopGeometry, laptopMaterial);

            return laptopModel;
        }
    }
}