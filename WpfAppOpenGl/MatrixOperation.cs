using System;

namespace WpfAppOpenGl
{
    public class MatrixOperation
    {
        // Метод для создания единичной матрицы (матрица без трансформаций)
        public static double[,] CreateIdentityMatrix(int size = 4)
        {
            var matrix = new double[size, size];
            for (int i = 0; i < size; i++)
                matrix[i, i] = 1.0; // Заполняем диагональные элементы единицами
            return matrix;
        }

        // Метод для создания матрицы вращения для заданной оси и угла
        public static double[,] CreateRotationMatrix(char axis, double angle)
        {
            var matrix = CreateIdentityMatrix(); // Начинаем с единичной матрицы

            // В зависимости от выбранной оси создаем соответствующую матрицу вращения
            switch (axis)
            {
                case 'X':
                    matrix[1, 1] = Math.Cos(angle);
                    matrix[1, 2] = Math.Sin(angle);
                    matrix[2, 1] = -Math.Sin(angle);
                    matrix[2, 2] = Math.Cos(angle);
                    break;
                case 'Y':
                    matrix[0, 0] = Math.Cos(angle);
                    matrix[0, 2] = -Math.Sin(angle);
                    matrix[2, 0] = Math.Sin(angle);
                    matrix[2, 2] = Math.Cos(angle);
                    break;
                case 'Z':
                    matrix[0, 0] = Math.Cos(angle);
                    matrix[0, 1] = Math.Sin(angle);
                    matrix[1, 0] = -Math.Sin(angle);
                    matrix[1, 1] = Math.Cos(angle);
                    break;
            }

            return matrix;
        }

        // Метод для умножения двух матриц
        public static double[,] MultiplyMatrices(double[,] matrixA, double[,] matrixB)
        {
            int rowsA = matrixA.GetLength(0);
            int colsA = matrixA.GetLength(1);
            int rowsB = matrixB.GetLength(0);
            int colsB = matrixB.GetLength(1);

            double[,] result = new double[rowsA, colsB];

            // Проход по всем строкам и столбцам и выполнение умножения матриц
            for (int i = 0; i < rowsA; i++)
            {
                for (int j = 0; j < colsB; j++)
                {
                    for (int k = 0; k < colsA; k++)
                    {
                        result[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return result;
        }

        // Метод для получения матрицы масштабирования
        public static double[,] GetScalingMatrix(double scaleFactor)
        {
            return new double[,]
            {
                { scaleFactor, 0, 0, 0 },
                { 0, scaleFactor, 0, 0 },
                { 0, 0, scaleFactor, 0 },
                { 0, 0, 0, 1 }
            };
        }
        public static double[,] GetParallelTransformMatrix(double x, double y, double z)
        {
            return new double[4, 4]
            {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { x, y, z, 1 }
            };
        }

        // Метод для получения матрицы косого сдвига (shear)
        public static double[,] GetObliqueShiftMatrix(char axis1, char axis2, double factor)
        {
            var matrix = CreateIdentityMatrix();
            if (axis1 == 'X' && axis2 == 'Y') matrix[0, 1] = factor;
            else if (axis1 == 'X' && axis2 == 'Z') matrix[0, 2] = factor;
            else if (axis1 == 'Y' && axis2 == 'X') matrix[1, 0] = factor;
            else if (axis1 == 'Y' && axis2 == 'Z') matrix[1, 2] = factor;
            else if (axis1 == 'Z' && axis2 == 'X') matrix[2, 0] = factor;
            else if (axis1 == 'Z' && axis2 == 'Y') matrix[2, 1] = factor;
            return matrix;
        }
        public static double[] ConvertTo1DArray(double[,] matrix)
        {
            double[] result = new double[matrix.Length];
            Buffer.BlockCopy(matrix, 0, result, 0, sizeof(double) * matrix.Length);
            return result;
        }
    }
}
