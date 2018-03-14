﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("LoadFirstScene", 2f);
	}

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}