using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public static ScreenFade instance;

    public GameObject fadeScreenObject;
    public Image fadeScreenImage;

    public float fadeSpeed;
    public bool fadeToBlack;
    public bool fadeFromBlack;
    public bool fading = false;

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (fadeToBlack)
        {
            fadeScreenImage.color = new Color(fadeScreenImage.color.r, fadeScreenImage.color.g, fadeScreenImage.color.b, Mathf.MoveTowards(fadeScreenImage.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (fadeScreenImage.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }
        if (fadeFromBlack)
        {
            fadeScreenImage.color = new Color(fadeScreenImage.color.r, fadeScreenImage.color.g, fadeScreenImage.color.b, Mathf.MoveTowards(fadeScreenImage.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (fadeScreenImage.color.a == 0f)
            {
                fadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        fadeToBlack = true;
        fadeFromBlack = false;
        fading = true;

    }

    public void FadeFromBlack()
    {
        fadeToBlack = false;
        fadeFromBlack = true;
        fading = false;
    }
}
