using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Endoflevel : MonoBehaviour
{
    int lastLevel;
    private void Start()
    {
        lastLevel = SceneManager.sceneCountInBuildSettings-1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && SceneManager.GetActiveScene().buildIndex < lastLevel)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
