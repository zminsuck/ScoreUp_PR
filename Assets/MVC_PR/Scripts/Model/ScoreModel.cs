using System;

public class ScoreModel
{
    public int Current { get; private set; }
    public event Action<int> OnChanged;

    public ScoreModel(int initial)
    {
        Current = initial;
        OnChanged?.Invoke(Current);
    }

    public void Add(int amount)
    {
        Current += amount;
        OnChanged?.Invoke(Current);
    }
}