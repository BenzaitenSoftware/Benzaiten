using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneManager : MonoBehaviour
{

    private Vector3 yUp, yDown, socialUp, socialDown;
    private bool show, social;
    [SerializeField]
    private Transform socialTransform;
    [SerializeField]
    private GameObject guide, kaoru, bird;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        yUp = new Vector3(0, -0.4f, 0);
        yDown = new Vector3(0, -21f, 0);
        socialUp = new Vector3(0, -0.5f, 0);
        socialDown = new Vector3(0, -21f, 0);

        speed = 3f;

        transform.localPosition = yDown;
        socialTransform.localPosition = socialDown;

        show = false;
        social = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (show)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, yUp, Time.deltaTime * speed);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, yDown, Time.deltaTime * speed);
        }

        if (social)
        {
            socialTransform.localPosition = Vector3.Lerp(socialTransform.localPosition, socialUp, Time.deltaTime * speed);
        }
        else
        {
            socialTransform.localPosition = Vector3.Lerp(socialTransform.localPosition, socialDown, Time.deltaTime * (speed * 2));
        }

        if (Input.GetKeyDown(KeyCode.A)) show = !show;
    }

    public void IconClick(string appName)
    {
        if (appName == "Social")
        {
            UpdateSocial();
            social = true;
        }
    }

    private void OnMouseDown()
    {
        if (social)
        {
            social = false;
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
