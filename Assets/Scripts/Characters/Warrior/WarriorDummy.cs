using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.SystemControls;

public class WarriorDummy: Character3D
{

    [SerializeField]
    Animator anim;
    [SerializeField]
    float shieldTime = .5f, currentTime = 0;
    float oldMovementSpeed;
    bool cooldown = false;
    public bool Guarded = false;
    public float Damage = 10;

    override protected void Start()
    {


        base.Start();
        

    }

    protected override void Attack()
    {
        base.Guard();
        
        if (Controllers.GetButton(1, "X", 1))
        {

            anim.SetBool("Guard", true);
            

        }
        else if (Controllers.GetButton(1, "X", 2))
        {
            cooldown = true;
            if (currentTime > shieldTime)
            {
                anim.SetBool("Guard", false);

                currentTime = 0;
            }



        }

        if (cooldown)
        {
            currentTime += Time.deltaTime;
        }

        if (!anim.GetBool("Guard") && cooldown)
        {

            if (currentTime > shieldTime)
            {
                currentTime = 0;
                cooldown = false;
                
            }
        }



    }

    protected override void Move()
    {
      
  

    }
    protected override void Rotate()
    {
        
    }

    protected override void Guard()
    {

        base.Attack();
        if (Controllers.GetButton(1, "Y", 1))
        {
            anim.SetTrigger("Attack");

        }
        
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
      //  Debug.Log("Nombre del collider: " + other.name + " Padre: " + other.transform.root.gameObject.name);
      //  Debug.Log("Estado de cubrir: " + anim.GetBool("Guard"));
        if (other.tag == "Damage" && !anim.GetBool("Guard"))
        {
         //   Debug.Log("Te has hecho daño men");
            WarriorMan another = other.transform.root.gameObject.GetComponent<WarriorMan>();
            another = other.transform.root.gameObject.GetComponent<WarriorMan>();
            RefreshHealth(another.Damage);
            Guarded = false;
        }
        
        
    }

    


}
