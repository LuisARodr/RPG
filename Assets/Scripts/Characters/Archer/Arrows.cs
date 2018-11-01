using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.ObjectPooler;

public class Arrows : MonoBehaviour {

	[SerializeField]
	protected string poolTag;
	[SerializeField]
	float velocity;
	[SerializeField]
	Rigidbody rb;
	ObjectPooler objectPooler;

	void Start(){
		objectPooler = ObjectPooler.Instance;
		rb.velocity = transform.forward * velocity * Time.deltaTime;
	}

}
