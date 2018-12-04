using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingCodeInterview.Solutions.ArraysAndStrings
{
    public class RotateMatrix
    {
        public static int[,] rotate90Degree(int[,] aMatrixToRotate)
        {
            int[,] rotatedMatrix = new int[aMatrixToRotate.GetLength(0), aMatrixToRotate.GetLength(1)];

            for (int i = 0; i < aMatrixToRotate.GetLength(0); i++)
            {
                for (int j = 0; j < aMatrixToRotate.GetLength(1); j++)
                {
                    rotatedMatrix[j, aMatrixToRotate.GetLength(0) - 1 - i] = aMatrixToRotate[i, j];
                }
            }

            return rotatedMatrix;
        }

        public static void rotate90DegreeLayer(int[,] aMatrixToRotate)
        {
            int[,] rotatedMatrix = new int[aMatrixToRotate.GetLength(0), aMatrixToRotate.GetLength(1)];

            int layer = aMatrixToRotate.GetLength(0);

            for (int i = 0; i < layer/2; i++)
            {
                for (int j = i; j < layer-1-i; j++)
                {
                    
                    int temp =aMatrixToRotate[i,j];

                    //left to top
                    aMatrixToRotate[i,j] = aMatrixToRotate[layer-1-j, i];
                    //bottom to left
                    aMatrixToRotate[layer-1-j, i] = aMatrixToRotate[layer-1-i,layer-1-j];
                    //right to bottom
                    aMatrixToRotate[layer-1-i,layer-1-j] = aMatrixToRotate[j, layer-1-i];
                    //top to right via temp
                    aMatrixToRotate[j,layer-1-i] = temp;
                }
            }
                        
        }
    }
}