using System;

namespace bst
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 1};
            int target = 2;
            //int index = bst_search(nums, target, 0);
            //Console.WriteLine(index);


            //int sqrtnum = sqrt(4);
            //Console.Write(sqrtnum);

            //int guessedNum = GuessNumber(3);
            //Console.WriteLine(guessedNum);

            //int index = Search(nums, target);
            //Console.WriteLine(index);

            //int badVersion = FirstBadVersion(5);
            //Console.WriteLine(badVersion);

            int peakNumber = FindPeakElement(nums);
        }

        private static int bst_search(int[] nums, int target, int startindex)
        {
            int mid = nums.Length / 2;
            if (nums[mid] == target)
                return mid + startindex;
            else if (mid == 0)
                return -1;

            if (nums[mid] > target)
            {
                nums = nums.AsSpan(0, mid).ToArray();
                return bst_search(nums, target, startindex);
            }
            else
            {              
                nums = nums.AsSpan(mid, nums.Length - mid).ToArray();
                return bst_search(nums, target, mid + startindex);
            }
        }

        private static int sqrt(int x)
        {
            if (x < 2) return x;

            int start = 2;
            int end = x / 2; 
            
            int mid = 0;
            long num;

            while(start <= end)
            {
                mid = start + (end-start) / 2;

                num = (long)mid * mid;

                if (num > x)
                    end = mid - 1;
                else if (num < x)
                    start = mid + 1;
                else
                    return mid;
            }

            return end;
        }

        private static int GuessNumber(int num)
        {
            int mid = num/2;
            while (mid != num)
            {                
                if (Guess(num, mid) == 1)
                    mid--;
                else
                    mid++;
            }
            return mid;
        }

        private static int Guess(int num, int guess)
        {
            if (num < guess)
                return 1;
            if (num > guess)
                return -1;
            else
                return 0;
        }

        private static int Search(int[] nums, int target)
        {
            int start = 0;
            int mid;
            int end = nums.Length;

            while (start <= end)
            {
                mid = start + (end - start) / 2;

                if (nums[mid] == target)
                    return mid;

                if (nums[mid] >= nums[start])
                {
                    if (nums[start] <= target && nums[mid] >= target)
                    {
                        end = mid - 1; 
                    }
                    else
                    {
                        start = mid + 1;
                    }
                }
                else
                {
                    if (nums[mid] <= target && nums[end] >= target)
                    {
                        start = mid + 1;
                    }
                    else
                    {
                        end = mid - 1;
                    }
                }
            }
            return -1;
        }

        private static bool isBadVersion(int givenVersion)
        {
            return givenVersion >= 8;
        }

        private static int FirstBadVersion(int n)
        {
            int left = 1;
            int right = n;
            int mid;

            while (left <= right)
            {
                mid = left + (right - left) / 2;

                if (isBadVersion(mid) && !isBadVersion(mid - 1))
                    return mid;

                if (isBadVersion(mid))
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            return -1;



            //int left = 1;
            //int right = n;
            //while (left < right)
            //{
            //    int mid = left + (right - left) / 2;
            //    if (isBadVersion(mid))
            //    {
            //        right = mid;
            //    }
            //    else
            //    {
            //        left = mid + 1;
            //    }
            //}
            //return left;
        }

        private static int FindPeakElement(int[] nums)
        {
            int left = 0;
            int right = nums.Length;
            int mid;

            while (left < right)
            {
                mid = left + (right - left) / 2;

                if (nums[mid - 1] > nums[mid])
                    return mid - 1;
                else
                    left = mid;
            }

            return -1; 
        }
    }
}
