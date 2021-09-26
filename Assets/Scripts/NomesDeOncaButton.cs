using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomesDeOncaButton : MonoBehaviour
{
    void Start() //no start fazemos o ajuste de posição e tamanho de acordo com o tamanho da tela
    {
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 1.5f); //define tamanho horizontal
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 15); //define tamanho vertical
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0 * Screen.height / 15); //define posição na tela
    }

    public void OnClick() //abrir o link da asset store quando o botão for clicado
    {
        Application.OpenURL("https://www.revistas.usp.br/azmz/article/view/126851/129609");
    }
}
