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
                        if (!tokenStack.TryPop(out int second))
                        {
                            throw new Exception("malformed statement, missing operand for operator at position {i}");
                        }
                        if (!tokenStack.TryPop(out int first))
                        {
                            throw new Exception("malformed statement, missing operand for operator at position {i}");
                        }
                        int result = first + second;
                        tokenStack.Push(result);
                        break;

                    case "-":
                        if (!tokenStack.TryPop(out second))
                        {
                            throw new Exception("malformed statement, missing operand for operator at position {i}");
                        }
                        if (!tokenStack.TryPop(out first))
                        {
                            throw new Exception("malformed statement, missing operand for operator at position {i}");
                        }
                        result = first - second;
                        tokenStack.Push(result);
                        break;

                    case "/":
                        if (!tokenStack.TryPop(out second))
                        {
                            throw new Exception("malformed statement, missing operand for operator at position {i}");
                        }
                        if (!tokenStack.TryPop(out first))
                        {
                            throw new Exception("malformed statement, missing operand for operator at position {i}");
                        }
                        result = first / second ;
                        tokenStack.Push(result);
                        break;

                    case "*":
                        if (!tokenStack.TryPop(out second))
                        {
                            throw new Exception("malformed statement, missing operand for operator at position {i}");
                        }
                        if (!tokenStack.TryPop(out first))
                        {
                            throw new Exception("malformed statement, missing operand for operator at position {i}");
                        }
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
