using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScene : MonoBehaviour
{
    GameObject soundEffect; //esta vari�vel receber� o prefab que ser� instanciado com o efeito de audio de vit�ria

    // Start is called before the first frame update
    void Start()
    {
        
        soundEffect = Resources.Load<GameObject>("Prefabs/SoundEffect"); //atribui��o do prefab � vari�vel para que possa ser manipulado neste script

        if (GetComponent<Text>().text == "Voc� Acertou!!!") //este script foi anexado aos textos de vitoria e derrota, ent�o caso seja o texto de vit�ria...
        { 
            soundEffect.GetComponent<SoundEfect>().audioClip = Resources.Load<AudioClip>("Audio/win"); //o clipe de audio para vit�ria ser� atribuido ao prefab 
        }
        else if (GetComponent<Text>().text == "Voc� Falhou!!!") //caso seja o texto de derrota mostrado na tela
        {
            soundEffect.GetComponent<SoundEfect>().audioClip = Resources.Load<AudioClip>("Audio/lost"); // o clipe de audio para derrota ser� atribuido ao prefab
        }

        Instantiate(soundEffect); //objeto que reproduz o clipe de audio � instanciado

        GetComponent<Text>().text += "\nA Palavra era: " + WordBehaviour.word + "\n"; //texto mostrando qual era a palavra correta
    }
}
