using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

    GameObject bridge;
    Rigidbody bridgeRigidBody;
    GameObject forceApplied;
	// Use this for initialization
	void Start () {
        bridge = GameObject.Find("Bridge");
        if (bridge == null) {
            Debug.Log("Cannot find the bridge");
        }
        forceApplied = GameObject.Find("ForceApplied");
        if (forceApplied == null) {
            Debug.Log("Cannot find the forceApplied text mesh");
        }
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.name == "Weight") {
            try {
                float force = (0.5f * collision.rigidbody.mass * Mathf.Pow(collision.rigidbody.velocity.magnitude, 2));
                //forceApplied.GetComponent<TextMesh>().text = "Force Applied: " + force.ToString("F") + "N";
                if (force <= 700) {
                    //forceApplied.GetComponent<TextMesh>().color = new Color(0f, 255f, 0f);
                    //bridgeRigidBody.AddExplosionForce(100f, bridgeRigidBody.position, 100f);
                } else {
                    //forceApplied.GetComponent<TextMesh>().color = new Color(255f, 0f, 0f);
                }
                Debug.Log("Weight hit bridge post");
                bridgeRigidBody = bridge.GetComponent<Rigidbody>();
                bridgeRigidBody.useGravity = true;
                bridgeRigidBody.isKinematic = false;
                GetComponent<Rigidbody>().isKinematic = false;
                Debug.Log("Mass: " + collision.rigidbody.mass + "kg");
                Debug.Log("Velocity: " + collision.rigidbody.velocity.magnitude + "m/s");
                Debug.Log(0.5f * collision.rigidbody.mass * Mathf.Pow(collision.rigidbody.velocity.magnitude, 2));
            }
            catch { }
        }
        //foreach (ContactPoint contact in collision.contacts) {
        //    Debug.DrawRay(contact.point, contact.normal, Color.white);
        //}

        //if (collision.relativeVelocity.magnitude > 2)
        //    audio.Play();
    }
}
