using System.Windows;
using System.Diagnostics;
using WpfAppOpenGl.Event;

namespace WpfAppOpenGl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var viewModel = new MainViewModel();
            DataContext = viewModel;

            openGLUserControl.Points = viewModel.Points;
            openGLUserControl.Lines = viewModel.Lines;
            mainMenu.Rotate += MainMenu_Rotate;
            mainMenu.Scale += MainMenu_Scale;
            mainMenu.ObliqueShift += MainMenu_ObliqueShift;
            mainMenu.OPP += MainMenu_OPP;
            mainMenu.ParallelTransfer += MainMenu_ParallelTransfer;
        }
        private void MainMenu_Rotate(object sender, RotationEventArgs e)
        {
           openGLUserControl.Rotate(e.Axis, e.Angle);
        }
        private void MainMenu_Scale(object sender, ScaleEventArgs e)
        {
            openGLUserControl.ApplyScale(e.ScaleFactor);
        }
        private void MainMenu_ObliqueShift(object sender, ObliqueShiftEventArgs e)
        {
            openGLUserControl.ObliqueShift(e.Axis1, e.Axis2, e.Factor);
        }
        private void MainMenu_OPP(object sender, OPPEventArgs e)
        {
            openGLUserControl.OPP(e.Axis, e.Focus);
        }
        private void MainMenu_ParallelTransfer(object sender, ParallelTransferEventArgs e)
        {
            openGLUserControl.ParallelTransfer(e.CoordinateX, e.CoordinateY, e.CoordinateZ);
        }
        private void ChangeFile_Click(object sender, RoutedEventArgs e)
        {            
            WindowFileTxt newWindow = new WindowFileTxt(this);
            newWindow.DataUpdated += NewWindow_DataUpdated; 
            newWindow.Show();
            this.Hide();
        }
        private void NewWindow_DataUpdated(object sender, EventArgs e)
        {            
            var viewModel = (MainViewModel)DataContext; 
            viewModel.ReloadData(); 
            openGLUserControl.Points = viewModel.Points; 
            openGLUserControl.Lines = viewModel.Lines;
        }
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("notepad.exe", WindowFileTxt.filePath);
        }
       
        private void ExitForm_Click (object sender, RoutedEventArgs e)
        {

            this.Close();
        }
        private void ReturnToTheOriginal_Click(object sender, RoutedEventArgs e)
        {
            openGLUserControl.ResetTransformations();
        }
        
        private void OpenInformation_Click(object sender, RoutedEventArgs e)
        {
            WindowInformation windowInformation = new WindowInformation();
            windowInformation.Show();   
        }
    }
}