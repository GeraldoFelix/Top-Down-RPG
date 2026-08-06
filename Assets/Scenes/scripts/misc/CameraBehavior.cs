using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject obejct_target;
    GameObject player_;
    void Start()
    {
        player_ = GameObject.FindGameObjectWithTag("Player");
        obejct_target = player_;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(this.transform.position, new Vector3(obejct_target.transform.position.x, obejct_target.transform.position.y, -10), 1f * Time.fixedDeltaTime);
    }
}
