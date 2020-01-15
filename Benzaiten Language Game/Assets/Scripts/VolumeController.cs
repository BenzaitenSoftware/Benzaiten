using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    [SerializeField]
    private Sprite vol0, vol20, vol40, vol60, vol80, vol100;
    private DataHolder dataHolder;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        dataHolder = GameObject.Find("DataHolder").GetComponent<DataHolder>();
        sprite = GetComponent<SpriteRenderer>();
        switch (dataHolder.Volume)
        {
            case 0:
                sprite.sprite = vol0;
                break;
            case 0.2f:
                sprite.sprite = vol20;
                break;
            case 0.4f:
                sprite.sprite = vol40;
                break;
            case 0.6f:
                sprite.sprite = vol60;
                break;
            case 0.8f:
                sprite.sprite = vol80;
                break;
            case 1f:
                sprite.sprite = vol100;
                break;
        }

    }

    public void OnMouseDown()
    {
        switch (dataHolder.Volume)
        {
            case 0:
                dataHolder.VolumeUpdate(0.2f);
                sprite.sprite = vol20;
                break;
            case 0.2f:
                dataHolder.VolumeUpdate(0.4f);
                sprite.sprite = vol40;
                break;
            case 0.4f:
                dataHolder.VolumeUpdate(0.6f);
                sprite.sprite = vol60;
                break;
            case 0.6f:
                dataHolder.VolumeUpdate(0.8f);
                sprite.sprite = vol80;
                break;
            case 0.8f:
                dataHolder.VolumeUpdate(1f);
                sprite.sprite = vol100;
                break;
            case 1f:
                dataHolder.VolumeUpdate(0f);
                sprite.sprite = vol0;
                break;
        }
    }
}
