using System.Drawing;
using System.Text.Encodings.Web;

namespace hw2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Ex1();
			//Ex2();
			//Ex3();
			//Ex4();
			//Ex5();
			//Ex6();
			//Ex7();
			//Ex8();
			Ex9();
		}   
		static void Ex1()
		{
			// arr
			const int sizeA = 5;
			int[] A = new int[sizeA];
			for (int i = 0; i < sizeA; i++) A[i] = Convert.ToInt32(Console.ReadLine());

			// matrix
			Random random = new Random();
			const int rows = 3;
			const int cols = 4;
			float[,] B = new float[rows, cols];
			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++) B[r, c] = (float)(random.NextDouble() * 100);
			}

			//output
			foreach (int el in A) { Console.Write(el + " "); }
			Console.WriteLine();
			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++) Console.Write(B[r, c] + " ");
				Console.WriteLine();
			}

			//search in A
			int max = A[0]; int min = A[0]; int sum = 0; int multiple = 1; int sum_even = 0;
			foreach (var item in A)
			{
				if (item % 2 == 0) sum_even += item;
				if (item > max) max = item;
				else if (item < min) min = item;
				sum += item;
				multiple *= item;
			}
			Console.WriteLine($"\nMax value: {max}, Min value: {min}, Sum: {sum}, Multiple: {multiple}, Sum of even items: {sum_even}");

			//search in B
			float _max = B[0, 0]; float _min = B[0, 0]; float _sum = 0; float _multiple = 1;
			for (int c = 0; c < cols; c++)
			{
				float? col_sum = null;
				if (c % 2 == 0)
				{
					col_sum = 0;
				}
				for (int r = 0; r < rows; r++)
				{
					float item = B[r, c];

					if (col_sum != null)
					{
						col_sum += item;
					}
					if (item > _max) _max = item;
					else if (item < _min) _min = item;
					_sum += item;
					_multiple *= item;
				}
				if (col_sum != null) Console.Write($"Col №{c + 1} has sum {col_sum} ");
			}
			Console.WriteLine($"\nMax value: {_max}, Min value: {_min}, Sum: {_sum}, Multiple: {_multiple}");
		}
		static void Ex2()
		{
			//create and print arr
			Random random = new Random();
			const int size = 5;
			int[,] arr = new int[5,5];
			for (int r = 0; r < size; r++)
			{
				for (int c = 0; c < size; c++)
				{
					arr[r, c] = random.Next(-100, 100);
					Console.Write($"{arr[r, c],4} "); 
				}
				Console.WriteLine();
			}
			//find min and max 
			int min = arr[0,0]; int max = arr[0, 0];
			int MinLinearInd = -1; int MaxLinearInd = -1;
			for (int r = 0; r < size; ++r)
			{
				for (int c = 0; c < size; c++)
				{
					if (arr[r, c] < min)
					{
						min = arr[r, c];
						MinLinearInd = r * size + c;
					}
					else if (arr[r, c] > max)
					{
						max = arr[r, c];
						MaxLinearInd = r * size + c;
					}
				}
			}
			Console.WriteLine($"\nМінімум: {min} (Індекс: {MinLinearInd})");
			Console.WriteLine($"Максимум: {max} (Індекс: {MaxLinearInd})");
			
			int StartInd = MaxLinearInd > MinLinearInd ? MinLinearInd : MaxLinearInd;
			int EndInd = MaxLinearInd < MinLinearInd ? MinLinearInd : MaxLinearInd;
			int sum = 0;
			for (int i = StartInd + 1; i < EndInd; ++i)
			{
				int r = i / size;
				int c = i % size;
				sum += arr[r, c];
			}
			Console.WriteLine($"Сума елементів між ними: {sum}");
		}
		static void Ex3()
		{
			string input = Console.ReadLine();
			char[] text = input.ToLower().ToCharArray();
			const int step = 3;
			// encrypt            
			char[] alphabet = new char[26];
			for (int i = 0; i < 26; i++)
			{
				// 'a' имеет код 97, 'a' + 1 = 'b' (98) и т.д.
				alphabet[i] = (char)('a' + i);
			}

			for (int i = 0; i < text.Length; i++)
			{
				int new_ind = (alphabet.IndexOf(text[i]) + step) % 26;
				text[i] = alphabet[new_ind];
			}
			Console.WriteLine(text);

			//decrypt
			for (int i = 0; i < text.Length; i++)
			{
				int new_ind = (alphabet.IndexOf(text[i]) - step + 26) % 26;
				text[i] = alphabet[new_ind];
			}
			Console.WriteLine(text);
		}
		static void Ex4()
		{
			Random rnd = new Random();
			const int row1 = 4;
			const int col1 = 2;
			int[,] matrix1 = new int[row1, col1];
			for (int r = 0; r < row1; r++)
			{
				for (int c = 0; c < col1; c++)
				{
					matrix1[r, c] = rnd.Next(0, 10);
					Console.Write($"{matrix1[r, c],3} ");
				}
				Console.WriteLine();
			}
			Console.WriteLine();

			const int row2 = 3;
			const int col2 = 5;
			int[,] matrix2 = new int[row2, col2];
			for (int r = 0; r < row2; r++)
			{
				for (int c = 0; c < col2; c++)
				{
					matrix2[r, c] = rnd.Next(0, 10);
					Console.Write($"{matrix2[r, c],3} ");
				}
				Console.WriteLine();
			}

			int number = 4;
			Console.WriteLine($"\nMultiple m1 by {number}: ");
			for (int r = 0; r < row1; r++)
			{
				for (int c = 0; c < col1; c++)
				{
					matrix1[r, c] *= number;
					Console.Write($"{matrix1[r, c],3} ");
				}
				Console.WriteLine();
			}
		}
		static void Ex5()
		{
			Console.WriteLine("Type your problem: ");
			string problem = Console.ReadLine();
			string[] arr = problem.Split(' ');
			switch (arr[1])
			{
				case ("+"):
					Console.WriteLine(Convert.ToInt32(arr[0]) + Convert.ToInt32(arr[2]));
					break;
				case ("-"):
					Console.WriteLine(Convert.ToInt32(arr[0]) - Convert.ToInt32(arr[2]));
					break;
			}
		}
		static void Ex6()
		{
			Console.WriteLine("type sentence: ");
			string text = Console.ReadLine();

			char[] arr = text.ToCharArray();
			int convert_step = 'A' - 'a';
			bool isNextUpper = true;

			for (int i = 0; i < arr.Length; i++)
			{
				if (arr[i] == '.' || arr[i] == '!' || arr[i] == '?') { isNextUpper = true; }

				if (isNextUpper)
				{
					if (char.IsLetter(arr[i]))
					{
						arr[i] = (char)((int)arr[i] + convert_step);
						isNextUpper = false;
					}
				}
			}
			Console.WriteLine(arr);
		}
		static void Ex7()
		{
			Console.WriteLine("type your text: ");
			string text = Console.ReadLine();
			Console.WriteLine("type ban word: ");
			string ban_word = Console.ReadLine();

			int count = text.Split(ban_word).Length - 1;
			Console.WriteLine($"{count} replaces of word {ban_word}");
			Console.WriteLine(text.Replace(ban_word, "***"));
		}
		static void Ex8()
		{
			Console.WriteLine("type text: ");
			string input = Console.ReadLine();
			Console.WriteLine("type step for cypher: ");
			int step = Convert.ToInt16(Console.ReadLine());

			char[] alphabet = new char[26];
			for (int i = 0; i < 26; i++)
			{	
				// 'a' имеет код 97, 'a' + 1 = 'b' (98) и т.д.
				alphabet[i] = (char)('a' + i);
			}

			char[] text = input.ToCharArray();
			for (int i = 0; i < text.Length; i++)
			{
				if (char.IsLetter(text[i]))
				{
					int new_ind = (alphabet.IndexOf(text[i]) + step) % 26;
					text[i] = alphabet[new_ind];
				}
				else { continue; }
			}
			Console.WriteLine(text);
		}
		static void Ex9()
		{
			Console.WriteLine("Type the size of array and multiple number: ");
			string[] input = Console.ReadLine().Split(' ');
            int rows = int.Parse(input[0]);
			int cols = int.Parse(input[1]);
			int multiplier = int.Parse(input[2]);

			int[,] arr = new int[rows, cols];
			Random rand = new Random();
			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					arr[r, c] = rand.Next(0, 10);
					Console.Write($"{arr[r, c]} ");
				}
				Console.WriteLine();
			}

			for (int r = 0; r < rows; r++)
			{
				for (int c = 0; c < cols; c++)
				{
					arr[r, c] *= multiplier;
					Console.Write($"{arr[r, c]} ");
				}
				Console.WriteLine();
			}
		}
	}
}
