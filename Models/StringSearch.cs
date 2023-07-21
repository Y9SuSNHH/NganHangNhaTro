using System;
namespace NganHangNhaTro.Models
{
    public class StringSearch
    {
        // Phương thức tính toán khoảng cách Levenshtein giữa hai chuỗi
        public static int LevenshteinDistance(string s1, string s2)
        {
            int[,] dp = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
                dp[i, 0] = i;

            for (int j = 0; j <= s2.Length; j++)
                dp[0, j] = j;

            for (int i = 1; i <= s1.Length; i++)
            {
                for (int j = 1; j <= s2.Length; j++)
                {
                    int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;
                    dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1] + cost);
                }
            }

            return dp[s1.Length, s2.Length];
        }

        // Phương thức tìm kiếm chuỗi gần đúng trong danh sách chuỗi
        public static string FindClosestMatch(string searchTerm, string[] searchList)
        {
            int minDistance = int.MaxValue;
            string closestMatch = string.Empty;

            foreach (string item in searchList)
            {
                int distance = LevenshteinDistance(searchTerm, item);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestMatch = item;
                }
            }

            return closestMatch;
        }
    }

}
