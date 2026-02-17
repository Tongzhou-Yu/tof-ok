using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;
using System.Collections.Generic;

public class SystemManager : MonoBehaviour
{
    public Button restart, delete;
    public Text txt;
    private List<GameObject> Container;
    private void Start()
    {
        Container = GetComponent<TofOkManager>().Container;
        restart.onClick.AddListener(Restart);
        delete.onClick.AddListener(Delete);
    }
    private void Update()
    {
        txt.text = Container.Count().ToString();
    }
    void Delete()
    {
        int count = Container.Count;
        Destroy(Container[count - 1]);
        Container.RemoveAt(count - 1);
    }
    void Restart()
    {
        foreach (GameObject brush in Container.ToArray())
        {
            Destroy(brush);
            Container.Remove(brush);
        }
        Container.Clear();
    }
}
