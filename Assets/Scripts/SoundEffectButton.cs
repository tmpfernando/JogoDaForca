using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() //ajustes de tamanho e posição ao instanciar o objeto na cena do jogo
    {
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.width / 1.5f);
        GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 15);
        GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -2 * Screen.height / 15);
    }

    public void OnClick() //ao acionar o botão, o link será aberto
    {
        Application.OpenURL("https://assetstore.unity.com/packages/audio/sound-fx/free-casual-game-sfx-pack-54116");
    }
}
