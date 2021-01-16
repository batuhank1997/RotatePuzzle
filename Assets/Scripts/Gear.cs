using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public GameObject effect;
    public GameObject camera;
    bool isSuccess;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.I.gears.Add(gameObject);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.I.gears.Count != 1)
        {
            if (GameManager.I.gears[0] == gameObject)
            {
                //Option 1
                /*transform.Rotate(0, 0.8f, 0);

                if (Input.GetMouseButtonDown(0))
                {
                    if (gameObject.transform.rotation.eulerAngles.y > 300 && gameObject.transform.rotation.eulerAngles.y < 360)
                    {
                        //isSuccess = true;
                        rb.velocity = new Vector3(0, -speed, 0);
                        gameObject.tag = "Untagged";
                    }
                }*/

                //Option2
                if(!isSuccess)
                    SetAngle();

                if ((int)gameObject.transform.rotation.eulerAngles.y == (int)GameManager.I.gears[1].transform.rotation.eulerAngles.y)
                {
                    isSuccess = true;
                    rb.velocity = new Vector3(0, -speed, 0);
                    gameObject.tag = "Untagged";
                }
            }
        }
    }
    
    void SetAngle()
    {
        if(Input.GetMouseButton(0))
            transform.RotateAround(Vector3.up, -Input.GetAxis("Mouse X") * 5 * Mathf.Deg2Rad);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gear")
        {
            Instantiate(effect, gameObject.transform.position, Quaternion.identity);

            camera.GetComponent<Animator>().Play("Shake");
            Handheld.Vibrate();

            if (GameManager.I.gears[0] == gameObject)
            {
                GameManager.I.gears.Remove(gameObject);

                //GetComponent<MeshRenderer>().material.color = other.gameObject.GetComponent<MeshRenderer>().material.color;
                rb.velocity = Vector3.zero;
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<Rigidbody>().isKinematic = true;

                transform.position = other.gameObject.transform.position;
                transform.rotation = other.gameObject.transform.rotation;
                gameObject.transform.parent = other.gameObject.transform;
            }
        }
        
    }
}
