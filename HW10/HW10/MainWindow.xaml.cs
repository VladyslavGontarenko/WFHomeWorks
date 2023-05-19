using System.Windows;
using MaterialDesignThemes.Wpf;

namespace HW10
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Применение темы Material Design
            var paletteHelper = new PaletteHelper();
            ITheme theme = paletteHelper.GetTheme();
            theme.SetBaseTheme(Theme.Dark);
            paletteHelper.SetTheme(theme);
        }
    }
}