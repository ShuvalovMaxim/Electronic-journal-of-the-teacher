using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRepos;

namespace Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public static class CalcPointForCp
    {
        public static int Calc(int count, int done)
        {
            int pointPos = (done * 100) / count;
            return pointPos;
        }

        public static int CalcScoreLabOrPrac(List<Work> list)
        {
            int sum = 0;

            foreach (var item in list)            
                sum += item.Point;
            
            return sum / list.Count;
        }

        public static int CalcScoreGeneral(int wLek, int wLab, int wPrac, int wMore, int pLek, int pLab, int pPrac, int pMore)
        {
            var scoreGeneral = ((wLek * pLek) + (wLab * pLab) + (wPrac * pPrac) + (wMore * pMore)) / 100;
            return scoreGeneral;
        }
    }
}
