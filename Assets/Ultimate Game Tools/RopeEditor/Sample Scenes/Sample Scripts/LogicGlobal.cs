using UnityEngine;
using System.Collections;

public class LogicGlobal : MonoBehaviour
{
    void Start()
    {

    }

    public static void GlobalGUI()
    {
        GUILayout.Label("Press 1-4 to select different sample scenes");
        GUILayout.Space(20);
    }

    void Update()
    {
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
