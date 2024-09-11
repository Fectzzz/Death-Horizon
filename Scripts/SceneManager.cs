using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public GameObject canvas;
    public GameObject button;
    public Animator animatorCanvas;

    void Start()
    {
        canvas.GetComponent<Animator>().enabled = false;
    }

    public void LoadGame()
    {
        canvas.GetComponent<Animator>().enabled = true;
        animatorCanvas.SetBool("isFade", true);
        button.SetActive(false);
    }
}