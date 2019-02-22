using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private bool isPause = false;
    private Rect butCont;
    private Rect butSave;
    private Rect butMain;
    private Rect butQuit;
    private Rect textMessage;
    private Texture activeMessage;
    public Texture noneMessage;
    public Texture pauseMessage;


    void Awake()
    {
        float ctrlWidth = Screen.width / 2;
        float ctrlHeight = Screen.height / 8;
        butCont = new Rect((Screen.width - ctrlWidth) / 2, 0, ctrlWidth, ctrlHeight);
        butSave = new Rect((Screen.width - ctrlWidth) / 2, 0, ctrlWidth, ctrlHeight);
        butMain = new Rect((Screen.width - ctrlWidth) / 2, 0, ctrlWidth, ctrlHeight);
        butQuit = new Rect((Screen.width - ctrlWidth) / 2, 0, ctrlWidth, ctrlHeight);
        activeMessage = noneMessage;
        textMessage = new Rect((Screen.width - activeMessage.width) / 2, (Screen.height) / 8, activeMessage.width, activeMessage.height);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            ToggleTimeScale();
        if (isPause)
        {
            activeMessage = pauseMessage;
        }
        else
        {
            activeMessage = noneMessage;
        }
    }


    void OnGUI()
    {
        GUI.DrawTexture(textMessage, activeMessage);
        float ctrlHeight = Screen.height / 8;
        if (isPause)
        {
            butCont.y = (Screen.height - ctrlHeight) / 4;
            if (GUI.Button(butCont, "Continue"))
                ToggleTimeScale();
            butSave.y = butCont.y + ctrlHeight;
            if (GUI.Button(butSave, "Save"))
                Debug.Log("Save Dummy");
            butMain.y = butSave.y + ctrlHeight;
            if (GUI.Button(butMain, "Main Menu"))
                SceneManager.LoadScene(0, LoadSceneMode.Single);
            butQuit.y = butMain.y + ctrlHeight;
            if (GUI.Button(butQuit, "Quit"))
                Application.Quit();
        }
    }


    void ToggleTimeScale()
    {
        if (!isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        isPause = !isPause;
    }
}