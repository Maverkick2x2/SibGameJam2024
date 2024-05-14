public class Caterpillar : Bug
{
    public void SetScore(int value)
    {
        Hit.Invoke(value);
    }
}
