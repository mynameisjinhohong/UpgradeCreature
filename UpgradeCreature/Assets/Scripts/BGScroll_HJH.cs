using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BGScroll_HJH : MonoBehaviour
{
    RawImage raw;
    public float scrollSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        raw = GetComponent<RawImage>();
    }

    float gogo = 0;
    // Update is called once per frame
    void Update()
    {
        gogo += Time.deltaTime * scrollSpeed;
        raw.uvRect = new Rect(gogo, 0, 1, 1);
    }
}
