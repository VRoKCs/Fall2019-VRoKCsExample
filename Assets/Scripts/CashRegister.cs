using UnityEngine;
using System;
using System.Collections.Generic;

public class CashRegister : MonoBehaviour {

    List<GameObject> items = new List<GameObject>();
    Item item;
    float totalAmount = 0;
    TextMesh totalDisplay;
    TextMesh receiptDisplay;
    bool update = true;

	// Use this for initialization
	void Start () {
        totalDisplay = GetComponentInChildren<TextMesh>();
        receiptDisplay = GameObject.Find("Receipt").GetComponentInChildren<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (update) {
            totalDisplay.text = GetTotal();
            update = false;
        }
        if (totalAmount > 20) {
            totalDisplay.color = new Color(255f, 0f, 0f);
        } else {
            totalDisplay.color = new Color(83f, 255f, 0f);
        }
	}

    string GetTotal() {
        totalAmount = 0;
        float amountBeforeGas = 0;
        receiptDisplay.text = "";
        foreach (GameObject item in items) {
            Item itemPrice = item.GetComponent<Item>();
            if (itemPrice != null) {
                totalAmount += itemPrice.price;
                receiptDisplay.text += "$" + itemPrice.price + "\n";
            }
        }
        //totalAmount = totalAmount + (totalAmount * .07f);
        amountBeforeGas = totalAmount;
        totalAmount += 5;
        receiptDisplay.text += "Gas " + String.Format("{0:C}", 5) + "\n";
        receiptDisplay.text += "\n";
        receiptDisplay.text += "Tax " + String.Format("{0:C}", amountBeforeGas * .07f) + "\n";
        receiptDisplay.text += "-------------\n";
        receiptDisplay.text += "Total: " + String.Format("{0:C}", totalAmount);
        return String.Format("{0:C}", totalAmount);
    }

    void OnTriggerEnter(Collider other) {
        update = true;
        if (other.attachedRigidbody)
            item = other.GetComponent<Item>();
            if (item != null) {
                Debug.Log("Added $" + item.price);
                items.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other) {
        update = true;
        if (other.attachedRigidbody)
            item = other.GetComponent<Item>();
        if (item != null) {
            Debug.Log("Removed $" + item.price);
            items.Remove(other.gameObject);
        }
    }
}
