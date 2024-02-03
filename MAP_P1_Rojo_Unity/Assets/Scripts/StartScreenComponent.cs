using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UIElements;

public class StartScreenComponent : MonoBehaviour
{
    private Animator _Animator;
    #region properties
    private bool txt;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        txt= true;
    }

    // Update is called once per frame
    void Update()
    {
        //Ir cambiando entre las variables de las animaciones para que parpadee la trifuerza, el press start y caiga el agua de la cascada
        if (txt)
        {
            txt = false;
            _Animator.SetBool("txt", false);
        }
        else if (!txt) 
        {
            txt = true;
            _Animator.SetBool("txt", true);
        }
        Task.Delay(1000);
    }
}
