
using System.Net.Http.Headers;

ScoringAlgrithm algrithm;

Console.WriteLine("Mens");

algrithm = new MensScoringAlgorithm();
Console.WriteLine(algrithm.GenerateScore(8,new TimeSpan(0,2,34)));
Console.WriteLine("Women");
algrithm = new WomansScoringAlgorithm();
Console.WriteLine(algrithm.GenerateScore(10,new TimeSpan(0,2,34)));

Console.WriteLine("Children");
algrithm = new ChildernsScoringAlgorithm();
Console.WriteLine(algrithm.GenerateScore(10, new TimeSpan(0, 2, 34)));
abstract class ScoringAlgrithm
{
    public int GenerateScore(int hits,TimeSpan time)
    {
        int score = CalculateBaseScore(hits);
        int reduction = CalculateReduction(time);
        return CalculatOverallScore(score, reduction);
    }

    public abstract int CalculatOverallScore(int score, int reduction);

    public abstract int CalculateReduction(TimeSpan time);

    public abstract int CalculateBaseScore(int hits);

}

class MensScoringAlgorithm:ScoringAlgrithm
{
    public override int CalculatOverallScore(int score, int reduction)
    {
        return score - reduction;
    }

    public override int CalculateReduction(TimeSpan time)
    {
        return (int) (time.TotalSeconds / 5);
    }

    public override int CalculateBaseScore(int hits)
    {
        return hits * 100;
    }
}
class WomansScoringAlgorithm : ScoringAlgrithm
{
    public override int CalculatOverallScore(int score, int reduction)
    {
        return score - reduction;
    }

    public override int CalculateReduction(TimeSpan time)
    {
        return (int)(time.TotalSeconds / 3);
    }
        
    public override int CalculateBaseScore(int hits)
    {
        return hits * 100;
    }
}
class ChildernsScoringAlgorithm : ScoringAlgrithm
{
    public override int CalculatOverallScore(int score, int reduction)
    {
        return score - reduction;
    }

    public override int CalculateReduction(TimeSpan time)
    {
        return (int)(time.TotalSeconds / 2);
    }

    public override int CalculateBaseScore(int hits)
    {
        return hits * 80;
    }
}