using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private int totalRupias;
    private int totalBombas;
    [SerializeField] private TMP_Text textoRupias;
    [SerializeField] private TMP_Text textoBombas;

    private void Start()
    {
       RupiesController.sumaRupias += SumarRupias;
       BlueRupieController.sumaRupias += SumarRupiasAzules;
       BombasController.sumaBombas += SumarBombas;
    }

    private void SumarRupias(int rupias)
    {
        totalRupias += rupias;
        textoRupias.text = totalRupias.ToString();

    }
    private void SumarRupiasAzules(int rupiasazules)
    {
        totalRupias += rupiasazules;
        textoRupias.text = totalRupias.ToString();
    }
    private void SumarBombas(int bombas)
    {
        totalBombas += bombas;
        textoBombas.text = totalBombas.ToString();

    }



}
