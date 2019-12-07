using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class ExtendRope : MonoBehaviour {
    public UltimateRope Rope;
    public float RopeExtensionSpeed;
    public GameObject ropeEnd;
    SteamVR_TrackedObject trackedObj;
    GameObject angleIndicator;

    public static float m_fRopeExtension;

    bool active = false;

    void Awake() {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    void Start() {
        m_fRopeExtension = Rope != null ? Rope.m_fCurrentExtension : 0.0f;
        angleIndicator = GameObject.Find("AngleIndicator");
        if (angleIndicator == null) {
            Debug.Log("Couldn't find angleIndicator");
        }
    }

    void Update() {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (Input.GetKey(KeyCode.M) || device.GetPressDown(SteamVR_Controller.ButtonMask.Grip)) {
            ToggleMetrics();
        }
        if (Input.GetKey(KeyCode.R) || device.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad)) {
            Debug.Log("Release Weight");
            FixedJoint joint = ropeEnd.GetComponent<FixedJoint>();
            Rigidbody rb = ropeEnd.GetComponent<Rigidbody>();
            rb.useGravity = true;
            Destroy(joint);
        }
        if (Input.GetKey(KeyCode.I) || device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
            Debug.Log(device.ToString() + " " + device.index);
            if (device.index == 1 || device.index == 3) {
                Debug.Log("Remove Rope");
                m_fRopeExtension -= Time.deltaTime * RopeExtensionSpeed;
            } else {
                Debug.Log("Adding Rope");
                m_fRopeExtension += Time.deltaTime * RopeExtensionSpeed;
            }
        }
        //Debug.Log(m_fRopeExtension);
        if (Rope != null) {
            m_fRopeExtension = Mathf.Clamp(m_fRopeExtension, 0.0f, Rope.ExtensibleLength);
            Rope.ExtendRope(UltimateRope.ERopeExtensionMode.LinearExtensionIncrement, m_fRopeExtension - Rope.m_fCurrentExtension);
        }
    }

    void OnCollisionStay(Collision collision) {
        //active = true;
    }

    void OnCollisionExit(Collision collision) {
        //active = false;
    }

    void ToggleMetrics() {
        
        bool active = true;
        TextMesh[] metrics = FindObjectsOfType(typeof(TextMesh)) as TextMesh[];
        foreach (TextMesh metric in metrics) {
            metric.transform.GetComponent<MeshRenderer>().enabled = !metric.transform.GetComponent<MeshRenderer>().enabled;
            active = metric.transform.GetComponent<MeshRenderer>().enabled;
        }
        angleIndicator.SetActive(active);
    }
}
