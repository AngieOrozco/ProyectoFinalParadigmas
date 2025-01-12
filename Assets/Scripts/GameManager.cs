using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject alien1; 
    public GameObject alien2;

    private bool alien1Dead = false;
    private bool alien2Dead = false;

    void Update()
    {
        if (alien1 != null && alien1.GetComponent<AlienController>().isDead)
        {
            alien1Dead = true;
        }

        if (alien2 != null && alien2.GetComponent<AlienController>().isDead)
        {
            alien2Dead = true;
        }

        if (alien1Dead || alien2Dead)
        {
            StartCoroutine(WaitAndRestart());
        }
    }

    IEnumerator WaitAndRestart()
    {
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


