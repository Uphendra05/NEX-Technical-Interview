using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IBossHealthService
{

    public abstract void Start();
    public abstract void DamageBoss(float amount);

}
