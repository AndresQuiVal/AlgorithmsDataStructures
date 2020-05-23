using System;
using System.Collections.Generic;

namespace DataStructAndAlgorithmsProject1.Infix__Postfix__Prefix_evaluation
{
	public class PostPreInfixEvaluation
	{
		//Infix to postfix
		public static string ToPostfix(string infix)
		{
			Stack<char> operators = new Stack<char>();
			string postfix = string.Empty;
			foreach (var item in infix)
			{
				if (IsOperator(item))
				{
					if (IsBinaryOperator(item))
					{
						while (operators.Count != 0 && 
							!IsOpeningParenthesis(operators.Peek()) && 
							HasHigherPrecedence(operators.Peek(), item))
							postfix += operators.Pop();
						operators.Push(item);
					}
					else if (IsClosingParenthesis(item))
					{
						while (operators.Count != 0 && !IsOpeningParenthesis(operators.Peek())) postfix += operators.Pop();
						if (operators.Count > 0) operators.Pop();
					}
					else operators.Push(item);
				}
				else postfix += item;
			}
			while (operators.Count != 0) postfix += operators.Pop();
			return postfix;
		}

		public static string ToPrefix(string infix)
		{
			Stack<char> operators = new Stack<char>();
			string postfix = string.Empty;
			for(int i = infix.Length - 1; i >= 0; i++)
			{
				if (IsOperator(infix[i]))
				{
					if (IsBinaryOperator(infix[i]))
					{
						while (operators.Count != 0 && 
							!IsOpeningParenthesis(operators.Peek()) && 
							HasHigherPrecedence(operators.Peek(), infix[i])) 
							postfix += operators.Pop();
						operators.Push(infix[i]);
					}
					else if (IsClosingParenthesis(infix[i]))
					{
						while (operators.Count != 0 && !IsOpeningParenthesis(operators.Peek())) postfix += operators.Pop();
						if (operators.Count > 0) operators.Pop();
					}
					else operators.Push(infix[i]);
				}
				else postfix += infix[i];
			}
			while (operators.Count != 0) postfix += operators.Pop();
			return postfix;
		}

		public static bool IsOperator(char item)
		{
			int binaryNumber = (int)item;
			return binaryNumber >= 40 && binaryNumber <= 47 && binaryNumber != 46 && binaryNumber != 44;
		}

		public static bool IsBinaryOperator(char item)
		{
			int byteRepr = (int)item;
			return byteRepr == 42 || byteRepr == 43 || byteRepr == 45 || byteRepr == 47;
		}

		public static bool HasHigherPrecedence(char last, char item)
		{ // or same associative rules
			if (last == char.Parse("*") || last == char.Parse("/"))
				return item == char.Parse("+") || item == char.Parse("-") || item == char.Parse("*") || item == char.Parse("/");
			return item == char.Parse("+") || item == char.Parse("-");
		}


		//Postfix to evaluation
		public static int PostfixToEvaluation(string postfix)
		{
			Stack<string> nums = new Stack<string>();
			foreach (var item in postfix)
			{
				if (IsBinaryOperator(item))
				{
					int op2 = int.Parse(nums.Pop()), op1 = int.Parse(nums.Pop());
					string _operator = item.ToString();
					int operation = PerformOperation(op1, op2, _operator) ?? 0;
					nums.Push(operation.ToString());
					continue;
				}
				nums.Push(item.ToString());
			}
			return int.Parse(nums.Pop());
		}

		public static int? PerformOperation(int op1, int op2, string _operator)
		{
			switch (_operator)
			{
				case "*": return op1 * op2;
				case "/": return op1 / op2;
				case "+": return op1 + op2;
				case "-": return op1 - op2;
			}
			return null;
		}

		public static bool IsOpeningParenthesis(char item) { return item == char.Parse("(") || item == char.Parse("{") || item == char.Parse("["); }

		public static bool IsClosingParenthesis(char item) { return item == char.Parse(")") || item == char.Parse("}") || item == char.Parse("]"); }

	//	public static bool CheckBalancedParentesis(string word)
	//	{
	//		Stack<char> balancedStack = new Stack<char>();
	//		foreach (var item in word)
	//		{
	//			if (item == char.Parse("(") || item == char.Parse("{") || item == char.Parse("["))
	//				balancedStack.Push(item);
	//			else if (item == char.Parse(")") || item == char.Parse("}") || item == char.Parse("]"))
	//			{
	//				if (balancedStack.Count == 0)
	//					return false;
	//				else if ((balancedStack.Peek() == char.Parse("(") && item == char.Parse(")")) ||
	//						(balancedStack.Peek() == char.Parse("[") && item == char.Parse("]")) ||
	//						(balancedStack.Peek() == char.Parse("{") && item == char.Parse("}")))
	//				{
	//					balancedStack.Pop();
	//					continue;
	//				}
	//				return false;

	//			}
	//		}
	//		return balancedStack.Count == 0;
	//	}
	//}

	//public class ListNode
	//{
	//	public int val;
	//	public ListNode next;
	//	public ListNode(int val = 0, ListNode next = null)
	//	{
	//		this.val = val;
	//		this.next = next;
	//	}
	}
}
