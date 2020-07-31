using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    public GameObject cinematicCamera;
    public CinemachineDollyCart cinemachineDollyCart;

    public CinemachineVirtualCamera playerCamera;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (cinemachineDollyCart.m_Position == 0)
        {
            playerCamera.gameObject.SetActive(true);
            cinematicCamera.SetActive(false);
        }
    }
}
