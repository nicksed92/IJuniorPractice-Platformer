using TMPro;
using UnityEngine;

public class UserStatsView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _crystalsCount;

    private int _currentCount = 0;

    private void Awake()
    {
        Player.Collected.AddListener(OnCollected);
    }

    private void OnCollected(int count)
    {
        _currentCount += count;
        _crystalsCount.text = _currentCount.ToString();
    }
}
