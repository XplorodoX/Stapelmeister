using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPhysics : MonoBehaviour
{
    public transform target;
    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate()
    {
        target.MovePosition(target.transform.position);
    }
}
