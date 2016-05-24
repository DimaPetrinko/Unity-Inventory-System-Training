using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public InventoryController inventory;
    public float speed = 1f;

    public bool canMove { get; set; }

    private Transform myTransform;
    private Rigidbody rb;
    private Vector3 moveVector;

    void Awake()
    {
        myTransform = transform;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        canMove = true;
    }

    void Update()
    {

        if (canMove)
        {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                moveVector.x = Input.GetAxis("Horizontal");
                moveVector.z = Input.GetAxis("Vertical");
            }
            else
            {
                if (moveVector.sqrMagnitude != 0)
                {
                    moveVector = Vector3.Lerp(moveVector, Vector3.zero, speed * Time.deltaTime);
                }
            }
        }
        else
        {
            if (moveVector.sqrMagnitude != 0)
            {
                moveVector = Vector3.Lerp(moveVector, Vector3.zero, speed * Time.deltaTime);
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(myTransform.position + moveVector * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            PickUpItem(other.gameObject.GetComponent<Item>());
        }
    }

    void PickUpItem(Item i)
    {
        inventory.AddItem(i);
    }

}
