using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace hackerrank
{
    internal class Turnstile
    {
        private class PersonTurn
        {
            public int ID;
            public int Time;
            public int Direction;
            public PersonTurn(int id, int time, int direction)
            {
                ID = id;
                Time = time;
                Direction = direction;
            }
        }
        internal static void Run()
        {
            #region Sample Input 0
            List<int> times = [0, 0, 1, 5];
            List<int> direction = [0, 1, 1, 0];
            #endregion



            int n = times.Count;
            int lastSecond = times[n - 1];
            int prevTurnstile = -1;
            Queue<int> qEnter = new Queue<int>();
            Queue<int> qExit = new Queue<int>();

            var personTurns = new List<PersonTurn>();

            for(int i=0;i < n; i++)
            {
                personTurns.Add(new PersonTurn(i, times[i], direction[i]));
            }
            for (int i = 0; i <=lastSecond; i++)
            {
                prevTurnstile = NextTurnstile(prevTurnstile);

                var persons = personTurns.Where(x => x.Time == i);
                if (persons==null || !persons.Any())
                {
                    PassThrough(ref prevTurnstile, qEnter, qExit);

                    continue;
                }
                
                foreach(var p in persons)
                {

                    if (p.Direction == 0)
                    {
                        qEnter.Enqueue(p.ID);
                    }
                    else
                    {
                        qExit.Enqueue(p.ID);
                    }
                }
                PassThrough(ref prevTurnstile,qEnter,qExit);
            }
        }
        internal static void PassThrough(ref int prevTurnstile, Queue<int> enter, Queue<int> exit)
        {
            prevTurnstile = NextTurnstile(prevTurnstile);
            if (prevTurnstile == 0)
            {
                if (enter.Any())
                    Console.WriteLine(enter.Dequeue());
                prevTurnstile = 0;
            }
            else
            {
                if(exit.Any())
                    Console.WriteLine(exit.Dequeue());
                prevTurnstile = 1;
            }
        }
        internal static int NextTurnstile(int prevTurnstile)
        {
            int val= 1;
            switch (prevTurnstile)
            {
                case -1://no turnstile
                    val = 1;
                    break;
                case 0://enter
                    val = 0;
                    break;
                case 3://exit
                    val = 1;
                    break;
            }
            return val;
        }
    }
}
