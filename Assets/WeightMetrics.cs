using UnityEngine;
using System.Collections;

public class WeightMetrics : MonoBehaviour {

    public TextMesh mass;
    public TextMesh velocity;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        velocity.text = "Velocity: " + transform.parent.GetComponent<Rigidbody>().velocity.magnitude.ToString("F") + "m/s";
    }
}
