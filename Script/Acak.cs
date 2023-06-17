using UnityEngine;
using UnityEngine.UI;

public class Acak : MonoBehaviour
{
    public Button button;
    public GameObject Map;

    private void Start()
    {
        button.onClick.AddListener(RepeatScript);
    }

    private void RepeatScript()
    {
        // Call the desired method or execute the script on the object to repeat
        Map.GetComponent<MazeGenerator>().AcakPeta();
    }
}
