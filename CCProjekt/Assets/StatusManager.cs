using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{

    public float movementSpeed = 1;
    public int maxHp = 10;
    [SerializeField]
    private float hp = 10;



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
    }


    public float Hp
    {
        get => hp;
        set
        {
            hp = value;
            if (value <= 0)
            {
                print("I died!");
                hp = 0;
            }
            if(value > maxHp)
            {
                hp = maxHp;
            }
            
        }
    }
}
