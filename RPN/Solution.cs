using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RPN
{
    public class Solution
    {
        // Leetcode stats
        // removed tryPop() calls as the hurt the metrics
        // still in the GitHub initial versions
        // Runtime 75ms - Beats 61.97% 
        // Memory 43.76MB - Beats 24.84%

        public int EvalRPN(string[] tokens)
        {
            // algorithm
            // push numbers onto the stack.
            // on operators pop the last 2 operands and
            // apply the operator. Push the result onto the stack 

            Stack<int> tokenStack = new Stack<int>();

            for (int i = 0; i < tokens.Length; i++)
            {
                string token = tokens[i];
                switch (token)
                {
                    case "+":
                        // second operand is always above first operand on the stack
                        int second = tokenStack.Pop();
                        int first = tokenStack.Pop();
                        int result = first + second;
                        tokenStack.Push(result);
                        break;

                    case "-":
                        second = tokenStack.Pop();
                        first = tokenStack.Pop();
                        result = first - second;
                        tokenStack.Push(result);
                        break;

                    case "/":
                        second = tokenStack.Pop();
                        first = tokenStack.Pop();
                        result = first / second ;
                        tokenStack.Push(result);
                        break;

                    case "*":
                        second = tokenStack.Pop();
                        first = tokenStack.Pop();
                        result = first * second;
                        tokenStack.Push(result);
                        break;

                    default:
                        int val = int.Parse(token);
                        tokenStack.Push(val);
                        break;
                }
            }

            if (tokenStack.Count != 1)
            {
                throw new Exception("invalid statement, one or more missing operands and operator(s)");
            }
            return tokenStack.Pop();
        }
    }
}
