using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIOptions : MonoBehaviour
{
    private int volume = 10;
    private int sfx = 10;

    public TextMeshProUGUI volumeLabel;
    public TextMeshProUGUI sfxLabel;


    private void Start()
    {
        volumeLabel.text = volume.ToString();
        sfxLabel.text = sfx.ToString();
    }

    public void AddVolume()
    {
        volume++;
        volume = Mathf.Clamp(volume, 0, 10);
        volumeLabel.text = volume.ToString();
       
    }

    public void MinusVolume()
    {
        volume--;
        volume = Mathf.Clamp(volume, 0, 10);
        volumeLabel.text = volume.ToString();
    }

    public void AddSFX()
    {
        sfx++;
        sfx = Mathf.Clamp(sfx, 0, 10);
        sfxLabel.text = sfx.ToString();
    }

    public void MinusSFX()
    {
        sfx--;
        sfx = Mathf.Clamp(sfx, 0, 10);
        sfxLabel.text = sfx.ToString();
    }
}
