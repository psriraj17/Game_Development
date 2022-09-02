using System.Collections;
using System.Collections.Generic;

public class Stats
{
    public float baseValue { get; set; }

    public float current;

    public List<float> modifiers;

    public Stats()
    {
        modifiers= new List<float>();
    }

    public Stats(float value)
    {
        baseValue = value;
    }

    public void AddModifier(float value)
    {
        //val.modify=value;
       
        modifiers.Add (value);
    }

    public float GetValue()
    {
        current = baseValue;
        foreach (var item in modifiers)
        {
            current += item;
        }
        return current;
    }
}
