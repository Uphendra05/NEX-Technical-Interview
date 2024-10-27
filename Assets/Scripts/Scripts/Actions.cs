using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Actions 
{
    public static Action<float> onHit = delegate { };
    public static Action<float> onHeal = delegate { };

    public static Action<float> onBossHit = delegate { };


}
