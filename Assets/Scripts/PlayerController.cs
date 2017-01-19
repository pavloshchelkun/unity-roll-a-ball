using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10f;

    private Rigidbody _rb;
    
    private void Start ()
    {
        _rb = GetComponent<Rigidbody>();
	}

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        _rb.AddForce(movement * Speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
