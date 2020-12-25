using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathmenu : MonoBehaviour
{
    public void PlayGame(){
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);

    }
    public void QuitGame(){
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
