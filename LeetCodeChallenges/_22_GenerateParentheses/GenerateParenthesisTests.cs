using System.Collections;

namespace LeetCodeChallenges.Tests._22_GenerateParentheses;

public class GenerateParenthesisTests
{
    [Theory]
    [InlineData(1, new[] { "()" })]
    [InlineData(2, new[] { "(())", "()()" })]
    [InlineData(3, new[] { "((()))", "(()())", "(())()", "()(())", "()()()" })]
    public void Tests(int n, string[] result) =>
        Assert.Equal(result, GenerateParenthesis(n));

    private IEnumerable<string> GenerateParenthesis(int n, int open = 0, int close = 0, string sequence = "")
    {
        if (open == close && close == n)
            return new[] { sequence };
        
        if (open > n || close > open)
            return Array.Empty<string>();

        var left = GenerateParenthesis(n, open + 1, close, sequence + '(');
        var right = GenerateParenthesis(n, open, close + 1, sequence + ')');
        
        return left.Concat(right);
    }
}