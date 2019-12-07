using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class AddRope : MonoBehaviour {
    public UltimateRope Rope;
    public float RopeExtensionSpeed;

    SteamVR_TrackedObject trackedObj;

    float m_fRopeExtension;

    bool active = false;

    void Awake() {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    void Start() {
        m_fRopeExtension = Rope != null ? Rope.m_fCurrentExtension : 0.0f;
    }

    void Update() {
        var device = SteamVR_Controller.Input((int)trackedObj.index);
        if (Input.GetKey(KeyCode.O) || device.GetTouch(SteamVR_Controller.ButtonMask.Trigger)) {
            Debug.Log(device.GetTouch(SteamVR_Controller.ButtonMask.Trigger));
            Debug.Log("Add Rope");
            m_fRopeExtension += Time.deltaTime * RopeExtensionSpeed;

            if (Rope != null) {
                Debug.Log("Adding Rope");
                m_fRopeExtension = Mathf.Clamp(m_fRopeExtension, 0.0f, Rope.ExtensibleLength);
                Rope.ExtendRope(UltimateRope.ERopeExtensionMode.LinearExtensionIncrement, m_fRopeExtension - Rope.m_fCurrentExtension);
            }
        }
    }

    void OnCollisionStay(Collision collision) {
        //active = true;
    }

    void OnCollisionExit(Collision collision) {
        //active = false;
    }

}
