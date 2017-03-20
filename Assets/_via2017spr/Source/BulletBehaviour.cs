using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private void Awake()
    {
        Destroy(gameObject, 2f); //Destroy this gameObject after two seconds when it has been created to cleanup memory
    }

    private void Update()
    {
        transform.position += transform.forward * Time.deltaTime * speed; //Apply movement with local forward, speed and deltaTime
    }
}
