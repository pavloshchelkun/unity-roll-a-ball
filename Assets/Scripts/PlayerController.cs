using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float Speed = 10f;
    public Text CountText;
    public Text WinText;

    private Rigidbody _rb;
    private int _count;
    
    private void Start ()
    {
        _rb = GetComponent<Rigidbody>();
        _count = 0;
        SetCountText();
        WinText.text = "";
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
            _count = _count + 1;
            SetCountText();
        }
    }

    private void SetCountText()
    {
        CountText.text = "Count: " + _count.ToString();

        if (_count >= 12)
        {
            WinText.text = "You win!";
        }
    }
}
