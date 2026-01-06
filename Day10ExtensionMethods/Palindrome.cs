using System;

namespace Day10ExtensionMethods
{
    #region Palindrome Class

    /// <summary>
    /// Represents a Palindrome checker that determines
    /// whether a given string reads the same forwards and backwards.
    /// </summary>
    public static class Palindrome
    {
        #region Public Methods

        /// <summary>
        /// Determines whether the stored text is a palindrome.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the text is a palindrome; otherwise, <c>false</c>.
        /// </returns>
        
        public static bool IsPalindrome(this string text)
        {
            int left = 0, right = text.Length - 1;

            while (left < right)
            {
                if (text[left] != text[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }

        #endregion
    }

    #endregion
}
