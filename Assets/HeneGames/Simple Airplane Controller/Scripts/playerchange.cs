using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using HeneGame.Airplane.SimpleAirPlaneController;

// 飛行機にアタッチしておく
public class playerchange : MonoBehaviour
{
    // カメラ（GameObject型）で、publicで宣言する。
    public GameObject planeCamera;

    public HeneGames.Airplane.SimpleAirPlaneController sapc = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");

        // もし、接触した相手が、プレイヤーなら。
        if (collision.gameObject.CompareTag("Player"))
        {
            // カメラのseActiveをtrueにする。
            planeCamera.SetActive(true);

            // sapcのenableをtrueにする。
            sapc.enabled = true;

            // プレイヤーのSetActiveをfalseにする。
            collision.gameObject.SetActive(false);
        }
    }
}

