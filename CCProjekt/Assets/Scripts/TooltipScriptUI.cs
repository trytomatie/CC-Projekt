using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipScriptUI : MonoBehaviour
{
    public Transform tooltipTarget;
    public Vector3 offset = new Vector3(0, 1, 0);
    public Camera c;

    private RectTransform rTransform;
    // Start is called before the first frame update
    void Start()
    {
        c = Camera.main;
        rTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tooltipTarget == null)
        {
            rTransform.localPosition = new Vector3(10000, 0, 0);
        }
        else
        {
            transform.position = c.WorldToScreenPoint(tooltipTarget.position + offset);
        }

    }
}
