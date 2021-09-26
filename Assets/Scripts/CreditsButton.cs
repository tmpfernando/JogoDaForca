using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() //ajuste de tamanho e posição de acordo com o tamanho da tela
    {
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 1.5f);
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 10);
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -2.8f * Screen.height / 10);
    }

    public void OnClick() //abre a cena dos créditos quando o botão é clicado
    {
        SceneManager.LoadScene("Credits");
    }
}
