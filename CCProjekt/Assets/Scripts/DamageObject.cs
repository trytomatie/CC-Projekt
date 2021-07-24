using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public int damage;
    public List<ParticleCollisionEvent> collisionEvents;
    public GameObject origin;

    private ParticleSystem part;

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
            if (otherStatus != null && other.gameObject != origin)
            {
                otherStatus.ApplyDamage(damage);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        StatusManager otherStatus = other.GetComponent<StatusManager>();
        if (otherStatus != null && other.gameObject != origin)
        {
            otherStatus.ApplyDamage(damage);
        }
    }

}
