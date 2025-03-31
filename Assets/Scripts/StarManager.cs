using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    private float randScale;
    private float randAlpha;
    public SpriteRenderer sr;
    public List<Sprite> opcionesSprite;
    // Start is called before the first frame update
    void Start()
    {
        randScale = Random.Range(0.1f, 0.8f);
        randAlpha = Random.Range(0.3f, 1f);
        int escogido = Random.Range(0, opcionesSprite.Count);
        sr.sprite = opcionesSprite[escogido];
        transform.rotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        transform.localScale = transform.localScale * randScale;
        Color tmp = sr.color;
        tmp.a = randAlpha;
        sr.color = tmp;
    }
}
