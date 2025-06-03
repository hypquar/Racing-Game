using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public UnityEvent OnAlarm;
    public UnityEvent OnTimerCancel;

    [Header("UI Elements")]
    [SerializeField] private Image fillImage;
    [SerializeField] private Button startButton;

    [Header("Settings")]
    [SerializeField] private float loadDuration = 10f;

    private float timer = 0f;
    private bool isLoading = false;

    private void Start()
    {
        // Подключаем метод к кнопке
        if (startButton != null)
            startButton.onClick.AddListener(StartLoading);

        // Сброс
        fillImage.fillAmount = 0f;
    }

    public void StartLoading()
    {
        timer = 0f;
        isLoading = true;
        fillImage.fillAmount = 0f;
    }

    public void CancelTimer()
    {
        timer = 0f;
        isLoading = false;
        fillImage.fillAmount = 0f;
        OnTimerCancel.Invoke();
    }

    private void Update()
    {
        if (!isLoading) return;

        timer += Time.deltaTime;
        float progress = Mathf.Clamp01(timer / loadDuration);
        fillImage.fillAmount = progress;

        if (progress >= 1f)
        {
            isLoading = false;
            Debug.Log("Загрузка завершена!");
            OnAlarm.Invoke();
            // Тут можно вызывать событие, менять сцену и т.д.
        }
    }
}

