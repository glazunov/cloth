using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using UnityEngine.SceneManagement;

public enum GameStates
{
    Playing,
    GameOver
}

public class GameController: IDisposable
{
    IMeshCreatable _meshCreator;
    PlanePiece.Factory _planePieceFactory;
    GameStates _state = GameStates.Playing;

    SignalBus _signalBus;

    [Inject]
    GameController(SignalBus signalBus, PlanePiece.Factory planePieceFactory, IMeshCreatable meshCreatable)
	{
        _signalBus = signalBus;
        _planePieceFactory = planePieceFactory;
        _meshCreator = meshCreatable;
        Init();

    }    

    public GameStates State {
        get { return _state; }
    }

	public void Dispose()
	{
        _signalBus.Unsubscribe<FinishedPlayerSignal>(OnPlayerFinished);
    }

    public void Init()
	{
        _signalBus.Subscribe<FinishedPlayerSignal>(OnPlayerFinished);
        _state = GameStates.Playing;

        List<PlanePiece> pieces = new List<PlanePiece>();
        Debug.Log(_meshCreator.Meshes.Keys);
        foreach (var item in _meshCreator.Meshes.Keys) {
            var piece = _planePieceFactory.Create(item, _meshCreator.Meshes[item]);
            pieces.Add(piece);
        }
    }

    void OnPlayerFinished()
	{
        _state = GameStates.GameOver;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
	
}