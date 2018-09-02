using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsynchronousFileSystem
{

    public class Studnet
    {
        public string Name = "윤정현";

        public Studnet(int koreanScore, int mathScore)
        {
            KoreanScore = koreanScore;
            MathScore = mathScore;

            Total = koreanScore + mathScore;
            Avg = Total / 2;
        }

        public int StudentID = 30212;
        public int KoreanScore { get; set; }
        public int MathScore { get; set; }
        public int Avg { get; set; }
        public int Total { get; set; }


    

        public override string ToString()
        {
            return "이름"+Name+"학번"+StudentID+"국어점수"+KoreanScore+"수학점수"+MathScore+"총점수"+Total+"평균"+Avg;
        }


    }
}
