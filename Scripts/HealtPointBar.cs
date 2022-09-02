using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtPointBar : MonoBehaviour
{
    public int

            max,
            min,
            current;

    public float time;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (time == 0 || time < Time.time)
        {
            current++;
            time = Time.time + 1;
        }
    }
}
