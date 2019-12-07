using UnityEngine;
using System.Collections;

public class gravity : MonoBehaviour
{

    Rigidbody arm;
    // Use this for initialization
    void Start()
    {

        arm = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.A))
        {

            arm.useGravity = true;
            arm.AddForce(Vector3.down * 30 * arm.mass);
       

        }
        else
        {
            arm.useGravity = false;
        }
    }
}
