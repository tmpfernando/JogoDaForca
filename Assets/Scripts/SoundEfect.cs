using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEfect : MonoBehaviour
{
    public AudioClip audioClip; //esta variável é atribuida por outro script, carregará o efeito de som de vitória ou derrota

    AudioSource audioSource; //vairável declarada para manipular a componente audio source

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); //atribuição do audiosource na variável

        if (GameObject.FindGameObjectsWithTag("soundEffect").Length > 1) //caso haja outro objeto com esta tag, este será removido
        {
            Object.Destroy(gameObject); //remove este objeto
        }
        else //caso este seja o único objeto com a tag soundEffect
        {
            audioSource.playOnAwake = false; //play on awake é definido false, pois primeiro é necessário selecionar o clipe de audio certo antes de dar o play
            audioSource.volume = PlayerPrefs.GetFloat("musicVolume"); //capturamos o volume atual
            audioSource.clip = audioClip; //o clipe de audio do efeito é selecionado através de outro script
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
