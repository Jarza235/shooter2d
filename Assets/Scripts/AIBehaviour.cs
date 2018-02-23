using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBehaviour : HumanBehaviour {

	protected override void FixedUpdate ()
	{
		base.FixedUpdate ();

		rb.AddForce(Vector3.left * 8f);
	}
}
