using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SetVolumen : MonoBehaviour
{
    public AudioMixerGroup musica, efectos;

    public void SetMúsica(float sliderValue)
    {
        musica.audioMixer.SetFloat("musica", Mathf.Log10(sliderValue) * 20);
    }
    public void SetEfectos(float sliderValue)
    {
        efectos.audioMixer.SetFloat("efectos", Mathf.Log10(sliderValue) * 20);
    }
}
