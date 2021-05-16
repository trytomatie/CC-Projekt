using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public int damage;

    private void OnParticleCollision(GameObject other)
    {
        StatusManager otherStatus = other.GetComponent<StatusManager>();
        if(otherStatus != null)
        {
            otherStatus.ApplyDamage(damage);
        }
    }

}
