using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Update(){
        int DistanceAway = 17;
        int HeightAway = 18;
        Vector3 PlayerPOS = GameObject.Find("Player").transform.transform.position;
        GameObject.Find("Main Camera").transform.position = new Vector3(PlayerPOS.x, PlayerPOS.y + HeightAway, PlayerPOS.z - DistanceAway);

    }
}
