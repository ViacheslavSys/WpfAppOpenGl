using System.Windows;
using System.Windows.Controls;
using WpfAppOpenGl.Event;

namespace WpfAppOpenGl
{
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public event EventHandler<RotationEventArgs> Rotate;
        public event EventHandler<ScaleEventArgs> Scale;
        public event EventHandler<ObliqueShiftEventArgs> ObliqueShift;
        public event EventHandler<OPPEventArgs> OPP;
        public event EventHandler<ParallelTransferEventArgs> ParallelTransfer;
        public event EventHandler FitToScreenRequested;

        public MainMenu()
        {
            InitializeComponent();
        }            

        private void ButtonRotateX_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextBoxRotateAngle.Text, out double angle))
            {
                Rotate?.Invoke(this, new RotationEventArgs('X', angle));
            }
        }

        private void ButtonRotateY_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextBoxRotateAngle.Text, out double angle))
            {
                Rotate?.Invoke(this, new RotationEventArgs('Y', angle));
            }
        }

        private void ButtonRotateZ_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextBoxRotateAngle.Text, out double angle))
            {
                Rotate?.Invoke(this, new RotationEventArgs('Z', angle));
            }
        }


        private void ButtonScale_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextBoxScale.Text, out double scale))
            {
                // Вызываем событие для масштабирования
                Scale?.Invoke(this, new ScaleEventArgs(scale));
            }
        }        

        private void ButtonObliqueShiftXY_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextBoxObliqueShiftFactor.Text, out double k))
            {
                ObliqueShift?.Invoke(this, new ObliqueShiftEventArgs('X', 'Y', k));
            }
        }

        private void ButtonObliqueShiftXZ_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextBoxObliqueShiftFactor.Text, out double k))
            {
                ObliqueShift?.Invoke(this, new ObliqueShiftEventArgs('X', 'Z', k));
            }
        }

        private void ButtonObliqueShiftYX_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextBoxObliqueShiftFactor.Text, out double k))
            {
                ObliqueShift?.Invoke(this, new ObliqueShiftEventArgs('Y', 'X', k));
            }
        }

        private void ButtonObliqueShiftYZ_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextBoxObliqueShiftFactor.Text, out double k))
            {
                ObliqueShift?.Invoke(this, new ObliqueShiftEventArgs('Y', 'Z', k));
            }
        }

        private void ButtonObliqueShiftZX_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextBoxObliqueShiftFactor.Text, out double k))
            {
                ObliqueShift?.Invoke(this, new ObliqueShiftEventArgs('Z', 'X', k));
            }
        }

        private void ButtonObliqueShiftZY_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextBoxObliqueShiftFactor.Text, out double k))
            {
                ObliqueShift?.Invoke(this, new ObliqueShiftEventArgs('Z', 'Y', k));
            }
        }        

        private void ButtonOPPX_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextBoxOPP.Text, out double focus))
            {
                OPP?.Invoke(this, new OPPEventArgs('X', focus));
            }
        }

        private void ButtonOPPY_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextBoxOPP.Text, out double focus))
            {
                OPP?.Invoke(this, new OPPEventArgs('Y', focus));
            }
        }

        private void ButtonOPPZ_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextBoxOPP.Text, out double focus))
            {
                OPP?.Invoke(this, new OPPEventArgs('Z', focus));
            }
        }
       
        private void ButtonParallelTransfer_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(TextBoxParallelTransferX.Text, out double coordinateX) && 
                double.TryParse(TextBoxParallelTransferY.Text, out double coordinateY) &&
                double.TryParse(TextBoxParallelTransferZ.Text, out double coordinateZ))
            {
                ParallelTransfer?.Invoke(this, new ParallelTransferEventArgs(coordinateX, coordinateY, coordinateZ));
            }
        }

        private void ButtonInscribing_Click(object sender, RoutedEventArgs e)
        {
            FitToScreenRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
