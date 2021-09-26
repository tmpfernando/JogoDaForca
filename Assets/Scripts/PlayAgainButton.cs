using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() //ajustes de tamanho e posi��o ao instanciar o objeto
    {
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 1.5f);
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 10);
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, - 2.8f * Screen.height / 10);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) //caso ENTER seja precionado, o bot�o para jogar novamente ser� acionado
        {
            OnClick();
        }
    }

    public void OnClick() 
    {
        SceneManager.LoadScene("Playing"); //caso o bot�o seja clicado, ser� feita a transi��o para a cena do jogo
    }
}
