using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UZI : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Bullet, shootPoint.transform.position, Quaternion.identity);
        
    }
}
