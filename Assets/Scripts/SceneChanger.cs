using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneToLoad;

    private void OnMouseDown()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
