using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IBossService
{


    public abstract void StartBossPhase();
    public abstract void UpdateBossPhase();
    public abstract void Cleanup();

}
