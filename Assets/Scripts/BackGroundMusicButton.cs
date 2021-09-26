using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMusicButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() //no start fazemos o ajuste de posição e tamanho de acordo com o tamanho da tela
    {
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 1.5f); //define tamanho horizontal
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 15); //define tamanho vertical
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, - 1 * Screen.height / 15); //define posição na tela
    }

    public void OnClick() //abrir o link da asset store quando o botão for clicado
    {
        Application.OpenURL("https://assetstore.unity.com/packages/audio/music/electronic/underwater-blues-125925");
    }
}
