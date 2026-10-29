using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // Agrega esta línea para que el código reconozca la variable:
    public int targetDoorID;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
