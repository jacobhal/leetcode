using System;

namespace EggDrop
{
	/*
     * This assignment is not actually part of a kattis problem but a famous problem that is interesting.
     * The problem statement is this: "Given a number of eggs n and a number of floors f,
     * how many egg drops do we at least have to do in order to know between which floors the egg breaks?"
     *
     */
	class Program
	{
		static void Main(string[] args)
		{

            // TODO: use a 2d array for dynamic programming
            int[,] ServicePoint = new int[10, 9];

            int n = 2, k = 3;
            int eggDrops = EggDrop(n, k);

            Console.WriteLine("Number of egg drops for " + n + " eggs and " + k + " floors: " + eggDrops);

        }

        static int EggDrop(int n, int f)
		{
			// If there is only one egg, we have to start from the bottom and work our way up
			if (n == 1)
				return f;
			// If there is only one floor, one drop is all we need no many how many eggs we get
			if (f == 1)
				return 1;
			// If there are no floors, we don't have to do any drops
			if (f == 0)
				return 0;

            int min = int.MaxValue;
            int res;

            // Check all possible drop locations and return the minimum of these + 1
            for (int i = 1; i < f; i++)
            {
                res = Math.Max(EggDrop(n - 1, i - 1), EggDrop(n, f - i));

                if (res < min)
                    min = res;
            }

            return min + 1;
		}
	}
}
