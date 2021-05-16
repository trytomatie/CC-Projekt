using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAi : MonoBehaviour
{

    public GameObject target;
    public float minMoveDistanceToTarget = 1;
    private StatusManager statusManager;
    private Rigidbody rb;
    public Animator anim;

    public float attackDelay = 0.4f;
    public float attackApplicationDelay = 0.3f;
    public float attackCooldown = 1f;
    //private bool preparingAttack = false;
    private bool isOnAttackCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        statusManager = GetComponent<StatusManager>();
        rb = GetComponent<Rigidbody>();
        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(target.transform.position, transform.position);
        // Checks if Ai should move
        if (target!= null && distanceToTarget > minMoveDistanceToTarget && !isOnAttackCooldown)
        {
            Move(target.transform);
        }
        else // doesn't move
        {
            anim.SetBool("Moving", false);
        }

        if(minMoveDistanceToTarget >= distanceToTarget)
        {
            CheckForAttack();
        }
    }

    /// <summary>
    /// Moves Ai toward Tagetposition
    /// - By Christian Scherzer
    /// </summary>
    /// <param name="moveTarget"></param>
    private void Move(Transform moveTarget)
    {
        Vector3 direction = (moveTarget.position - transform.position).normalized;
        direction.y = 0;
        rb.position += (direction * (statusManager.movementSpeed * Time.deltaTime));
        RotateToTaget(moveTarget);
        anim.SetBool("Moving", true);
    }

    private void RotateToTaget(Transform roationTaget)
    {
        transform.LookAt(roationTaget.position);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    /// <summary>
    /// Checks attack conditions
    /// - By Christian Schezer
    /// </summary>
    private void CheckForAttack()
    {
        if(!isOnAttackCooldown)
        {
            //preparingAttack = true;
            isOnAttackCooldown = true;
            RotateToTaget(target.transform);
            Invoke("Attack", attackDelay);
            Invoke("ResetAttackCooldown", attackCooldown);
        }
    }
    /// <summary>
    /// Attack target
    /// - By Christian Scherzer
    /// </summary>
    /// <param name="target"></param>
    private void Attack()
    {
        anim.SetTrigger("Attack");
        Invoke("ApplyDamage", attackApplicationDelay);
    }

    /// <summary>
    /// Sets the isOnAttackCooldown variable
    /// - By Christian Scherzer
    /// </summary>
    private void ResetAttackCooldown()
    {
        isOnAttackCooldown = false;
    }

    /// <summary>
    /// Apply Damage
    /// - By Christian Scherzer
    /// </summary>
    private void ApplyDamage()
    {
        StatusManager targetStatus = target.GetComponent<StatusManager>();
        //preparingAttack = false;
        targetStatus.ApplyDamage(statusManager.damage);
    }


}
