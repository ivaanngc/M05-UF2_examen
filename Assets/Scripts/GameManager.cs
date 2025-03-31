using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Player player;
    public int points;
    public TMP_Text pointsText;
    public TMP_Text lifesText;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        pointsText.text = points.ToString("00000");
        lifesText.text = player.life.ToString();
    }
}
