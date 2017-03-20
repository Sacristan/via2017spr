using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {
	[SerializeField]
	private float speed = 5f;

	void Update () {
		transform.position += transform.forward * Time.deltaTime * speed;
	}
}
