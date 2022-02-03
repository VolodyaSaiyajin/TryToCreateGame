using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("GameObject")]

    [SerializeField] private Transform player;

    private void FixedUpdate()
    {
        UpdateCameraPositon();
    }

    void UpdateCameraPositon()
    {
            transform.position = new Vector3(
                player.localPosition.x,
                player.localPosition.y,
               player.localPosition.z - 10);
    }
}
