using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectStar : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collide");
        if (collision.gameObject.CompareTag("star")) {
            //Debug.Log("get star");
            player.GetComponent<PlayerForce>().starNum += 1;
            Color temp = collision.gameObject.GetComponent<starFollow>().followStar.GetComponent<SpriteRenderer>().color;
            temp.a = 1f;
            collision.gameObject.GetComponent<starFollow>().followStar.GetComponent<SpriteRenderer>().color = temp;
            Destroy(collision.gameObject);
        }
    }
}
