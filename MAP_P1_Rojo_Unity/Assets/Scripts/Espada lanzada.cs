using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Espadalanzada : MonoBehaviour
{
    public GameObject efecto;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject efecto1 = Instantiate(efecto, collision.gameObject.transform.position, Quaternion.identity);
        efecto1.GetComponent<Rigidbody2D>().velocity = new Vector3(-2, 2);

        GameObject efecto2 = Instantiate(efecto, collision.gameObject.transform.position, Quaternion.identity);
        efecto2.GetComponent<SpriteRenderer>().flipX = true;
        efecto2.GetComponent<Rigidbody2D>().velocity = new Vector3(2, 2);

        GameObject efecto3 = Instantiate(efecto, collision.gameObject.transform.position, Quaternion.identity);
        efecto3.GetComponent<SpriteRenderer>().flipY = true;
        efecto3.GetComponent<Rigidbody2D>().velocity = new Vector3(-2, -2);

        GameObject efecto4 = Instantiate(efecto, collision.gameObject.transform.position, Quaternion.identity);
        efecto4.GetComponent<SpriteRenderer>().flipY = true;
        efecto4.GetComponent<SpriteRenderer>().flipX = true;
        efecto4.GetComponent<Rigidbody2D>().velocity = new Vector3(2, -2);

        

        Destroy(efecto1, 0.25f);
        Destroy(efecto2, 0.25f);
        Destroy(efecto3, 0.25f);
        Destroy(efecto4, 0.25f);
        Destroy(this.gameObject);
    }
}
