using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public int damage;
    public List<ParticleCollisionEvent> collisionEvents;
    public GameObject origin;
    public float lingeringTime = 0;

    private ParticleSystem part;

    private void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
        if(lingeringTime > 0)
        {
            Destroy(gameObject, lingeringTime);
        }
    }
    /// <summary>
    /// Applies damage on Particle Collision
    /// by Christian Scherzer
    /// </summary>
    /// <param name="other"></param>
    private void OnParticleCollision(GameObject other)
    {

        int numCollisionEvents = 1;
        // If a particlesystem exists, count the numbers of collision on that frame
        if (part != null)
        { 
            numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);
        }
        // Apply damage for each collisonevent
        for(int i = 0; i <numCollisionEvents;i++)
        {
            ApplyDamage(other);
        }
    }

    /// <summary>
    /// Apply Damage to gameObject with Statusmanager
    /// by Christian Scherzer
    /// </summary>
    /// <param name="other"></param>
    private void ApplyDamage(GameObject other)
    {
        StatusManager otherStatus = other.GetComponent<StatusManager>();
        if (otherStatus != null && other.gameObject != origin && otherStatus.faction != origin.GetComponent<StatusManager>().faction)
        {
            otherStatus.ApplyDamage(damage);
        }
    }

    /// <summary>
    /// Apply Damage on trigger enter
    /// by Christian Scherzer
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        ApplyDamage(other.gameObject);
    }

}
