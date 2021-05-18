using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StatusManager : MonoBehaviour
{

    public float movementSpeed = 1;
    public int maxHp = 10;
    [SerializeField]
    private float hp = 10;
    public int damage = 1;

    public UnityEvent deathEvent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ApplyDamage(int damage)
    {
        Hp -= damage;
        GameManager.SpawnFloatingText("-"+damage,transform);
    }


    public float Hp
    {
        get => hp;
        set
        {
            hp = value;
            if (value <= 0)
            {
                if(deathEvent == null)
                {
                    print("No DeathEvent set");
                }
                deathEvent.Invoke();
                hp = 0;
            }
            if(value > maxHp)
            {
                hp = maxHp;
            }
            
        }
    }
}
