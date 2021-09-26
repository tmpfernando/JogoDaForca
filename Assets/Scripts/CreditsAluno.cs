using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsAluno : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() //ajuste de posição e tamanho de acordo com o tamanho da tela
    {
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 2.5f);
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 1.2f);

        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, Screen.height / 4);
    }

}
