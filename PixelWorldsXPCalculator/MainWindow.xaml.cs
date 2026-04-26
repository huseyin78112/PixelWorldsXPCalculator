using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PixelWorldsXPCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateXP_Click(object sender, RoutedEventArgs e)
        {
            int xp = 0;
            int sourceXPLevel = 0;
            int targetXPLevel = 0;
            int currentXP = 0;
            if (!int.TryParse(SourceXPLevel.Text, out sourceXPLevel))
            {
                MessageBox.Show("Source XP Level is not a valid value of Int32.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(TargetXPLevel.Text, out targetXPLevel))
            {
                MessageBox.Show("Target XP Level is not a valid value of Int32.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!int.TryParse(CurrentXP.Text, out currentXP))
            {
                MessageBox.Show("Current XP is not a valid value of Int32.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (sourceXPLevel < 1 || sourceXPLevel > (Utils.MaxXPLevel - 1))
            {
                MessageBox.Show("Source XP Level must be in range 1-" + (Utils.MaxXPLevel - 1) + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (targetXPLevel < 2 || targetXPLevel > Utils.MaxXPLevel)
            {
                MessageBox.Show("Target XP Level must be in range 2-" + Utils.MaxXPLevel + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (targetXPLevel <= sourceXPLevel)
            {
                MessageBox.Show("Target XP Level must not be less than or equal to the Source XP Level.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (currentXP < 0 || currentXP >= (sourceXPLevel * Utils.XPMultiplier))
            {
                MessageBox.Show("Current XP must be in range 0-" + ((sourceXPLevel * Utils.XPMultiplier) - 1) + ".", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            for (int i = sourceXPLevel; i < targetXPLevel; i++)
            {
                xp += i * Utils.XPMultiplier;
            }
            xp -= currentXP;
            MessageBox.Show("You need " + xp + " XP for XP level " + targetXPLevel + ".", "Result", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        private void MaxLevel_Click(object sender, RoutedEventArgs e)
        {
            TargetXPLevel.Text = Utils.MaxXPLevel.ToString();
        }
    }
}