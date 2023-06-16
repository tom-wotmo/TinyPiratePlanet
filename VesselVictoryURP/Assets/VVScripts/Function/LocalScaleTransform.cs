using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalScaleTransform : MonoBehaviour
{
    void Start()
    {
        ScaleTransform();
    }
    private void ScaleTransform()
    {
        
        Vector2 screenSize = new Vector2(Screen.width, Screen.height);
        Vector3 objectSize = transform.localScale;

        float widthScale = screenSize.x / objectSize.x;
        float heightScale = screenSize.y / objectSize.y;

        transform.localScale = new Vector3(widthScale, heightScale, 1f);
    }
}
