using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InventoryController : MonoBehaviour
{
    public GameObject panel;
    public Transform cellsObject;
    public PlayerController player;

    private CellController[] cells;
    private bool opened;

    void Start()
    {
        opened = panel.activeInHierarchy;
        cells = new CellController[cellsObject.childCount];
        for (int i = 0; i < cellsObject.childCount; i++)
        {
            cells[i] = cellsObject.GetChild(i).GetComponent<CellController>();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Action"))
        {
            if (opened)
                Close();
            else
                Open();
        }
        if (Input.GetButtonDown("Cancel"))
        {
            if (opened)
                Close();
        }
    }

    public void AddItem(Item i)
    {
        foreach (CellController c in cells)
        {
            if (c.isEmpty)
            {
                c.item = i.gameObject;
                c.thumbnail.sprite = i.thumbnail.sprite;
                c.thumbnail.color = i.thumbnail.color;
                i.gameObject.SetActive(false);
                Debug.Log(i.name + " added to inventory");
                return;
            }
        }
        Debug.Log("inventory is empty");
    }


    public void Open()
    {
        opened = true;
        player.canMove = false;
        panel.SetActive(true);
    }

    public void Close()
    {
        opened = false;
        player.canMove = true;
        panel.SetActive(false);
    }
}
