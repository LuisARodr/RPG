using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealArea : MonoBehaviour {

    public ArrayList gOInside;
    [SerializeField, Range(1,5)]
    protected int maxNumberOfHeals;
    [SerializeField, Range(.5f,10f)]
    protected float areaRadius;
    protected SphereCollider effectArea;

    private void Start()
    {
        effectArea = GetComponent<SphereCollider>();
        effectArea.radius = areaRadius;
        gOInside = new ArrayList();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Character")
        {
            if (!gOInside.Contains(other.gameObject) && gOInside.Count < maxNumberOfHeals -1 )
            {
                gOInside.Add(other.gameObject);
                //agregar algun efecto o algo cuando estan dentro del healArea
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Character")
        {
            if (!gOInside.Contains(other.gameObject))
            {
                gOInside.Remove(other.gameObject);
                //quitar el efecto??
            }
        }
    }

}
