using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipController : MonoBehaviour
{
    public GameObject alien1;
    public GameObject alien2;

    public string nextSceneName;

    private bool alien1Reached = false;
    private bool alien2Reached = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == alien1)
        {
            alien1Reached = true;
        }
        else if (other.gameObject == alien2)
        {
            alien2Reached = true;
        }

        if (alien1Reached && alien2Reached)
        {
            StartCoroutine(WaitAndLoadNextLevel());
        }
    }

    IEnumerator WaitAndLoadNextLevel()
    {
        yield return new WaitForSeconds(2f);

        if (!string.IsNullOrEmpty(nextSceneName))
        {
            SceneManager.LoadScene(nextSceneName);
        }
        else
        {
            Debug.LogError("El nombre de la siguiente escena no ha sido asignado.");
        }
    }
}
