using UnityEngine;

public class Crystal : MonoBehaviour, ICollectable
{
    [SerializeField] private int _collectCount = 1;

    public int Collect()
    {
        Destroy(gameObject);
        return _collectCount;
    }
}
