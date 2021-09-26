using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintBehaviour : MonoBehaviour
{

    public string hint; //esta variável recebe o texto de dica da palavra oculta
    

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = hint; //define o counteúdo do texto apresentado na tela

        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 4); //ajuste de tamanho
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width - WordBehaviour.letterSize); //ajuste de tamanho

        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, Screen.height / 3); //ajuste de posição

    }
}
