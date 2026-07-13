using System;

namespace Source
{
    public static class G
    {
        public static GInit DefaultInit =  new GInit(
            level: 1, 
            exp: 0);
        
        public static void InitG(GInit gInit)
        {
            CurrentLevel = gInit.CurrentLevel;
            CurrentExp = gInit.CurrentExp;
        }

        private static int _currentLevel;
        public static Action<int> OnLevelChanged;

        public static int CurrentLevel
        {
            get => _currentLevel;
            set { 
                _currentLevel = value; 
                OnLevelChanged?.Invoke(_currentLevel); 
            }
        }
        private static int _currentExp;

        public static Action<int> OnExpChanged;

        public static int CurrentExp
        {
            get => _currentExp;
            set {
                _currentExp = value;
                OnExpChanged?.Invoke(_currentExp);
            }
        }
    }

    public struct GInit
    {
        public  GInit(int level, int exp)
        {
            CurrentLevel = level;
            CurrentExp = exp;
        }
        
        public int CurrentLevel;
        public int CurrentExp;
    }
}