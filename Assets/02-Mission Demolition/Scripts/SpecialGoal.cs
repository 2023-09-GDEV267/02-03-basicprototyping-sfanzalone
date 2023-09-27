using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialGoal : MonoBehaviour
{
	//A static field accessible by code anywhere
	static public bool specGoalMet = false;

	void OnTriggerEnter(Collider other)
	{
		// when the trigger is hit by something
		// check to see if it's a Projectile 
		if (other.gameObject.tag == "Projectile")
		{
			// if so, set goalMet = true
			SpecialGoal.specGoalMet = true;

			// also set the alpha of the color of higher opacity
			Material mat = GetComponent<Renderer>().material;
			Color c = mat.color;
			c.a = 1;
			mat.color = c;

			//Prints a message in the debugger
			Debug.Log("You reached the special goal!  Lucky you!");
		}
	}
}