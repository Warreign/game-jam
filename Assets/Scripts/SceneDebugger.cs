using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChecker : MonoBehaviour
{
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        Debug.Log("Scene " + SceneManager.GetActiveScene().name + " was loaded");
        mainCamera.enabled = true;
    }

    void OnDisable()
    {
        Debug.Log("Scene " + SceneManager.GetActiveScene().name + " was unloaded");
        // mainCamera.enabled = false;
    }
}
