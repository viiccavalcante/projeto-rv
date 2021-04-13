using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameController : MonoBehaviour
{
    public AnimationClip anim;
    private void OnTriggerEnter(Collider other) {
        GameObject player = other.gameObject;
        player.GetComponent<SimpleSampleCharacterControl>().EndGame();
    }
}
