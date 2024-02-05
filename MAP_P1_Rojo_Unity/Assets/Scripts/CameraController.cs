using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    private Transform myTransform;
    private BoxCollider2D boxColl;

    public GameObject MinimapLink;
    public float moveAmount = 1.0f;

    [SerializeField] GameObject link;
    InputManager inputManager;

    // Atributos para la caja que determina los bordes de la pantalla del juego (sin UI)
    float BoxSizeX = 13.35f;
    float BoxSizeY =  7.15f;
    float BoxOffsetX = 0f;
    float BoxOffsetY = -1.425f;

    float xDistance;
    float yDistance;

    int scene;

    private void Awake()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
    }

    // Start is called before the first frame update
    void Start()
    {
        float margen = 0f;
        myTransform = transform;

        boxColl = GetComponent<BoxCollider2D>();
        boxColl.size = new Vector2(BoxSizeX - margen, BoxSizeY - margen);
        boxColl.offset = new Vector2(BoxOffsetX, BoxOffsetY);

        xDistance = 6.675f - margen;
        yDistance = 3.575f - margen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(scene == 1)
            StartCoroutine(Desplazamiento());
    }

    IEnumerator Desplazamiento()
    {
        Vector3 currentPos = myTransform.position;
        Vector3 targetPos;

        Vector3 linkMove;
        float linkDist = 0.1f;
        float speed = 0.1f;
        float speedL = 0.0002f;

        float xLink = link.transform.position.x - myTransform.position.x;
        float yLink = link.transform.position.y - (myTransform.position.y + BoxOffsetY);

        if (xLink > xDistance)
        {
            targetPos = currentPos + new Vector3(BoxSizeX, 0, 0);
            linkMove = link.transform.position + new Vector3(linkDist, 0, 0);
            MinimapLink.transform.Translate(new Vector3(moveAmount,0,0));
        }
            
        else if (xLink < -xDistance)
        {
            targetPos = currentPos + new Vector3(-BoxSizeX, 0, 0);
            linkMove = link.transform.position + new Vector3(-linkDist, 0, 0);
            MinimapLink.transform.Translate(new Vector3(-moveAmount, 0, 0));
        }
            
        else if (yLink > yDistance)
        {
            targetPos = currentPos + new Vector3(0, BoxSizeY, 0);
            linkMove = link.transform.position + new Vector3(0, linkDist, 0);
            MinimapLink.transform.Translate(new Vector3(0, moveAmount, 0));
        }
            
        else
        {
            targetPos = currentPos + new Vector3(0, -BoxSizeY, 0);
            linkMove = link.transform.position + new Vector3(0, -linkDist, 0);
            MinimapLink.transform.Translate(new Vector3(0, -moveAmount, 0));
        }

        while (myTransform.position != targetPos)
        {
            //link.transform.position = Vector3.MoveTowards(link.transform.position, linkMove, speedL);
            myTransform.position = Vector3.MoveTowards(myTransform.position, targetPos, speed);
            yield return null;
        }
    }
}
