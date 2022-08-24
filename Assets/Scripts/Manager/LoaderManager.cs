using UnityEngine;

public class LoaderManager : MonoBehaviour
{
    public GameObject UIScreen;
    public GameObject controllMan;
    public GameObject player;

    private GameObject playerStart;

    void Start()
    {
        if (ScreenFade.instance == null)
        {
            ScreenFade.instance = Instantiate(UIScreen).GetComponent<ScreenFade>();
        }
        if (PlayerController.instance == null)
        {
            PlayerController clone = Instantiate(player).GetComponent<PlayerController>();
            PlayerController.instance = clone;
            playerStart = GameObject.Find("Player Start");
            if (playerStart != null)
            {
                clone.transform.position = playerStart.transform.position;
            }
        }
        if (ControlManager.instance == null)
        {
            ControlManager.instance = Instantiate(controllMan).GetComponent<ControlManager>();
        }
    }
}
