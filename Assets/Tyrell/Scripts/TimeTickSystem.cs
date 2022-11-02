using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TimeTickSystem : MonoBehaviour
{
    public class OnTickEventArgs : EventArgs
    {
        public int Tick;
    }

    public static event EventHandler<OnTickEventArgs> OnTick;


    private const float Tick_Timer_Max = 1f;


    private int tick;
    private float tickTimer;

    private void Awake()
    {
        tick = 0;
    }

    private void Update()
    {
        tickTimer += Time.deltaTime;
        if (tickTimer >= Tick_Timer_Max)
        {
            tickTimer -= Tick_Timer_Max;
            tick++;
            if (OnTick != null) OnTick(this, new OnTickEventArgs {Tick = tick });
        }
    }
}
