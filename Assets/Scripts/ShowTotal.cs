using UnityEngine;
using System.Collections;

public class ShowTotal : MonoBehaviour {

    GameObject total;
    GameObject receipt;
    GameObject receiptTotal;
    // Use this for initialization
    void Start () {
        total = GameObject.Find("Total");
        if (total == null) {
            Debug.Log("Couldn't find Cash Register display object");
        }
        receipt = GameObject.Find("Receipt");
        if (receipt == null) {
            Debug.Log("Couldn't find Receipt display object");
        }
        receiptTotal = GameObject.Find("ReceiptTotal");
        if (receiptTotal == null) {
            Debug.Log("Couldn't find ReceiptTotal display object");
        }
        total.GetComponent<MeshRenderer>().enabled = false;
        receipt.GetComponent<MeshRenderer>().enabled = false;
        receiptTotal.GetComponent<MeshRenderer>().enabled = false;
    }

    void OnCollisionEnter(Collision collision) {
        Debug.Log("Collided to Pay");
        total.GetComponent<MeshRenderer>().enabled = !total.GetComponent<MeshRenderer>().enabled;
        receipt.GetComponent<MeshRenderer>().enabled = !receipt.GetComponent<MeshRenderer>().enabled;
        receiptTotal.GetComponent<MeshRenderer>().enabled = !receiptTotal.GetComponent<MeshRenderer>().enabled;
    }
}
