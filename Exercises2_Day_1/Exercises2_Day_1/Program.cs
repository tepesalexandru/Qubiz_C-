using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Exercises2_Day_1
{
    class Program
    {
        
        static int FromRomanToArab(string s)
        {
            Dictionary<char, int> value = new Dictionary<char, int>();
            value.Add('I', 1);
            value.Add('V', 5);
            value.Add('X', 10);
            value.Add('L', 50);
            value.Add('C', 100);
            value.Add('D', 500);
            value.Add('M', 1000);

            int len = s.Length;
            int n = 0, c = 0;
            for (int i = 0; i < len; i++)
            {
                if (i < len - 1 && value[s[i]] < value[s[i + 1]])
                {
                    c = value[s[i + 1]] - value[s[i]];
                    i++;
                } else
                {
                    c = value[s[i]];
                }
                n += c;
            }

            return n;

        }
        static string FromArabToRoman(int n)
        {
            Dictionary<int, string> value = new Dictionary<int, string>();
            value.Add(1, "I");
            value.Add(4, "IV");
            value.Add(5, "V");
            value.Add(9, "IX");
            value.Add(10, "X");
            value.Add(40, "XL");
            value.Add(50, "L");
            value.Add(90, "XC");
            value.Add(100, "C");
            value.Add(400, "CD");
            value.Add(500, "D");
            value.Add(900, "CM");
            value.Add(1000, "M");

            string s = "";
            int idx = 12;
            
            while (n != 0)
            {
                int div = n / value.ElementAt(idx).Key;
                n = n % value.ElementAt(idx).Key;
                while (div != 0)
                {
                    s += value.ElementAt(idx).Value;
                    div--;
                }
                idx--;
            }
            return s;

        } 
        static bool IsPalindrome(LinkedList l)
        {
            LinkedList simmetric = new LinkedList();

            Node temp = l.head;
            while (temp != null)
            {
                simmetric.InsertNode(temp.value);
                temp = temp.next;
            }

            simmetric.Reverse();

            while (l.head.next != null)
            {
                if (l.head.value != simmetric.head.value)
                {
                    return false;
                }
                //Console.WriteLine(l.head.value + " " + simmetric.head.value);
                l.head = l.head.next;
                simmetric.head = simmetric.head.next;
            }
            return true;
        }
        static void Hanoi(int n, char from, char to, char aux)
        {
            if (n == 1)
            {
                Console.WriteLine($"Move disk 1 from {from} to {to}");
                return;
            }
            Hanoi(n - 1, from, aux, to);
            Console.WriteLine($"Move disk {n} from {from} to {to}");
            Hanoi(n - 1, aux, to, from);
        }

        static void Main(string[] args)
        {
            LinkedList x = new LinkedList();
            x.InsertNode(1);
            x.InsertNode(3);
            x.InsertNode(3);
            x.InsertNode(5);
            x.InsertNode(2);
            x.InsertNode(3);
            x.InsertNode(3);
            x.InsertNode(5);
            x.InsertNode(1);

            x.Sort();
            x.Print();

            Console.WriteLine();
            Console.WriteLine(x.GetNthElementFromEnd(7));

            Console.ReadKey();
        }
    }
}
