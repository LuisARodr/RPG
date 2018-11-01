using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.SystemControls;

public class WarriorMan : Character3D
{

    [SerializeField]
    Animator anim;
    [SerializeField]
    float shieldTime = .5f, currentTime = 0;
    float oldMovementSpeed;
    bool cooldown = false;
    public bool Guarded = false;
    public bool Guarded2 = false;
    public float Damage = 10;

    override protected void Start()
    {
        
        
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();
        if (Controllers.GetButton(1, "A", 1) )
        {
            anim.SetTrigger("Attack");

        }
        
    }

    protected override void Move()
    {
        base.Move();
        anim.SetFloat("Velocity", Mathf.Abs(rb.velocity.x  +rb.velocity.y));
        
    }

    protected override void Guard()
    {
        base.Guard();
        if (Controllers.GetButton(1, "B", 1))
        {
          
            anim.SetBool("Guard",true);
            Guarded = true;
            Guarded2 = true;
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ |  RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;

        } else if (Controllers.GetButton(1, "B", 2))
            {
                cooldown = true;
            if (currentTime > shieldTime) {
                anim.SetBool("Guard", false);
                Guarded = false;
                Guarded2 = false;
                currentTime = 0;
            }
                 
            

            }

        if (cooldown)
        {
            currentTime += Time.deltaTime;
        }

        if (!anim.GetBool("Guard") && cooldown)
        {
            
            if(currentTime > shieldTime)
            {
                currentTime = 0;
                cooldown = false;
                rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY;
            }
        }

    }
    protected override void OnTriggerEnter(Collider other)
    {

        Debug.Log("Asi se llama el padre de este men " + other.transform.root.name);
        if(other.tag == "Damage" && !Guarded && (this.name != other.transform.root.name))
        {
            RefreshHealth(-30f);
        }
        




    }

    protected  void OnCollisionExit(Collision collision)
    {
        base.OnCollisionEnter(collision);
        Guarded = false;
    }
}
