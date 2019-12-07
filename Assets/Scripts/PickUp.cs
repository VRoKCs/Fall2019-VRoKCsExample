using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class PickUp : MonoBehaviour {

    public SteamVR_TrackedObject trackedObj;
    public GameObject[] menuItems;
    public GameObject pickedupObject;

    void Awake() {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        menuItems = GameObject.FindGameObjectsWithTag("MenuItem");
        SetMenuVisibility(false);
    }

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        var device = SteamVR_Controller.Input((int)trackedObj.index);

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.ApplicationMenu)) {
            Debug.Log("Application Menu");
            ToggleMenuVisibility();
        }
        if (Input.GetKey(KeyCode.D) || device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger)) {
            if (pickedupObject != null && trackedObj != null) {
                pickedupObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedupObject.transform.parent = null;
            }
        }
    }

    //void FixedUpdate() {
    //    var device = SteamVR_Controller.Input((int)trackedObj.index);
    //    if (joint == null && device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)) {
    //        var go = GameObject.Instantiate(prefab);
    //        go.transform.position = attachPoint.transform.position;

    //        joint = go.AddComponent<FixedJoint>();
    //        joint.connectedBody = attachPoint;
    //    } else if (joint != null && device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger)) {
    //        var go = joint.gameObject;
    //        var rigidbody = go.GetComponent<Rigidbody>();
    //        Object.DestroyImmediate(joint);
    //        joint = null;
    //        Object.Destroy(go, 15.0f);

    //        // We should probably apply the offset between trackedObj.transform.position
    //        // and device.transform.pos to insert into the physics sim at the correct
    //        // location, however, we would then want to predict ahead the visual representation
    //        // by the same amount we are predicting our render poses.

    //        var origin = trackedObj.origin ? trackedObj.origin : trackedObj.transform.parent;
    //        if (origin != null) {
    //            rigidbody.velocity = origin.TransformVector(device.velocity);
    //            rigidbody.angularVelocity = origin.TransformVector(device.angularVelocity);
    //        } else {
    //            rigidbody.velocity = device.velocity;
    //            rigidbody.angularVelocity = device.angularVelocity;
    //        }

    //        rigidbody.maxAngularVelocity = rigidbody.angularVelocity.magnitude;
    //    }
    //}

    void OnCollisionStay(Collision collision) {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        Debug.Log("Colliding with " + collision.collider.name);
        if (Input.GetKey(KeyCode.P) || device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger)) {
            if (collision.collider.name == "Flour" || collision.collider.name == "Bread" || collision.collider.name == "Sugar") {
                if (collision.collider.transform.parent != trackedObj.transform) {
                    Debug.Log(device.ToString() + " " + device.index + " picking up " + collision.collider.name);
                    pickedupObject = collision.collider.gameObject;
                    pickedupObject.GetComponent<Rigidbody>().isKinematic = true;
                    pickedupObject.transform.parent = trackedObj.transform;
                }
            }
        }
    }

    void ToggleMenuVisibility() {
        foreach (GameObject item in menuItems) {
            item.GetComponent<Renderer>().enabled = !item.GetComponent<Renderer>().enabled;
        }
    }

    void SetMenuVisibility(bool visibility) {
        foreach (GameObject item in menuItems) {
            item.GetComponent<Renderer>().enabled = visibility;
        }
    }
}
