﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BacktoMain : MonoBehaviour
{
    public void returntoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
