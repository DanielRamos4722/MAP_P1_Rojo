using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Transform _myTransform;
    public int maxhealth; 
    private int initialmaxhealth;
    public GameObject Rupia;
    public GameObject RupiaAzul;
    public GameObject Corazon;
    private void Awake()
    {
        //Esto luego se hará algo para cambiarlo para cada enemigo, ¿con un public o algo así?
       initialmaxhealth = maxhealth = 3;
    }

    // Start is called before the first frame update
    void Start()
    {
        //para saber la posición donde crear los prefabs
        _myTransform = transform;
    }
    public void Damaged() 
    {
        maxhealth--;
        Debug.Log(maxhealth);
        if (maxhealth <= 0) { Death(); }  
    }
    private void Death()
    {
        //Drop();
        Destroy(gameObject);
    }
    private void Drop()
    {
        //decidir cuál será el drop para el enemigo
        int i;
         Randomize(100,out i);
        i +=  initialmaxhealth*2;
        if (i <= 40) { }
        else if(i<=65)
        {
            Instantiate(Rupia, _myTransform.position,new Quaternion (0,0,0,0));
        }
        else if (i <= 90) 
        {
           Instantiate(Corazon, _myTransform.position, new Quaternion(0, 0, 0, 0));
        }
        else if (i >90) 
        {
            Instantiate(RupiaAzul, _myTransform.position, new Quaternion(0, 0, 0, 0));
        }

    }
     private void Randomize(int max, out int i)
    {
       i= Random.Range(0,max);       
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Playermove playermove = collision.gameObject.GetComponent<Playermove>();
        print("va");

        if (playermove)
        {
            Vector3 guaya = (collision.gameObject.transform.position - _myTransform.position) - collision.transform.position;

            playermove.rb.AddForce(guaya.normalized * 3);
            print("va");
        }
    }
}
