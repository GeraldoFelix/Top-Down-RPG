using UnityEngine;

public class CameraMagnet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject camera_center;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            if (Camera.main.GetComponent<CameraBehavior>().obejct_target == collision.gameObject)
            {
                Camera.main.GetComponent<CameraBehavior>().obejct_target = camera_center;
            }
            else {
                Camera.main.GetComponent<CameraBehavior>().obejct_target = collision.gameObject;
            }
        }
    }
}
