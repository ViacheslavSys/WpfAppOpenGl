using SharpGL;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppOpenGl
{
    public partial class OpenGLUserControl : UserControl
    {
        public List<PointModel> Points { get; set; }
        public List<SegmentModel> Lines { get; set; }
        private double[,] currentTransformationMatrix;

        private double currentScaleFactor = 1.0;

        public OpenGLUserControl()
        {
            InitializeComponent();
            currentTransformationMatrix = MatrixOperation.CreateIdentityMatrix();
        }
        public void ResetTransformations()
        {
            // Сбросить текущие трансформации
            currentTransformationMatrix = MatrixOperation.CreateIdentityMatrix();

            // Сбросить масштаб
            currentScaleFactor = 1.0;

            // Обновить OpenGLControl
            openGLControl.InvalidateVisual();
        }

        public void Rotate(char axis, double angle)
        {
            var rotationMatrix = MatrixOperation.CreateRotationMatrix(axis, Math.PI / 180 * angle);
            ApplyTransformation(rotationMatrix);
        }

        public void ApplyScale(double scaleFactor)
        {
            currentScaleFactor *= scaleFactor;
            ApplyTransformation(MatrixOperation.GetScalingMatrix(currentScaleFactor));
        }

        public void ObliqueShift(char axis1, char axis2, double factor)
        {
            var obliqueShiftMatrix = MatrixOperation.GetObliqueShiftMatrix(axis1, axis2, factor);
            ApplyTransformation(obliqueShiftMatrix);
        }

        public void OPP(char axis, double factor)
        {
            var matrix = MatrixOperation.CreateIdentityMatrix();
            matrix[GetAxisIndex(axis), 3] = 1 / factor;
            ApplyTransformation(matrix);
        }

        public void ParallelTransfer(double x, double y, double z)
        {
            var translationMatrix = MatrixOperation.GetParallelTransformMatrix(x, y, z);
            ApplyTransformation(translationMatrix);
        }

        private void ApplyTransformation(double[,] transformationMatrix)
        {
            currentTransformationMatrix = MatrixOperation.MultiplyMatrices(currentTransformationMatrix, transformationMatrix);
            openGLControl.InvalidateVisual();
        }

        private int GetAxisIndex(char axis)
        {
            return axis switch
            {
                'X' => 0,
                'Y' => 1,
                'Z' => 2,
                _ => throw new System.ArgumentException("Invalid axis")
            };
        }

        private void openGLControl_OpenGLDraw(object sender, RoutedEventArgs e)
        {
            var gl = openGLControl.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
            gl.LoadIdentity();

            DrawAxes(gl);

            gl.PushMatrix();
            gl.MultMatrix(MatrixOperation.ConvertTo1DArray(currentTransformationMatrix));
                        
            DrawModel(gl);

            gl.PopMatrix();
            gl.Flush();
        }        

        private void DrawModel(OpenGL gl)
        {
            if (Points != null && Lines != null)
            {
                gl.Color(1.0, 0.0, 1.0);
                foreach (var line in Lines)
                {
                    var start = Points[line.StartIndex].GetScaledCoordinates();
                    var end = Points[line.EndIndex].GetScaledCoordinates();

                    gl.Begin(OpenGL.GL_LINES);
                    gl.Vertex(start.x, start.y, start.z);
                    gl.Vertex(end.x, end.y, end.z);
                    gl.End();
                }
            }
        }

        private void DrawAxes(OpenGL gl)
        {
            gl.Color(1.0, 0.0, 0.0);
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(0, 0, 0);
            gl.Vertex(2, 0, 0);
            gl.End();

            gl.Color(0.0, 1.0, 0.0);
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(0, 0, 0);
            gl.Vertex(0, 2, 0);
            gl.End();

            gl.Color(0.0, 0.0, 1.0);
            gl.Begin(OpenGL.GL_LINES);
            gl.Vertex(0, 0, 0);
            gl.Vertex(0, 0, 2);
            gl.End();
        }
        private void openGLControl_Resized(object sender, RoutedEventArgs e)
        {
            var openGLControl = sender as SharpGL.WPF.OpenGLControl;
            var gl = openGLControl.OpenGL;

            gl.MatrixMode(OpenGL.GL_PROJECTION);
            gl.LoadIdentity();
            gl.Perspective(45.0f, (double)openGLControl.ActualWidth / openGLControl.ActualHeight, 0.1, 100.0);
            gl.LookAt(0, 0, 10, 0, 0, 0, 0, 10, 0);
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }
       

    }
}
