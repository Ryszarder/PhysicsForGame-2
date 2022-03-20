using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPick : MonoBehaviour
{
	public Transform TheDest;

	void OnMouseDown()
	{
		GetComponent<Rigidbody>().useGravity = false;
		this.transform.position = TheDest.position;
		this.transform.parent = GameObject.Find("Destination").transform;
	}

	void OnMouseUp()
	{
		this.transform.parent = null;
		GetComponent<Rigidbody>().useGravity = true;
	}
}
