using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class Preload : MonoBehaviour
{
    [SerializeField] private Image raionLogo;
    [SerializeField] private Image devindoLogo;

    void Start()
    {
        Call();
    }

    private void Call()
    {
        Color _c1 = raionLogo.color;
        Color _c3 = devindoLogo.color;

        _c1.a = 0;
        _c3.a = 0;

        raionLogo.color = _c1;
        devindoLogo.color = _c3;

        DOVirtual.DelayedCall(.5f, () =>
        {
            PlayRaionLogo();
        });
    }

    private void PlayRaionLogo()
    {
        Color _c = raionLogo.color;

        DOVirtual.Float(0f, 1f, 1f, (a) =>
        {
            _c.a = a;
            raionLogo.color = _c;
        }).OnComplete(() =>
        {
            DOVirtual.Float(1f, 0f, 1f, (a) =>
            {
                _c.a = a;
                raionLogo.color = _c;
            }).OnComplete(PlayDevindoLogo);
        });
    }

    private void PlayDevindoLogo()
    {
        Color _c = devindoLogo.color;

        DOVirtual.Float(0f, 1f, 1f, (a) =>
        {
            _c.a = a;
            devindoLogo.color = _c;
        }).OnComplete(() =>
        {
            DOVirtual.Float(1f, 0f, 1f, (a) =>
            {
                _c.a = a;
                devindoLogo.color = _c;
            }).OnComplete(LoadMainMenuScene);
        });
    }

    private void LoadMainMenuScene()
    {
        //SceneManager.LoadScene("Main Menu");
    }
}
