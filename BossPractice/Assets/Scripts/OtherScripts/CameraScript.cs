using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject Player = null;
    [SerializeField]
    private Vector3 offset;

    void LateUpdate()
    {
        float newXPosition = Player.transform.position.x - offset.x;
        float newYPosition = Player.transform.position.y - offset.y;
        //float newZPosition = Player.transform.position.z - offset.z;

        transform.position = new Vector3(newXPosition, newYPosition, transform.position.z);
    }
}
