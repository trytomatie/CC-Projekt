using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public int damage;
    private ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    private void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }
    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = 1;
        if (part != null)
        { 
            numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        }
        for(int i = 0; i <numCollisionEvents;i++)
        {
            StatusManager otherStatus = other.GetComponent<StatusManager>();
            if (otherStatus != null)
            {
                otherStatus.ApplyDamage(damage);
            }
        }
    }

}
