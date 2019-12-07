using UnityEngine;
using System.Collections;

public class GlobalSettings : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            Debug.Log("Load Jungle");
            UnityEngine.SceneManagement.SceneManager.LoadScene("JungleChallenge", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            Debug.Log("Load Store");
            UnityEngine.SceneManagement.SceneManager.LoadScene("StoreChallenge", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }
}
