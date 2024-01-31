using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float speed = 0.1f;
    private Transform myTransform;
    private BoxCollider2D boxColl;

    [SerializeField] GameObject link;
    InputManager inputManager;

    // Atributos para la caja que determina los bordes de la pantalla del juego (sin UI)
    float BoxSizeX = 13.3f;
    float BoxSizeY =  7.15f;
    float BoxOffsetX = 0f;
    float BoxOffsetY = -1.425f;

    float xDistance;
    float yDistance;

    // Start is called before the first frame update
    void Start()
    {
        float margen = 1f;
        myTransform = transform;

        boxColl = GetComponent<BoxCollider2D>();
        boxColl.size = new Vector2(BoxSizeX, BoxSizeY);
        boxColl.offset = new Vector2(BoxOffsetX, BoxOffsetY);

        xDistance = ((10f / Screen.height * Screen.width) / 2) - 0.2f;
        yDistance = 4.8f + BoxOffsetY;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StartCoroutine(Desplazamiento());
    }

    IEnumerator Desplazamiento()
    {
        Vector3 currentPos = myTransform.position;
        Vector3 targetPos;

        float xLink = link.transform.position.x - myTransform.position.x;
        float yLink = link.transform.position.y - (myTransform.position.y + BoxOffsetY);

        if (xLink > xDistance)
            targetPos = currentPos + new Vector3(boxColl.size.x, 0, 0);
        else if (xLink < -xDistance)
            targetPos = currentPos + new Vector3(-boxColl.size.x, 0, 0);
        else if (yLink > yDistance)
            targetPos = currentPos + new Vector3(0, boxColl.size.y, 0);
        else
            targetPos = currentPos + new Vector3(0, -boxColl.size.y, 0);

        while (myTransform.position != targetPos)
        {
            
            myTransform.position = Vector3.MoveTowards(myTransform.position, targetPos, speed);
            yield return null;
        }
    }
}
