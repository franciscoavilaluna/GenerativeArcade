using UnityEngine;
using UnityEngine.InputSystem;

namespace GenerativeArcade.Core
{
    public enum GameState
    {
        MainMenu,
        PlayingMiniGame,
        BetweenGames,
        GameOver
    }

    public class GameManager : MonoBehaviour
    {
        public GameState currentState;

        [Header("Configuración de Tiempo")]
        public float miniGameDuration = 5.0f;
        private float timer;

        private void Start()
        {
            ChangeState(GameState.MainMenu);
        }

        private void Update()
        {
            switch (currentState)
            {
                case GameState.MainMenu:
                    if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
                    {
                        StartNextMiniGame();
                    }
                    break;

                case GameState.PlayingMiniGame:
                    timer -= Time.deltaTime;
                    Debug.Log("Tiempo restante: " + timer.ToString("F1") + "s");

                    if (timer <= 0)
                    {
                        OnMiniGameEnd();
                    }
                    break;

                case GameState.BetweenGames:
                    break;

                case GameState.GameOver:
                    break;
            }
        }

        public void ChangeState(GameState newState)
        {
            currentState = newState;
            Debug.Log("Estado cambiado a: " + newState);
        }

        public void StartNextMiniGame()
        {
            timer = miniGameDuration;
            ChangeState(GameState.PlayingMiniGame);
        }

        private void OnMiniGameEnd()
        {
            Debug.Log("¡Tiempo fuera! Minijuego finalizado.");
            ChangeState(GameState.BetweenGames);
        }
    }
}
