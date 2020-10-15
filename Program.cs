using System;

namespace ConsoleApp1
{
    class Program
    {
		 struct RGB
		{
			public int R;
			public int G;
			public int B;
		};

		 struct XYLv
		{
			public double X;
			public double Y;
			public double Lv;
		};


	    static string min_Dist(RGB[] rgb60, RGB[] rgb90, RGB[] rgb120, XYLv[] xylv60, XYLv[] xylv90, XYLv[] xylv120, int n)
		{
			double min = double.MaxValue;
			double[,,] data = new double[n,n,n];
			string[,,] indicator = new string[n,n,n];

			for(int i = 0; i < n; i++)
			{
				for(int k = 0; k < n; k++)
				{
					for (int m = 0; m < n; m++)
					{
						indicator[i,k,m] = rgb60[i].R + "," + rgb60[i].G + "," + rgb60[i].B
							+ "/" + rgb90[k].R + "," + rgb90[k].G + "," + rgb90[k].B
							+ "/" + rgb120[m].R + "," + rgb120[m].G + "," + rgb120[m].B;
					}
				}
			}

			for (int i = 0; i < n; i++)
			{
				for (int k = 0; k < n; k++)
				{
					for (int m = 0; m < n; m++)
					{
						data[i, k, m] = Math.Sqrt(Math.Pow(xylv60[i].X - xylv90[k].X, 2) + Math.Pow(xylv60[i].Y - xylv90[k].Y, 2))
							+ Math.Sqrt(Math.Pow(xylv90[k].X - xylv120[m].X, 2) + Math.Pow(xylv90[k].Y - xylv120[m].Y, 2))
							+ Math.Sqrt(Math.Pow(xylv60[i].X - xylv120[m].X, 2) + Math.Pow(xylv60[i].Y - xylv120[m].Y, 2));
					}
				}
			}

			int[] index = new int[3];

			for (int i = 0; i < n; i++)
				for (int k = 0; k < n; k++)
					for (int m = 0; m < n; m++)
					{
						if (min > data[i, k, m])
						{
							min = data[i, k, m];
							index[0] = i;
							index[1] = k;
							index[2] = m;
						}
						Console.WriteLine((i * n * n + k * n + m) + ") min : " + min + ", data[i] : " + data[i, k, m]);
					}
			return indicator[index[0], index[1], index[2]];
		}


		static void Main(string[] args)
        {
			const int n = 3;
			RGB[] rgb60 = new RGB[n];
			rgb60[0].R = 500; rgb60[0].G = 377; rgb60[0].B = 333;
			rgb60[1].R = 151; rgb60[1].G = 369; rgb60[1].B = 181;
			rgb60[2].R = 145; rgb60[2].G = 367; rgb60[2].B = 317;

			RGB[] rgb90 = new RGB[n]; 
			rgb90[0].R = 317; rgb90[0].G = 167; rgb90[0].B = 54;
			rgb90[1].R = 242; rgb90[1].G = 96; rgb90[1].B = 458;
			rgb90[2].R = 338; rgb90[2].G = 492; rgb90[2].B = 464;

			RGB[] rgb120 = new RGB[n];
			rgb120[0].R = 188; rgb120[0].G = 230; rgb120[0].B = 71;
			rgb120[1].R = 448; rgb120[1].G = 247; rgb120[1].B = 504;
			rgb120[2].R = 71; rgb120[2].G = 108; rgb120[2].B = 160;

			XYLv[] xylv60 = new XYLv[n];
			xylv60[0].X = 0.306; xylv60[0].Y = 0.313; xylv60[0].Lv = 908;
			xylv60[1].X = 0.309; xylv60[1].Y = 0.312; xylv60[1].Lv = 899;
			xylv60[2].X = 0.310; xylv60[2].Y = 0.319; xylv60[2].Lv = 898;

			XYLv[] xylv90 = new XYLv[n];
			xylv90[0].X = 0.304; xylv90[0].Y = 0.312; xylv90[0].Lv = 902;
			xylv90[1].X = 0.302; xylv90[1].Y = 0.319; xylv90[1].Lv = 904;
			xylv90[2].X = 0.306; xylv90[2].Y = 0.313; xylv90[2].Lv = 902;

			XYLv[] xylv120 = new XYLv[n]; ;
			xylv120[0].X = 0.309; xylv120[0].Y = 0.311; xylv120[0].Lv = 907;
			xylv120[1].X = 0.304; xylv120[1].Y = 0.311; xylv120[1].Lv = 895;
			xylv120[2].X = 0.307; xylv120[2].Y = 0.320; xylv120[2].Lv = 907;

	
			string ans = Program.min_Dist(rgb60, rgb90, rgb120, xylv60, xylv90, xylv120, n);
			Console.WriteLine("result(ans) : " + ans);
        }
    }
}
