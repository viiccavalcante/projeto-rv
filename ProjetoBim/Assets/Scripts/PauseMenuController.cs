using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused = false;
    public GameObject player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");   
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.P)) {
           
           if(isPaused){
               ResumeGame();
           }else{
               isPaused=true;
               pauseMenu.SetActive(true);
               Time.timeScale =0f;
           }
        }
    }
     public void RestartGame(){
        Time.timeScale =1f;
        player.SetActive(false);
        SceneManager.LoadScene("InitialMenuScene"); 
    }

    public void ResumeGame(){
        isPaused=false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
