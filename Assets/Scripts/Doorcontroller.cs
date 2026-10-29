using UnityEngine;
using UnityEngine.SceneManagement;

public class Doorcontroller : MonoBehaviour
{

    public int DoorID;
    public string SceneLoad;
    public int DestinationDoorID;
    public bool spawnLeftSide = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.targetDoorID = DestinationDoorID;

            SceneManager.LoadScene(SceneLoad);
        }
    }

}

