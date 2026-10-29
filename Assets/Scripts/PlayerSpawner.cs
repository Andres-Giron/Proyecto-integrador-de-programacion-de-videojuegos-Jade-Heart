using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{

    private static PlayerSpawner Instance;

    void Awake()
    {
        // Evita que existan múltiples jugadores duplicados al cambiar de escena
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Hace que el objeto del Jugador persista
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // Nos desuscribimos cuando se desactiva
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Este método se ejecuta AUTOMÁTICAMENTE cada vez que una escena termina de cargar
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Damos una pequeña pausa de un frame para asegurarnos de que las puertas ya existen en la escena
        Invoke("MovePlayerToDoor", 0.05f);
    }

    void MovePlayerToDoor()
    {
        Doorcontroller[] doors = FindObjectsByType<Doorcontroller>(FindObjectsSortMode.None);

        foreach (Doorcontroller door in doors)
        {

            if (door.DoorID == GameManager.Instance.targetDoorID)
            {
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.linearVelocity = Vector2.zero; // Detiene cualquier movimiento previo
                }

                float offsetX = door.spawnLeftSide ? -3f : 3f;

                transform.position = door.transform.position + new Vector3(offsetX, 0.2f, 0f);
                break;
            }
        }
    }

}
