using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatusManager : MonoBehaviour
{

    public enum entityFaction { Monster,Player,Plant,DeathZone };
    public entityFaction faction = entityFaction.Monster;

    public float baseMovmentSpeed = 1;
    public float movementspeedModifier = 1;
    public float maxHp = 10;
    public float maxStamina = 0;
    public float staminaRegen;

    public bool staminaRegenEnabled = true;
    public bool godMode = false;
    public int damage = 1;

    public UnityEvent deathEvent;
    public UnityEvent takingDamageEvent;

    private float movementSpeed;

    [SerializeField]
    private float stamina = 0;
    [SerializeField]
    private float hp = 10;

    // Start is called before the first frame update
    void Start()
    {
        // If Statusmanager has Stamina Trigger the stamina Regeneration
        if (maxStamina > 0)
        {
            InvokeRepeating("StaminaRegen", 0, 0.2f);
        }
    }

    /// <summary>
    /// Apply Damage to Statusmanager
    /// By Christian Scherzer
    /// </summary>
    /// <param name="damage"></param>
    public void ApplyDamage(int damage)
    {
        Hp -= damage;
        GameManager.SpawnFloatingText("-"+damage,transform);
        takingDamageEvent.Invoke();
    }

    /// <summary>
    /// The BaseDeathEvent to give a Statusmanager if none is set
    /// By Shaina Milde
    /// </summary>
    public void BaseDeathEvent()
    {
        Destroy(gameObject);
    }


    public float Hp
    {
        get => hp;
        set
        {
            hp = value;
            // If hp reaches or drops under zero, trigger the death event and set the hp to 0
            if (value <= 0 && !godMode)
            {
                deathEvent.Invoke();
                hp = 0;
            }
            // Makes sure hp can't exceed the maxHp
            if(value > maxHp)
            {
                hp = maxHp;
            }
            
        }
    }

    // Return the Movementspeed
    public float MovementSpeed 
    { 
        get => (baseMovmentSpeed * movementspeedModifier); 
    }

    public float Stamina { get => stamina; set 
        {
            // Makes sure staminate cannot exceed the maxStamina
            if(value > maxStamina)
            {
                stamina = maxStamina;
            }
            else
            { 
                stamina = value;
            }
        } 
    }

    /// <summary>
    /// Initializes the HP
    /// By Shaina Milde
    /// </summary>
    /// <param name="value"></param>
    public void InitalizeHP (int value)
    {
        maxHp = value;
        hp = value;
    }

    /// <summary>
    /// Stamina Regen method
    /// By Christian Scherzer
    /// </summary>
    private void StaminaRegen()
    {
        if(staminaRegenEnabled)
        { 
            Stamina += staminaRegen / 5;
        }
    }
}
