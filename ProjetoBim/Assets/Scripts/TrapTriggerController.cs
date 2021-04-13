using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TrapTriggerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        GameObject player= other.gameObject;
        player.GetComponent<SimpleSampleCharacterControl>().ManageLife();
    }
}
