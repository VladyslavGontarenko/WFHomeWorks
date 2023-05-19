using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace HW11
{
    public partial class MainWindow : Window
    {
        private readonly SolidColorBrush _redBrush = new SolidColorBrush(Colors.Red);
        private readonly SolidColorBrush _yellowBrush = new SolidColorBrush(Colors.Yellow);
        private readonly SolidColorBrush _greenBrush = new SolidColorBrush(Colors.Green);
        private readonly SolidColorBrush _blueBrush = new SolidColorBrush(Colors.Blue);

        private int _currentColorIndex = 0;
        private readonly DoubleAnimation _animation;

        public MainWindow()
        {
            InitializeComponent();

            // Устанавливаем начальный цвет фона окна
            Background = _redBrush;

            // Создаем анимацию смены цвета фона
            _animation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(2),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };

            // Запускаем анимацию
            AnimateBackgroundColor();
        }

        private void AnimateBackgroundColor()
        {
            var colorStoryboard = new Storyboard();

            // Создаем анимацию для каждого цвета
            var redAnimation = CreateColorAnimation(_redBrush);
            var yellowAnimation = CreateColorAnimation(_yellowBrush);
            var greenAnimation = CreateColorAnimation(_greenBrush);
            var blueAnimation = CreateColorAnimation(_blueBrush);

            // Добавляем анимации в Storyboard
            colorStoryboard.Children.Add(redAnimation);
            colorStoryboard.Children.Add(yellowAnimation);
            colorStoryboard.Children.Add(greenAnimation);
            colorStoryboard.Children.Add(blueAnimation);

            // Запускаем анимацию цвета фона окна
            Storyboard.SetTarget(redAnimation, this);
            Storyboard.SetTarget(yellowAnimation, this);
            Storyboard.SetTarget(greenAnimation, this);
            Storyboard.SetTarget(blueAnimation, this);

            Storyboard.SetTargetProperty(redAnimation, new PropertyPath("(MainWindow.Background).(SolidColorBrush.Color)"));
            Storyboard.SetTargetProperty(yellowAnimation, new PropertyPath("(MainWindow.Background).(SolidColorBrush.Color)"));
            Storyboard.SetTargetProperty(greenAnimation, new PropertyPath("(MainWindow.Background).(SolidColorBrush.Color)"));
            Storyboard.SetTargetProperty(blueAnimation, new PropertyPath("(MainWindow.Background).(SolidColorBrush.Color)"));

            // Запускаем Storyboard
            colorStoryboard.Begin(this);
        }

        private ColorAnimation CreateColorAnimation(SolidColorBrush targetBrush)
        {
            var colorAnimation = new ColorAnimation
            {
                From = ((SolidColorBrush)Background).Color,
                To = targetBrush.Color,
                Duration = TimeSpan.FromSeconds(2),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };

            // При завершении анимации меняем текущий цвет на следующий
            colorAnimation.Completed += (sender, args) =>
            {
                _currentColorIndex = (_currentColorIndex + 1) % 4;

                switch (_currentColorIndex)
                {
                    case 0:
                        colorAnimation.To = _yellowBrush.Color;
                        break;
                    case 1:
                        colorAnimation.To = _greenBrush.Color;
                        break;
                    case 2:
                        colorAnimation.To = _blueBrush.Color;
                        break;
                    case 3: colorAnimation.To = _redBrush.Color; break;
                }
            }; return colorAnimation;
        }
    }
}