using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatAi : MonoBehaviour
{

    public GameObject target;
    public Animator anim;
    public ParticleSystem waterParticles;
    public AudioClip damageClip;

    public bool isCaveRat;
    public float attackDelay = 0.4f;
    public float attackApplicationDelay = 0.3f;
    public float attackCooldown = 1f;
    public float minMoveDistanceToTarget = 1;
    public float aggroDistance = 1f;

    private bool isOnAttackCooldown = false;
    private bool isDead = false;

    private SpawnManager spawnManager;
    private StatusManager statusManager;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        statusManager = GetComponent<StatusManager>();
        rb = GetComponent<Rigidbody>();
        FindTarget();
        spawnManager = GameObject.FindObjectOfType<SpawnManager>();

        waterParticles.Stop();
    }

    private bool FindTarget()
    {
        CropsScript[] crops = GameObject.FindObjectsOfType<CropsScript>();
        if (crops.Length == 0)
        {
            target = GameObject.Find("Player");
        }
        else
        {
            target = crops[Random.Range(0, crops.Length)].gameObject;
        }
        if(isCaveRat && Vector3.Distance(transform.position,target.transform.position) > aggroDistance)
        {
            target = null;
            return false;
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            if (!FindTarget())
            {
                return;
            }
        }
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

        IsDead();
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
        rb.position += (direction * (statusManager.MovementSpeed * Time.deltaTime));
        RotateToTaget(moveTarget);
        anim.SetBool("Moving", true);
    }

    /// <summary>
    /// Rotates to target
    /// - By Christian Scherzer
    /// </summary>
    /// <param name="roationTaget"></param>
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
        if (!GameManager.Instance.isGameOver)
        {
            if (!isOnAttackCooldown && !isDead)
            {
                //preparingAttack = true;
                isOnAttackCooldown = true;
                RotateToTaget(target.transform);
                Invoke("Attack", attackDelay);
                Invoke("ResetAttackCooldown", attackCooldown);
            }
            else if (isDead)
            {
                Destroy(gameObject);
            }
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
        if(targetStatus == null)
        {
            return;
        }
        //preparingAttack = false;
        targetStatus.ApplyDamage(statusManager.damage);
    }


    /// <summary>
    /// if HP reaches 0 and rat didnt die yet, it returns to one of the spawnpoints
    /// </summary>
    private void IsDead()
    {
        if (statusManager.Hp == 0 && !isDead)
        {
            Destroy(gameObject, 20f); // guarantees that game object will be destroyed after 20 seconds
            gameObject.layer = 9; // rat ignores collision except the floor
            isDead = true;
            Instantiate(spawnManager.seedPrefab, transform.position, spawnManager.seedPrefab.transform.rotation); // rat drops a seed once it dies
            target = spawnManager.spawnpoints[Random.Range(0, spawnManager.spawnpoints.Length)].gameObject;       // rat returns to one of the set spawnpoints
            waterParticles.Play();                                                                                

        }
    }

    public void OnTakingDamage()
    {
        GameObject go = Instantiate(GameManager.Instance.soundObject,transform.position,transform.rotation);
        AudioSource audioSource = go.GetComponent<AudioSource>();
        audioSource.clip = damageClip;
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.Play();
        Destroy(go, damageClip.length);
    }
}
