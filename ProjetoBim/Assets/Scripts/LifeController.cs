using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    int life =3;
    public TMP_Text lifeText;
    
    private void OnTriggerEnter(Collider other) {
        
        var hit = other.gameObject;

        if(hit.CompareTag("Player")){
            life--;
            lifeText.text = "Vidas: " + life.ToString();
        
            if(life == 0){
                SceneManager.LoadScene("GameOverScene"); 
            }  
        }
        
    }

}
