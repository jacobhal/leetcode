using System;

namespace EggDrop
{
    /*
     * The problem statement is this: "Given a number of eggs n and a number of floors f,
     * how many egg drops do we at least have to do in order to know between which floors the egg breaks?"
     *
     *
     *
     * Eggs are on the left 'rows'. Floors are on the top 'cols'.
     *                                             Floors
     *           0  1  2  3  4  5  6  7  8  9  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27
     *        0  0  0  0  0  0  0  0  0  0  0  0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0   0
     *        1  0  1  2  3  4  5  6  7  8  9  10  11  12  13  14  15  16  17  18  19  20  21  22  23  24  25  26  27
     *     e  2  0  1  2  2  3  3  3  4  4  4  4   5   5   5   5   5   6   6   6   6   6   6   7   7   7   7   7   7
     *     g  3  0  1  2  2  3  3  3  3  4  4  4   4   4   4   4   5   5   5   5   5   5   5   5   5   5   5   6   6
     *     g  4  0  1  2  2  3  3  3  3  4  4  4   4   4   4   4   4   5   5   5   5   5   5   5   5   5   5   5   5
     *     s  5  0  1  2  2  3  3  3  3  4  4  4   4   4   4   4   4   5   5   5   5   5   5   5   5   5   5   5   5
     *        6  0  1  2  2  3  3  3  3  4  4  4   4   4   4   4   4   5   5   5   5   5   5   5   5   5   5   5   5
     *
     */
    class Program
	{
		static void Main(string[] args)
		{

            int n = 2, k = 10;
            int eggDropsRecursive = EggDrop(n, k);
            int eggDropsDP = EggDropDP(n, k);

            Console.WriteLine("Number of egg drops for " + n + " eggs and " + k + " floors: " + eggDropsRecursive);
            Console.WriteLine("Number of egg drops for " + n + " eggs and " + k + " floors: " + eggDropsDP);

        }

        /*
         * Dynamic programming solution for the egg drop problem.
         * See the following video for a good explanation and example code: https://www.youtube.com/watch?v=iOaRjDT0vjc&list=PLiQ766zSC5jM2OKVr8sooOuGgZkvnOCTI&index=2
         * 
         */
        static int EggDropDP(int n, int f)
        {
            int[,] eggDrops = new int[n + 1, f + 1];

            // Base case: One floor or no floors
            for (int eggs = 1; eggs <= n; eggs++)
            {
                eggDrops[eggs, 0] = 0;
                eggDrops[eggs, 1] = 1;
            }

            // Base case: One egg
            for (int floors = 1; floors <= f; floors++)
            {
                eggDrops[1, floors] = floors;
            }

            int res = 0;

            // Solve all subproblems
            for (int i = 2; i <= n; i++)
            {
                for (int j = 2; j <= f; j++)
                {
                    // Set answer to this subproblem
                    eggDrops[i, j] = int.MaxValue; // Set the current egg/floor combination to max value of integer

                    // We simulate every floor for this subproblem
                    for (int testFloor = 1; testFloor <= j; testFloor++)
                    {
                        // Case 1: the egg breaks and we have to remove one egg and go down one floor
                        // Case 2: the egg does not break and we keep the same amount of eggs but subtract the current floor from our total floors
                        // in order to get how many floors there are left to investigate

                        // Choose the worst case/outcome
                        res = Math.Max(eggDrops[i-1, testFloor-1], eggDrops[i, j-testFloor]);
                        /*
                            After we get the cost of the WORST outcome we add 1 to that worst outcome to simulate
                            the fact that we are going to do a test from THIS subproblem.

                            The answer to this problem is 1 PLUS the cost of the WORST SITUATION that
                            happens after our action at this subproblem.
                        */
                        res++;

                        /*
                            Did we reach a BETTER (lower) amount of drops that guarantee that we can
                            find the floor where eggs begin to break?
                         */
                        eggDrops[i, j] = Math.Min(res, eggDrops[i, j]);

                    }

                }
            }


            return eggDrops[n, f];
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
                // Case 1: the egg breaks and we have to remove one egg and go down one floor
                // Case 2: the egg does not break and we keep the same amount of eggs but subtract the current floor from our total floors
                // Example 2: If we have 6 floors and 3 eggs and the egg does not break, calculate 6 - 5 = 1 and so we have 1 floor left to investigate
                res = Math.Max(EggDrop(n-1, i-1), EggDrop(n, f-i));

                if (res < min)
                    min = res;
            }

            return min + 1;
		}
	}
}
