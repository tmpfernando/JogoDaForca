using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEfect : MonoBehaviour
{
    public AudioClip audioClip; //esta vari�vel � atribuida por outro script, carregar� o efeito de som de vit�ria ou derrota

    AudioSource audioSource; //vair�vel declarada para manipular a componente audio source

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); //atribui��o do audiosource na vari�vel

        if (GameObject.FindGameObjectsWithTag("soundEffect").Length > 1) //caso haja outro objeto com esta tag, este ser� removido
        {
            Object.Destroy(gameObject); //remove este objeto
        }
        else //caso este seja o �nico objeto com a tag soundEffect
        {
            audioSource.playOnAwake = false; //play on awake � definido false, pois primeiro � necess�rio selecionar o clipe de audio certo antes de dar o play
            audioSource.volume = PlayerPrefs.GetFloat("musicVolume"); //capturamos o volume atual
            audioSource.clip = audioClip; //o clipe de audio do efeito � selecionado atrav�s de outro script
            audioSource.Play(); //reproduz o clipe de audio
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying) //quando o clipe de audio chega ao seu fim, este objeto pode ser removido
            Object.Destroy(gameObject);
    }

}
