using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBehaviour : MonoBehaviour
{

    public float speed = 0.5f;
    public Image imageComponent;

    // Start is called before the first frame update
    void Start()
    {
        imageComponent.material.mainTextureOffset = new Vector2(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * speed, Time.time * speed);

        imageComponent.material.mainTextureOffset = offset;
    }
}
