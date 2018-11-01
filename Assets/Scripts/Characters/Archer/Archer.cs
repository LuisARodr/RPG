using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCore.SystemControls;
using GameCore.ObjectPooler;

public class Archer : Character3D {

	[SerializeField]
	Animator anim;
	[SerializeField]
	GameObject arrowSpawner;
	ObjectPooler objectPooler;

	AnimatorStateInfo animStateInfo;

	override protected void Start(){
		base.Start ();
		objectPooler = ObjectPooler.Instance;
	}

	override protected void Move() {
		if (!Controllers.GetButton (1, "A", 2)) {
			base.Move ();
			anim.SetFloat ("Velocity", Mathf.Abs (rb.velocity.x + rb.velocity.z));
		}
	}

	override protected void Attack() {
		if (Controllers.GetButton (1, "A", 1)) {
			anim.SetBool ("Attack", true);
		}
		if (Controllers.GetButton (1, "A", 2)) {
			animStateInfo = anim.GetCurrentAnimatorStateInfo (0);
			if (animStateInfo.IsName("shoot-still")) {
				objectPooler.GetObjectFromPool ("Arrow", arrowSpawner.transform.position, arrowSpawner.transform.rotation, null);
			}
			anim.SetBool ("Attack", false);
		}
	}
}
