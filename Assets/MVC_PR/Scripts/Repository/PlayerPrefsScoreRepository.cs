public class PlayerPrefsScoreRepository : IScoreRepository
{
    private const string Key = "score:value";

    public int Load() => UnityEngine.PlayerPrefs.GetInt(Key, 0);

    public void Save(int value)
    {
        UnityEngine.PlayerPrefs.SetInt(Key, value);
        UnityEngine.PlayerPrefs.Save();
    }
}