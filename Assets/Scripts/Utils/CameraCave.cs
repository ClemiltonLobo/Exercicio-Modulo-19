using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraCave : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCameraPlayer;
    public CinemachineVirtualCamera VirtualCameraFoguete;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            VirtualCameraPlayer.gameObject.SetActive(false);
            VirtualCameraFoguete.gameObject.SetActive(false);
        }        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            VirtualCameraPlayer.gameObject.SetActive(true);
            VirtualCameraFoguete.gameObject.SetActive(true);
        }
    }
}
