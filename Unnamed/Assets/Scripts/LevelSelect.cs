using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour
{
    // Start is called before the first frame update
   public void levelSelect1()
    {
        SceneManager.LoadScene("Level_0");
    }

    public void levelSelect2()
    {
        SceneManager.LoadScene("Level_1");
    }

}
