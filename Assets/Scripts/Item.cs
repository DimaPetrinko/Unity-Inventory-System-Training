using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Item : MonoBehaviour
{
    public Image thumbnail;
// { get; private set; }

    void Start()
    {
        thumbnail = GetComponent<Image>();
    }
}

