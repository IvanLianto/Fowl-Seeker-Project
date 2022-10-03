using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TomWill;
using UnityEngine.SceneManagement;
public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Image raionLogo;
    [SerializeField] private Image devindoLogo;

    [SerializeField] private Text titleText;
    [SerializeField] private Text pressText;

    void Start()
    {
        Call();
    }

    private void Call()
    {
        TWAudioController.PlayBGM("BGM_MAIN_MENU", "BGM_MAIN_MENU");
        Color _c1 = raionLogo.color;
        Color _c3 = devindoLogo.color;

        _c1.a = 0;
        _c3.a = 0;

        raionLogo.color = _c1;
        devindoLogo.color = _c3;

        Color _c2 = titleText.color;
        Color _c4 = pressText.color;

        _c2.a = 0;
        _c4.a = 0;

        titleText.color = _c2;
        pressText.color = _c4;

        DOVirtual.DelayedCall(.5f, () =>
        {
            switch (GameVariables.MainMenuState)
            {
                case MAIN_MENU_STATE.FIRST_CALL:
                    PlayRaionLogo();
                    break;
                case MAIN_MENU_STATE.SECOND_CALL:
                    PlayMainMenu();
                    break;
            }
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
            }).OnComplete(PlayMainMenu);
        });
    }

    private void PlayMainMenu()
    {
        Camera camera = Camera.main;

        Color titleColor = titleText.color;
        Color pressColor = pressText.color;

        Color _c2 = titleColor;
        Color _c4 = pressColor;

        camera.gameObject.transform.DOLocalMoveY(0f, 3f).OnComplete(() =>
        {
            DOVirtual.Float(0f, 1f, 1f, (a) =>
            {
                _c2.a = a;
                titleText.color = _c2;
            }).OnComplete(() =>
            {
                DOVirtual.Float(0f, 1f, 1f, (a) =>
                {
                    _c2.a = a;
                    pressText.color = _c2;
                }).OnComplete(LoadScene);
            });
        });
    }

    private void LoadScene()
    {
        TWAudioController.StopBGMPlayed("BGM_MAIN_MENU");
        SceneManager.LoadScene("Credit");
    }
}
