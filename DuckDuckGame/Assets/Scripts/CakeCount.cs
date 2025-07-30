using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class CakeCount : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cakeCountText;
    [SerializeField] int totalCakeSlices;

    public void UpdateCakeCount(int currentSlices)
    {
        cakeCountText.text = currentSlices + "/" + totalCakeSlices;
    }
}

