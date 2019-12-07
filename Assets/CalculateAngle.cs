using UnityEngine;
using System.Collections;

public class CalculateAngle : MonoBehaviour {

    public GameObject objectToTrack;
    public GameObject reference;
    public TextMesh angleDisplay;

    public float xOffset = 0;
    public float yOffset = 0;
    public float zOffset = 0;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = objectToTrack.transform.rotation;
        float angle = transform.rotation.eulerAngles.z > 180 ? transform.rotation.eulerAngles.z - 360 : transform.rotation.eulerAngles.z;
        angleDisplay.text = angle.ToString("F");
    }
}
