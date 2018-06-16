using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Console
{
    public struct Point
    {
        public double X;
        public double Y;
        public Point(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }
    }
    class Program
    {
        //线性拟合  拟合误差即R²值，该值越接近1则表示结果越准确
        static void Main(string[] args)
        {
            //设置一个包含9个点的数组
            Point[] array = new Point[9];
            array[0] = new Point(0, 66.7);
            array[1] = new Point(4, 71.0);
            array[2] = new Point(10, 76.3);
            array[3] = new Point(15, 80.6);
            array[4] = new Point(21, 85.7);
            array[5] = new Point(29, 92.9);
            array[6] = new Point(36, 99.4);
            array[7] = new Point(51, 113.6);
            array[8] = new Point(68, 125.1);
            //array[0] = new Point(2, 2.1);
            //array[1] = new Point(4, 4);
            //array[2] = new Point(5.2, 5);
            //array[3] = new Point(8, 8.1);
            //array[4] = new Point(10, 10.1);
            //array[5] = new Point(13, 13);
            //array[6] = new Point(14, 14);
            //array[7] = new Point(17, 17);
            //array[8] = new Point(19, 19);
            LinearRegression(array);
            System.Console.Read();
        }
        /// <summary>
        /// 对一组点使用最小二乘法进行线性回归
        /// </summary>
        /// <param name="parray"></param>
        public static void LinearRegression(Point[] parray)
        {
            if (parray.Length < 2)
            {
                System.Console.WriteLine("点个数不能少于2");
                return;
            }
            //求 X,Y平均值
            double averagex = 0; double averagey = 0;
            foreach (Point item in parray)
            {
                averagex += item.X;
                averagey += item.Y;
            }
            averagex /= parray.Length;
            averagey /= parray.Length;
            //经验回归系数的分子与分母
            double numerator = 0;
            double denominator = 0;
            foreach (Point p in parray)
            {
                numerator += (p.X - averagex) * (p.Y - averagey);
                denominator += (p.X - averagex) * (p.X - averagex);
            }
            //回归系数b（Regression Coefficient）
            double RCB = numerator / denominator;
            //回归系数a
            double RCA = averagey - RCB * averagex;
            System.Console.WriteLine("回归系数A： " + RCA.ToString("0.0000"));
            System.Console.WriteLine("回归系数B： " + RCB.ToString("0.0000"));
            System.Console.WriteLine(string.Format("方程为： y = {0} + {1} * x",
              RCA.ToString("0.0000"), RCB.ToString("0.0000")));
            //剩余平方和与回归平方和
            double residualSS = 0;  //（Residual Sum of Squares）
            double regressionSS = 0; //（Regression Sum of Squares）
            foreach (Point p in parray)
            {
                residualSS +=
                  (p.Y - RCA - RCB * p.X) *
                  (p.Y - RCA - RCB * p.X);
                regressionSS +=
                  (RCA + RCB * p.X - averagey) *
                  (RCA + RCB * p.X - averagey);
            }
            //计算R^2的值
            numerator = 0;denominator = 0;
            foreach (var item in parray)
            {
                denominator += Math.Pow((item.Y - averagey), 2.0);
                numerator += Math.Pow((item.Y - (item.X * RCB + RCA)), 2.0);
            }
            double RSquare = 1 - numerator / denominator;
            System.Console.WriteLine("剩余平方和： " + residualSS.ToString("0.0000"));
            System.Console.WriteLine("回归平方和： " + regressionSS.ToString("0.0000"));
            //拟合误差越接近1则表示越准确
            System.Console.WriteLine("R平方值(拟合误差)：{0}", RSquare.ToString("0.0000"));
        }

    }

}
