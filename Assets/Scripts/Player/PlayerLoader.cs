using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        if (PlayerController.instance == null) Instantiate(player, this.transform);
        else
        { 
            PlayerController clone = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
    }
}
