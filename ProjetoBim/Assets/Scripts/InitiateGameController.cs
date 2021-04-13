using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitiateGameController : MonoBehaviour
{
   public void StartGame(){
        SceneManager.LoadScene("Cena1");
    }
}
