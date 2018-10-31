using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.ObjectPooler;

#pragma warning disable 0649

public class Spell : PooledObjectBehavior {
    
    [SerializeField]
    float velocity;
    Rigidbody speelRigidBody;
    
    bool collide;

    Vector3 lastPosition;

    override protected void Awake() {
        speelRigidBody = GetComponent<Rigidbody>();
    }
    
    override protected void Start() {
        base.Start();
        collide = false;
        speelRigidBody.velocity = transform.forward * velocity * Time.deltaTime;
    }
    
    override protected void Update() {
        base.Update();
        if (!collide) {
            lastPosition = transform.position;
            speelRigidBody.velocity = transform.forward * velocity * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision) {
        collide = true;
        speelRigidBody.velocity = Vector3.zero;
        //objectPooler.GetObjectFromPool("Explosion", lastPosition, Quaternion.identity);
        ReturnObjectToPool();
    }
    private void OnTriggerEnter(Collider other) {
        collide = true;
        speelRigidBody.velocity = Vector3.zero;
        //objectPooler.GetObjectFromPool("Explosion", lastPosition, Quaternion.identity);
        ReturnObjectToPool();
    }

    override protected void ReturnObjectToPool() {
        collide = false;
        base.ReturnObjectToPool();
    }

}
