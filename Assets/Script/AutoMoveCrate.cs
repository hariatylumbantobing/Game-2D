using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMoveCrate : PhysicsObject {

	void Update ()
	{
		targetVelocity = Vector2.right; //horizontal move
	}

}
