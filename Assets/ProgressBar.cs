using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Image image;
    public float Value { get=>value; set { this.value = value; image.fillAmount = value; } }
    private float value;

}
