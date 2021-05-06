using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 3;

    private CharacterController cc;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        cc.SimpleMove((transform.forward * verticalInput + transform.right * horizontalInput) * speed);
        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        { 
            anim.SetFloat("Speed_f", 1);
        }
        else
        {
            anim.SetFloat("Speed_f", 0);
        }
    }
}
