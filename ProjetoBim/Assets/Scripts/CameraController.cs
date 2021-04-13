using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offSet;
   
    void Start(){
        offSet.z = transform.position.z - player.transform.position.z;
        offSet.x = transform.position.x - player.transform.position.x;
    }

    void LateUpdate(){
        transform.position = new Vector3(player.transform.position.x + offSet.x,
        transform.position.y ,player.transform.position.z + offSet.z);

    }
}
