using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Button start;

    private void Awake()
    {
        start.onClick.AddListener(() => SceneManager.LoadScene(1));        
    }

}
