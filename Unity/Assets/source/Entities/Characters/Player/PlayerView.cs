﻿using UnityEngine;
using System.Collections;

public class PlayerView : MonoBehaviour
{

    private GameObject _playerHead;
    private GameObject _playerLegs;

    public GameObject PlayerHead { get { return _playerHead; } }
    public GameObject PlayerLegs { get { return _playerLegs; } }

    public void Deactivate()
    {
        //_playerHead.renderer.enabled = false;
        //_playerLegs.renderer.enabled = false;
    }
    public void Activate()
    {
        //_playerHead.renderer.enabled = true;
        //_playerLegs.renderer.enabled = true;
    }


    void Awake()
    {
        if (_playerHead == null)
        {
            _playerHead = new GameObject("PlayerHead");
            _playerHead.transform.parent = transform;
            _playerHead.transform.localPosition = (Vector2.up / 2);
        }
        if (_playerLegs == null)
        {
            _playerLegs = new GameObject("PlayerLegs");
            _playerLegs.transform.parent = transform;
            _playerLegs.transform.localPosition = Vector3.zero;
        }
    }

}
