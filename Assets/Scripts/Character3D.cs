using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.SystemMovements;
using UnityEngine.UI;

public abstract class Character3D : MonoBehaviour {

    protected float healthValue;
    protected int manaValue;
    [SerializeField, Range(50,1000)]
    protected int maxManaValue;
    [SerializeField]
    protected float movementSpeed;
    [SerializeField, Range(0,5)]
    protected float rotationSpeed;
    [SerializeField]
    protected float guardValue;
    [SerializeField]
    protected float attackValue;
    protected Rigidbody rb;
    protected bool usesMana;

    [SerializeField]
    protected GameObject healthBar;
    protected Image healthBarValue;
    [SerializeField]
    protected GameObject manaBar;
    protected Image manaBarValue;


    // Use this for initialization
    protected virtual void Start () {
        rb = GetComponent<Rigidbody>();
        healthBarValue = healthBar.transform.GetChild(1).GetComponent<Image>();
        healthValue = 100f;

        RefreshHealt(0f);
        if (usesMana)
        {
            manaValue = maxManaValue;
            manaBar.SetActive(true);
            manaBarValue = manaBar.transform.GetChild(1).GetComponent<Image>();
            RefreshMana(0);
        }
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        Rotate();
        Attack();
        Guard();
    }

    protected virtual void Move()
    {
        Movement.MoveForward(rb, movementSpeed, transform);
    }

    protected virtual void Rotate()
    {
        Movement.RotateY(transform, rotationSpeed);
    }

    protected virtual void Attack()
    {

    }

    protected virtual void Guard()
    {

    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Damage")
        {
            //hay que poner un scrip o hacer alguna manera en la que podamos darle un valor al daño que hacen los ataques
            float damage = 30f;
            RefreshHealt(-damage);
        }
        else if(other.tag == "Heal")
        {
            //hay que poner un scrip o hacer alguna manera en la que podamos darle un valor al daño que hacen los ataques
            float healAmount = 30f;
            RefreshHealt(healAmount);
        }
        //aqui hay que poner los tags de las pociones de vida y mana y las flechas, alomejor el de las flechas nomas en el del arquero
    }

    protected void RefreshHealt(float healthChange)
    {
        healthValue = healthValue + healthChange < 0 ? 0 :
            healthValue + healthChange > 100 ? 100 :
            healthValue + healthChange;

        healthBarValue.fillAmount = healthValue / 100f;
        if (healthValue <= 0)
        {
            //lo que pasa cuando el personaje se queda sin vida
        }
    }

    /// <summary>
    /// regresa true si se hay mana suficiente para substraer el mana del mana actual,
    /// regresa false si no hay suficiente mana
    /// </summary>
    /// <param name="manaChange">cantidad de mana en la que va a cambiar; (-) para quitar, (+) para agregar</param>
    /// <returns></returns>
    protected virtual bool RefreshMana(int manaChange)
    {
        if (manaValue + manaChange < 0)
            return false;
        manaValue = manaValue + manaChange > maxManaValue ? maxManaValue
            : manaValue + manaChange;
        //refrescar la barra de mana
        manaBarValue.fillAmount = manaValue / maxManaValue;

        return true;
    }




}
