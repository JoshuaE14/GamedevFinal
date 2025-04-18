using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Destroy : MonoBehaviour
{
    private float timer = 0f;  // Timer to track elapsed time
    public float destroyTime = 30f;  // Time (in seconds) before the object is destroyed
    public Transform target;
    public int Message;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timer += Time.deltaTime;  // Increment the timer by the time passed since the last frame

        if (timer >= destroyTime)  // Check if 30 seconds have passed
        {
            Destroy(gameObject);  // Destroy the object this script is attached to
            Debug.Log("Obj destroy");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == target)
        {
            Destroy(gameObject);
            Debug.Log("Player has been damaged");
        }
    }
}