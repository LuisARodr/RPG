using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    
	void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("El escudo ha chocado");
        WarriorMan another = this.transform.root.gameObject.GetComponent<WarriorMan>();
        Debug.Log("PADRE: " + (this.transform.root.name));
        Debug.Log("PADRE2: " + (other.transform.root.name));


        WarriorMan thisone = other.transform.root.gameObject.GetComponent<WarriorMan>();
        
        if(thisone.Guarded2)
        {
            thisone.Guarded = true;
        }
        if (other.tag == "Damage" && !another.Guarded && (this.transform.root.name != other.transform.root.name))
        {
            

             another = this.transform.root.gameObject.GetComponent<WarriorMan>();
            
            Debug.Log("Te has cubrido men!!");


        }
        
       
    }
}
