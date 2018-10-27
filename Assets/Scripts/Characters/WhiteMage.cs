using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.SystemControls;

public class WhiteMage : Character3D {

    [SerializeField]
    protected HealArea healArea;
    [SerializeField,Range(0,50)]
    protected int healManaCost;

    override protected void Start()
    {
        usesMana = true;

        base.Start();
    }

    protected override void Attack()
    {  
        if (Controllers.GetButton(1, "A", 1) && RefreshMana(-healManaCost))
        {
            print("Curado yo xD");
            foreach (GameObject player in healArea.gOInside)
            {
                //alguna manera de curar a los personajes
                print("Curado xD");
            }
        }
        else if(Controllers.GetButton(1, "A", 1) && !RefreshMana(-healManaCost))
        {
            //hacer algo si no hay mana??
        }
    }
    
}
