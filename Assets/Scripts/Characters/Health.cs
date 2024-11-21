using UnityEngine;

public class Health
{
    public Health(int max)
    {
        Max = new Stat<int>(max);
        Current = new Stat<int>(max);
    }

    public Stat<int> Max { get; }
    public Stat<int> Current { get; private set; }

    public void Reduce(int value)
    {
        if (value < 0)
            Debug.LogError("value < 0");

        int tempValue = Current.Value - value;
        tempValue = Mathf.Clamp(tempValue, 0, Max.Value);

        Current.Value = tempValue;
    }
}
