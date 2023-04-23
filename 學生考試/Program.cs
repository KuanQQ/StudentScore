using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 學生考試
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var student = new Studert();
			student.Name = "考試超人";
			student.English = 80;
			student.Chinese = 77;
			student.MathScore = 55;
			Console.WriteLine(student.Score());
			student.MaxAndMinScore();
		}
		class Studert //學生基本資料
		{
			public string Name { get; set; }
			public int English { get; set; }
			public int Chinese { get; set; }
			public int MathScore { get; set; }
			public string Score()
			=> $"學生:{Name},英文{English}分,國文{Chinese}分,數學{MathScore}分,總分{TotalScore()},平均{AvgScore()}分";
			public int TotalScore() //算總分
			=> English + Chinese + MathScore;
			public double AvgScore() //算平均分
			{
				List<int> scores = new List<int> { English, Chinese, MathScore };
				double avgScore = scores.Average();
				return Math.Round(avgScore, MidpointRounding.AwayFromZero);
			}
			public void MaxAndMinScore() //顯示最高和最低分的科目和分數
			{
				List<(string subject, int score)> scores = new List<(string, int)>
				{
					("英文", English),
					("國文", Chinese),
					("數學", MathScore)
				};
				int maxScore = scores.Max(s => s.score);
				int minScore = scores.Min(s => s.score);
				string maxSubject = scores.First(s => s.score == maxScore).subject;
				string minSubject = scores.First(s => s.score == minScore).subject;
				Console.WriteLine($"最高分數：{maxSubject} {maxScore} 分");
				Console.WriteLine($"最低分數：{minSubject} {minScore} 分");
			}
		}
	}
}