using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private KeyCode key1;
    [SerializeField] private KeyCode key2;
    [SerializeField] private Vector3 moveDirecton;

    void FixedUpdate()
    {
        if (Input.GetKey(key1))
        {
            GetComponent<Rigidbody>().velocity += moveDirecton;
        }

        if (Input.GetKey(key2))
        {
            GetComponent<Rigidbody>().velocity -= moveDirecton;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Cube") && other.CompareTag("Cube") || this.CompareTag("Player") && other.CompareTag("Cube"))
        {
            foreach (Activator button in FindObjectsOfType<Activator>())
            {
                button.canPush = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.CompareTag("Cube") && other.CompareTag("Cube") || this.CompareTag("Player") && other.CompareTag("Cube"))
        {
            foreach (Activator button in FindObjectsOfType<Activator>())
            {
                button.canPush = true;
            }
        }
    }
}