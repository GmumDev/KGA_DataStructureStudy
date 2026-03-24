using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureStudy
{
	/// <summary>
	/// 필수 데이터 클래스 : 스택, 큐
	/// 타입: T
	/// 제한사항: 배열만 사용
	/// 
	/// Stack: 최대 사이즈 100
	///		Method
	///			void Push(T)
	///			T Pop()
	///		Field
	///			int topIndex;	// Last pushed item idx
	///	
	/// Queue: 
	///		Method
	///			void Enqueue(T)
	///			T Dequeue()
	///		Field
	///			int head;	// first idx
	///			int tail;	// last idx
	///	
	/// LinkedList:
	///		Method
	///			void AddFirst(T)
	///			void AddLast(T)
	///			T PopFirst()
	///			T PopLast()
	///		Field
	///			Node<T> head;
	///			Node<T> tail;
	/// 
	/// </summary>

	/*
		[Note]
		- T를 반환해야하는 상황에서 에러가 발생하면 default를 반환. int의 경우 0을 반환. 
		- Program.DoTest 함수를 실행시켜 개괄적 동작 확인이 가능
	*/
	public class Stack<T>
	{
		T[] data;
		int topIndex;
		public Stack() { data = new T[100]; topIndex = 0; }
		public void Add(T item) {
			if (topIndex == 100)
			{
				Console.Write("Out of memory. Failed to Add");
				return;
			}
			data[topIndex++] = item;
		}
		public T Pop() {
			if (topIndex == 0)
			{
				Console.WriteLine("No item in stack. Failed to pop");
				return default;
			}
			return data[--topIndex]; 
		}
		public void Print()
		{
			Console.Write("[");
			for(int i = 0; i < topIndex; i++)
			{
				Console.Write($"{data[i]}, ");
			}
			Console.WriteLine("]");
		}

	}
	public class Queue<T>
	{
		T[] data;
		int head;
		int tail;
		public Queue() { data = new T[100]; head = 0; tail = 0; }
		public void Enqueue(T item) {
			if (tail == 100)
			{
				ReAllocate();
				if (tail == 100)
				{
					Console.Write("Out of memory. Failed to enqueue");
					return;
				}
			}
			data[tail++] = item;
		}
		public T Dequeue()
		{
			if (tail == head)
			{
				ReAllocate();
				if (tail == head)
				{
					Console.WriteLine("No item in queue. Failed to dequeue");
					return default;
				}
			}
			return data[head++];
		}
		public void Print()
		{
			Console.Write("[");
			for (int i = head; i < tail; i++)
			{
				Console.Write($"{data[i]}, ");
			}
			Console.WriteLine("]");
		}
		private void ReAllocate()
		{
			int cnt = tail - head;
			for(int i = 0; i < cnt; i++)
			{
				data[i] = data[head + i];
			}
			head = 0;
			tail = cnt;
		}

	}
	public class LinkedList<T>
	{
		Node<T> head;
		Node<T> tail;
		public void AddFirst(T item)
		{
			if (head == null && tail == null)
			{
				Node<T> newNode = new Node<T>();
				newNode.data = item;
				head = newNode;
				tail = newNode;
			}
			else if (head == null)
			{
				Node<T> newNode = new Node<T>();
				newNode.data = item;
				newNode.next = tail;
				head = newNode;
			}
			else
			{
				Node<T> newNode = new Node<T>();
				newNode.data = item;
				newNode.next = head;
				head.prev = newNode;
				head = newNode;
			}
		}
		public void AddLast(T item)
		{
			if (head == null && tail == null)
			{
				Node<T> newNode = new Node<T>();
				newNode.data = item;
				head = newNode;
				tail = newNode;
			}
			else if (tail == null)
			{
				Node<T> newNode = new Node<T>();
				newNode.data = item;
				newNode.prev = head;
				tail = newNode;
			}
			else
			{
				Node<T> newNode = new Node<T>();
				newNode.data = item;
				newNode.prev = tail;
				tail.next = newNode;
				tail = newNode;
			}
		}
		public void Print()
		{
			Node<T> e = head;
			Console.Write("[");
			while (e != null)
			{
				Console.Write(e.data + ", ");
				e = e.next;
			}
			Console.Write("]");
			Console.WriteLine();
		}
		public T PopFirst()
		{
			if(head == null)
			{
				Console.WriteLine("LinkedList empty. Failed to PopFirst");
				return default;
			}
			T val = head.data;

			if (head == tail)
			{
				tail = null;
			}

			head = head.next;
			if(head != null)
				head.prev = null;
			return val;
		}
		public T PopLast()
		{
			if (tail == null)
			{
				Console.WriteLine("LinkedList empty. Failed to PopLast");
				return default;
			}
			T val = tail.data;

			if (head == tail)
			{
				head = null;
			}

			tail = tail.prev;
			if(tail != null)
				tail.next = null;
			return val;
		}
		public T GetFirst()
		{
			if (head == null)
			{
				Console.Write("LinkedList empty. Failed to GetFirst");
				return default;
			}
			T val = head.data;
			return val;
		}
		public T GetLast()
		{
			if (tail == null)
			{
				Console.Write("LinkedList empty. Failed to GetLast");
				return default;
			}
			T val = tail.data;
			return val;
		}
	}
	public class Node<T>
	{
		public T data;
		public Node<T> prev;
		public Node<T> next;
	}

	internal class Program
	{
		static void DoTest()
		{
			Console.WriteLine("[Stack]");
			Stack<int> stack = new Stack<int>();
			Console.Write("    Add(1);  ");
			stack.Add(1);
			stack.Print();
			Console.Write("    Add(2);  ");
			stack.Add(2);
			stack.Print();
			Console.Write("    Add(3);  ");
			stack.Add(3);
			stack.Print();

			Console.WriteLine();

			Console.Write($"    Pop(); {stack.Pop()} ");
			stack.Print();
			Console.Write($"    Pop(); {stack.Pop()} ");
			stack.Print();
			Console.Write($"    Pop(); {stack.Pop()} ");
			stack.Print();
			Console.Write($"    Pop(); {stack.Pop()} ");
			stack.Print();

			Console.WriteLine();

			Console.Write("    Add(i) in range(0,100);  ");
			for(int i = 0; i < 100; i++)
				stack.Add(i);

			Console.WriteLine();

			Console.Write("    Pop() in range(0,100);   ");
			for (int i = 0; i < 100; i++)
				Console.Write($"{stack.Pop()} ");

			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("[Queue]");
			Queue<int> queue = new Queue<int>();
			Console.Write("    Enqueue(1);  ");
			queue.Enqueue(1);
			queue.Print();
			Console.Write("    Enqueue(2);  ");
			queue.Enqueue(2);
			queue.Print();
			Console.Write("    Enqueue(3);  ");
			queue.Enqueue(3);
			queue.Print();

			Console.WriteLine();

			Console.Write($"    Dequeue(); {queue.Dequeue()} ");
			queue.Print();
			Console.Write($"    Dequeue(); {queue.Dequeue()} ");
			queue.Print();
			Console.Write($"    Dequeue(); {queue.Dequeue()} ");
			queue.Print();
			Console.Write($"    Dequeue(); {queue.Dequeue()} ");
			queue.Print();

			Console.WriteLine();

			Console.Write("    Enqueue(1);  ");
			queue.Enqueue(1);
			queue.Print();
			Console.Write($"    Dequeue(); {queue.Dequeue()} ");
			queue.Print();
			Console.Write($"    Dequeue(); {queue.Dequeue()} ");
			queue.Print();

			Console.WriteLine();

			Console.Write("    Enqueue(2);  ");
			queue.Enqueue(2);
			queue.Print();
			Console.Write("    Enqueue(3);  ");
			queue.Enqueue(3);
			queue.Print();
			Console.Write($"    Dequeue(); {queue.Dequeue()} ");
			queue.Print();

			Console.WriteLine();

			Console.Write("    Enqueue(i) in range(0,100);  ");	
			for (int i = 0; i < 100; i++)
				queue.Enqueue(i); // there was 'one' element in que at the initial stage. so last queue.Enqueue(99) is out of memory

			Console.WriteLine();

			Console.Write("    Dequeue() in range(0,101);   ");
			for (int i = 0; i < 101; i++)
				Console.Write($"{queue.Dequeue()} ");


			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("[LinkedList]");
			LinkedList<int> list = new LinkedList<int>();

			Console.Write("    AddFirst(1);  ");
			list.AddFirst(1);
			list.Print();
			Console.Write("    AddFirst(2);  ");
			list.AddFirst(2);
			list.Print();
			Console.Write("    AddFirst(3);  ");
			list.AddFirst(3);
			list.Print();

			Console.WriteLine();

			Console.Write($"    PopFirst(); {list.PopFirst()} ");
			list.Print();
			Console.Write($"     PopLast(); {list.PopLast()} ");
			list.Print();
			Console.Write($"    PopFirst(); {list.PopFirst()} ");
			list.Print();
			Console.Write($"     PopLast(); {list.PopLast()} ");
			list.Print();
			Console.Write($"    PopFirst(); {list.PopFirst()} ");
			list.Print();

			Console.WriteLine();

			Console.Write("     AddLast(1);  ");
			list.AddLast(1);
			list.Print();
			Console.Write($"    PopFirst(); {list.PopFirst()} ");
			list.Print();
			Console.Write($"     PopLast(); {list.PopLast()} ");
			list.Print();


			Console.WriteLine();

			Console.Write("    AddFirst(2);  ");
			list.AddFirst(2);
			list.Print();
			Console.Write($"    PopFirst(); {list.PopFirst()} ");
			list.Print();
			Console.Write($"     PopLast(); {list.PopLast()} ");
			list.Print();

			Console.WriteLine();

			Console.Write("    AddFirst(1);  ");
			list.AddFirst(1);
			list.Print();
			Console.Write("     AddLast(1);  ");
			list.AddLast(2);
			list.Print();
			Console.Write("    AddFirst(1);  ");
			list.AddFirst(3);
			list.Print();
			Console.Write("     AddLast(1);  ");
			list.AddLast(4);
			list.Print();
			Console.Write("    AddFirst(1);  ");
			list.AddFirst(5);
			list.Print();

			Console.WriteLine();

			Console.Write($"     PopLast(); {list.PopLast()} ");
			list.Print();
			Console.Write($"     PopLast(); {list.PopLast()} ");
			list.Print();
			Console.Write($"     PopLast(); {list.PopLast()} ");
			list.Print();
			Console.Write($"     PopLast(); {list.PopLast()} ");
			list.Print();
			Console.Write($"     PopLast(); {list.PopLast()} ");
			list.Print();

			Console.WriteLine();

			Console.Write("    AddFirst(i) AddLast(i) in range(0,100);  ");
			for (int i = 0; i < 100; i++)
			{
				list.AddFirst(i);
				list.AddLast(i);
			}

			Console.WriteLine();

			Console.Write("    PopFirst() in range(0,201);   ");
			for (int i = 0; i < 201; i++)
			{
				Console.Write($"{list.PopFirst()} ");
			}

			Console.WriteLine();

		}
		static void Main(string[] args)
		{

			DoTest();

		}
	}
}
