using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScene : MonoBehaviour
{
    GameObject soundEffect; //esta variável receberá o prefab que será instanciado com o efeito de audio de vitória

    // Start is called before the first frame update
    void Start()
    {
        
        soundEffect = Resources.Load<GameObject>("Prefabs/SoundEffect"); //atribuição do prefab à variável para que possa ser manipulado neste script

        if (GetComponent<Text>().text == "Você Acertou!!!") //este script foi anexado aos textos de vitoria e derrota, então caso seja o texto de vitória...
        { 
            soundEffect.GetComponent<SoundEfect>().audioClip = Resources.Load<AudioClip>("Audio/win"); //o clipe de audio para vitória será atribuido ao prefab 
        }
        else if (GetComponent<Text>().text == "Você Falhou!!!") //caso seja o texto de derrota mostrado na tela
        {
            soundEffect.GetComponent<SoundEfect>().audioClip = Resources.Load<AudioClip>("Audio/lost"); // o clipe de audio para derrota será atribuido ao prefab
        }

        Instantiate(soundEffect); //objeto que reproduz o clipe de audio é instanciado

        GetComponent<Text>().text += "\nA Palavra era: " + WordBehaviour.word + "\n"; //texto mostrando qual era a palavra correta
    }
}
