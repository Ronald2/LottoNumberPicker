public class GameSettings
{
    public int MaxNumber { get; init; }
    public int TotalNumbers { get; init; }

    public void Validate()
    {
        if (MaxNumber <= 0)
        {
            throw new InvalidOperationException("MaxNumber must be greater than zero.");
        }

        if (TotalNumbers <= 0)
        {
            throw new InvalidOperationException("TotalNumbers must be greater than zero.");
        }

        if (TotalNumbers > MaxNumber)
        {
            throw new InvalidOperationException("TotalNumbers cannot be greater than MaxNumber.");
        }
    }
}
