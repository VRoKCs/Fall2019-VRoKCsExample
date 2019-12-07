using UnityEngine;
using System.Collections;

public class loginSCript : MonoBehaviour
{
    public float colourChangeDelay = 0.5f;
    float currentDelay = 0f;
    bool colourChangeCollision = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkColourChange();
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "1" ||
            col.gameObject.name == "2" ||
            col.gameObject.name == "3" ||
            col.gameObject.name == "4" ||
            col.gameObject.name == "5" ||
            col.gameObject.name == "6" ||
            col.gameObject.name == "7" ||
            col.gameObject.name == "8" ||
            col.gameObject.name == "9" ||
            col.gameObject.name == "0")
        {
            Debug.Log("Contact was made!");
            colourChangeCollision = true;
            currentDelay = Time.time + colourChangeDelay;
        }
    }

    void checkColourChange()
    {
        if (colourChangeCollision)
        {
            transform.GetComponent<Renderer>().material.color = Color.yellow;
            if (Time.time > currentDelay)
            {
                transform.GetComponent<Renderer>().material.color = Color.white;
                colourChangeCollision = false;
            }
        }
    }
}
