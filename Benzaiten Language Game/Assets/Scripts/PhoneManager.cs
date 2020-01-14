using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{

    private Vector3 phoneUp, phoneDown, screenUp, screnDown;
    private bool show, social, settings;
    [SerializeField]
    private Transform socialTransform, settingsTransform;
    [SerializeField]
    private GameObject guide, kaoru, bird;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        phoneUp = new Vector3(0, -0.45f, 0);
        phoneDown = new Vector3(0, -21f, 0);
        screenUp = new Vector3(0, -0.5f, 0);
        screnDown = new Vector3(0, -21f, 0);

        speed = 3f;

        transform.localPosition = phoneDown;
        socialTransform.localPosition = screnDown;
        settingsTransform.localPosition = screnDown;

        show = false;
        social = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (show)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, phoneUp, Time.deltaTime * speed);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, phoneDown, Time.deltaTime * speed);
        }

        if (social)
        {
            socialTransform.localPosition = Vector3.Lerp(socialTransform.localPosition, screenUp, Time.deltaTime * speed);
        }
        else
        {
            socialTransform.localPosition = Vector3.Lerp(socialTransform.localPosition, screnDown, Time.deltaTime * (speed * 2));
        }

        if (settings)
        {
            settingsTransform.localPosition = Vector3.Lerp(settingsTransform.localPosition, screenUp, Time.deltaTime * speed);
        }
        else
        {
            settingsTransform.localPosition = Vector3.Lerp(settingsTransform.localPosition, screnDown, Time.deltaTime * (speed * 2));
        }

    }

    public void IconClick(string appName)
    {
        if (!social || !settings)
        {
            if (appName == "Social")
            {
                UpdateSocial();
                social = true;
            }
            else if (appName == "Settings")
            {
                settings = true;
            }
        }
    }

    private void OnMouseDown()
    {
        if (social || settings)
        {
            social = false;
            settings = false;
        }
        else
        {
            show = false;
        }
    }

    private void UpdateSocial()
    {
        Dictionary<string, float> playerProgression = GameObject.Find("DataHolder").GetComponent<DataHolder>().player.PlayerProgression;

        guide.SetActive(playerProgression["Guide"] >= 1);
        kaoru.SetActive(playerProgression["Kaoru"] >= 1);
        bird.SetActive(playerProgression["BaristaBird"] >= 1);
    }

    public bool Show
    {
        get
        {
            return show;
        }

        set
        {
            show = value;
        }
    }
}
