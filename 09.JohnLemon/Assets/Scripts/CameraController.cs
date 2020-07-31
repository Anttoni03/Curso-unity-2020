using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform ghost;
    public Transform player;
    private CinemachineVirtualCamera _camera;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CinemachineVirtualCamera>();
        ghost = GetComponent<Transform>();
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    public void BathroomEnter()
    {
        _camera.LookAt = ghost;
    }

    public void BathroomExit()
    {
        _camera.LookAt = player;
    }
}
