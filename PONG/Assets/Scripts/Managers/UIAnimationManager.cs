using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIAnimationManager : MonoBehaviour
{
    [Header("Start Menu")]
    [SerializeField] private RectTransform startGameButton;
    [SerializeField] private RectTransform endGameButton;
    [SerializeField] private RectTransform backgroundImage;
    
    [Header("Gameplay")]
    [SerializeField] private RectTransform gameplayElementsHolder;
    
    [Header("End Menu")]
    [SerializeField] private RectTransform topEndMenuHolder;
    [SerializeField] private RectTransform downEndMenuHolder;

    public void ShowStartMenu()
    {
        startGameButton.DOAnchorPosY( 100, 1f);
        endGameButton.DOAnchorPosY(-150, 1f);
    }
    
    public void HideStartMenu()
    {
        startGameButton.DOAnchorPosY( 700, 1f);
        endGameButton.DOAnchorPosY(-700, 1f);
        backgroundImage.DOAnchorPosY( -1500, 1f);
        
        gameplayElementsHolder.DOAnchorPosY(0, 1);
    }

    public void ShowEndMenu()
    {
        gameplayElementsHolder.DOAnchorPosY(150, 1);
        
        downEndMenuHolder.DOAnchorPosY(0, 1);
        topEndMenuHolder.DOAnchorPosY(0, 1);
    }

    public void TryAgainAnimation()
    {
        gameplayElementsHolder.DOAnchorPosY(0, 1);
        
        downEndMenuHolder.DOAnchorPosY(-1500, 1);
        topEndMenuHolder.DOAnchorPosY(650, 1);
    }
}
