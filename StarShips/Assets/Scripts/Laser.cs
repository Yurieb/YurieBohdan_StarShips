using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Transform myTransform;
    public int laserSpeed = 7;
    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;

    }

    // Update is called once per frame
    void Update()
    {
        myTransform.Translate(Vector3.up * laserSpeed * Time.deltaTime);

        if (myTransform.position.y > 8)
        {
            DestroyObject(this.gameObject);
        }

    }
}
