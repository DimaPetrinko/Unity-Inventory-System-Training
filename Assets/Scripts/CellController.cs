using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CellController : MonoBehaviour
{
    public GameObject item;
    public Image thumbnail;

    public bool isEmpty { get { return item == null; } private set { } }

    //    void Update()
    //    {
    //        if (!isEmpty)
    //        {
    //            if (!thumbnail.gameObject.activeInHierarchy)
    //                thumbnail.gameObject.SetActive(true);
    //        }
    //        else
    //        {
    //            if (thumbnail != null)
    //            {
    //                if (thumbnail.gameObject.activeInHierarchy)
    //                    thumbnail.gameObject.SetActive(false);
    //            }
    //        }
    //    }
}
