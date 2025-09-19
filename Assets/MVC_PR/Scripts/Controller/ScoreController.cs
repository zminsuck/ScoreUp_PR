using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [Header("View")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Button addButton;

    private ScoreModel model;
    private IScoreRepository repo;
    private const int AddAmount = 10;

    private void Awake()
    {
        repo  = new PlayerPrefsScoreRepository();
        model = new ScoreModel(repo.Load());
        
        model.OnChanged += UpdateView;
        addButton.onClick.AddListener(OnClickAdd);
        UpdateView(model.Current);
    }

    private void OnDestroy()
    {
        model.OnChanged -= UpdateView;
        addButton.onClick.RemoveListener(OnClickAdd);
    }

    private void OnClickAdd()
    {
        model.Add(AddAmount);
        repo.Save(model.Current);
    }

    private void UpdateView(int value)
    {
        if (scoreText != null) scoreText.text = value.ToString();
    }
}