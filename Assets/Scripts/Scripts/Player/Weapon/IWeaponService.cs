using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface IWeaponService
{
    public abstract void Spawn(Transform parent);

    public abstract void Shoot();


}
