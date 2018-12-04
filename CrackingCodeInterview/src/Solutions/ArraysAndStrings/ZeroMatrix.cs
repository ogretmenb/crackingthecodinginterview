using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrackingCodeInterview.Solutions.ArraysAndStrings
{
    public class ZeroMatrix
    {
        public static void Zero(int[,] aMatrixToZero)
        {
            //int[,] zeroedMatrix = new int[aMatrixToZero.GetLength(0), aMatrixToZero.GetLength(1)];
            bool[] zero_x = new bool[aMatrixToZero.GetLength(0)];
            bool[] zero_y = new bool[aMatrixToZero.GetLength(1)];
            Dictionary<char, bool> dicMap = new Dictionary<char, bool>();
            for (int i = 0; i < aMatrixToZero.GetLength(0); i++)
            {
                for (int j = 0; j < aMatrixToZero.GetLength(1); j++)
                {
                    if (aMatrixToZero[i, j] == 0)
                    {
                        zero_x[i] = true;
                        zero_y[j] = true;
                    }
                }
            }
            for (int k = 0; k < zero_x.Length; k++)
            {
                if (zero_x[k])
                {

                    for (int j = 0; j < aMatrixToZero.GetLength(1); j++)
                    {
                        aMatrixToZero[k,j] =0;
                    }

                }
            }

            for (int k = 0; k < zero_y.Length; k++)
            {
                if (zero_y[k])
                {

                    for (int i = 0; i < aMatrixToZero.GetLength(1); i++)
                    {
                        aMatrixToZero[i,k] =0;
                    }

                }
            }

        }
    }
}