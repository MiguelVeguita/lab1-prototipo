using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.SceneManagement;



public class GameManager : MonoBehaviour
{
    [Header("restar Menu")]
    public TextMeshProUGUI pauseText;

    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            restar();
        }
    }
    public void restar()
    {
        SceneManager.LoadScene("SampleScene");

    }
    




}