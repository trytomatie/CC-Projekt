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
        if(maxStamina > 0)
        {
            InvokeRepeating("StaminaRegen", 0, 0.2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ApplyDamage(int damage)
    {
        Hp -= damage;
        GameManager.SpawnFloatingText("-"+damage,transform);
        takingDamageEvent.Invoke();
    }

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
            if (value <= 0)
            {
                deathEvent.Invoke();
                hp = 0;
            }
            if(value > maxHp)
            {
                hp = maxHp;
            }
            
        }
    }

    public float MovementSpeed 
    { 
        get => (baseMovmentSpeed * movementspeedModifier); 
    }
    public float Stamina { get => stamina; set 
        {
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

    public void InitalizeHP (int value)
    {
        maxHp = value;
        hp = value;
    }

    private void StaminaRegen()
    {
        if(staminaRegenEnabled)
        { 
            Stamina += staminaRegen / 5;
        }
    }
}
