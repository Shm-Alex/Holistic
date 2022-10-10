using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public interface ISpliter
    {
        string Split(string toSplit);
    }
    public class SimpleSpliter : ISpliter
    {
        public string Split(string toSplit)
        {
            var sb = new StringBuilder();
           
            var wordLength = 1;
            for (int  i = toSplit.Length; i >0; i--)
                if (Char.IsUpper(toSplit[i-1]))
                {
                    sb.Insert(0,toSplit.Substring(i-1, wordLength) + ' ');
                    wordLength = 1;
                }
                else
                {
                   wordLength++;
                }
            return sb.ToString();
        }
    }
    public class FastSpliter : ISpliter
    {
        public string Split(string toSplit)
        {
            //allocate buffer memory
            char[] chars = new char[(toSplit.Length)*2+1];
            int charsPointer = 0;
            for (int i = 0; i < toSplit.Length; i++) 
            {


                if (Char.IsUpper(toSplit[i])) 
                {
                    chars[charsPointer] = ' ';
                    charsPointer++;
                }
                chars[charsPointer] = toSplit[i];
                charsPointer++;
            }
            char [] ret=new char[charsPointer+1];
            Array.Copy(chars, ret, charsPointer);
            return new string(ret);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            ISpliter []simpleSpliters = new ISpliter[] { new SimpleSpliter() ,new FastSpliter()};
            string [] testStrings=new string[] { "TodayIsALovelyDay","CCCCCCCCCCCC","МамаМылаРаму", "МамаМыла Раму" };
            foreach (var sp in simpleSpliters) 
            {
                foreach(var testString in testStrings)
                    Console.Write(sp.Split(testString));
                Console.WriteLine();
            };
            var ch= Console.ReadKey();
        }
    }
}
