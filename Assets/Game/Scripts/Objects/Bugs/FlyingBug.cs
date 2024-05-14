public class FlyingBug : Bug
{
    public void SetFightScore(int value)
    {
        Fight.Invoke(value);
    }
}
