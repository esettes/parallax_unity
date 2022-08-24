using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public float adjustmentY;
    [HideInInspector]
    public GameObject player;

    private void Start()
    {
        player = (GameObject)GameObject.FindGameObjectWithTag("Player");
        this.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x, (this.gameObject.transform.position.y) - adjustmentY, (this.gameObject.transform.position.z));
    }

    void LateUpdate()
    {
        if (player != null)
        {
            this.gameObject.transform.position = new Vector3(player.gameObject.transform.position.x, (this.gameObject.transform.position.y), (this.gameObject.transform.position.z));
        }
    }
}
