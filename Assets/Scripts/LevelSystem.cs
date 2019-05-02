using UnityEngine;
public class LevelSystem : MonoBehaviour
{
    [SerializeField]
    int Level = 1;
    [SerializeField]
    int CurrentXP = 0;
    [SerializeField]
    int NextLevelXP = 100;
    [SerializeField]
    float NextXPMultiplier = 1.3f;

    public delegate void LevelUpDelegate(int newLevel);
    public LevelUpDelegate LevelUpCallback = delegate{};

    void AddXP(int xp)
    {
        int myXp = CurrentXP + xp;

        bool hasLevelUp = false;
        while (myXp > NextLevelXP)
        {
            NextLevelXP = (int)Mathf.Floor(NextLevelXP * NextXPMultiplier);
            ++Level;
            hasLevelUp = true;
        }

        CurrentXP = xp;

        if (hasLevelUp)
        {
            LevelUP();
        }
    }

    private void LevelUP()
    {
        if (LevelUpCallback != null)
        {
            LevelUpCallback(Level);
        }
    }

    public void SetLevel(int level)
    {
        int dif = Level - level;
        Level = level;
        NextLevelXP = (int)Mathf.Floor(NextLevelXP * NextXPMultiplier * dif);
        CurrentXP = (int)Mathf.Floor(CurrentXP * NextXPMultiplier * dif);
        LevelUP();
    }
}