using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurretService
{
    public abstract void Start(TurretView turretView);
    public abstract void Update();

    public abstract void Cleanup();
}
