using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    Vector3 offset = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //docelowa pozycja kamery
        //zapamietal offset kamery i uzyl tu by uzyskac nowa poycje kamery
        Vector3 targetPosition = player.transform.position + offset;
        //plynna animacja przesuwania
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
    }
}
