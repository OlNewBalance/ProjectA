using System;
using System.Collections.Generic;

namespace Sourceг
{
    public static class G
    {
        // Player
        private static int _currentLevel;

        public static int CurrentLevel
        {
            get => _currentLevel;
            set { 
                _currentLevel = value; 
                OnLevelChanged?.Invoke(_currentLevel); 
            }
        }
        public static Action<int> OnLevelChanged;
        private static int _currentExp;

        public static int CurrentExp
        {
            get => _currentExp;
            set {
                _currentExp = value;
                if (LevelMap.ContainsKey(_currentLevel + 1) && LevelMap[_currentLevel + 1] < _currentExp)
                {
                    ChangeLevel(_currentLevel + 1);
                }
                OnExpChanged?.Invoke(value);
            }
        }
        public static Action<int> OnExpChanged;

        public static int PlayerDamage { get; set; }
        private static Dictionary<int, int> _playerDamageByLevel = new Dictionary<int, int>();

        public static Dictionary<int, int> LevelMap { get; private set; } = new Dictionary<int, int>();
        
        //Enemies
        public static int EnemyHp { get; set; }
        private static  Dictionary<int, int> _enemyHpByLevel = new Dictionary<int, int>();
        public static int EnemyMoveSpeed { get; set; }
        private static  Dictionary<int, int> _enemyMoveSpeedByLevel =  new Dictionary<int, int>();
        public static int EnemyMoveMaxSpeed { get; set; }
        private static  Dictionary<int, int> _enemyMoveMaxSpeedByLevel = new Dictionary<int, int>();
        public static int EnemyCorvetteDamage { get; set; }
        private static  Dictionary<int, int> _enemyCorvetteDamageByLevel = new Dictionary<int, int>();
        public static int CurrentCoinExpValue { get; set; }
        private static  Dictionary<int, int> _currentCoinExpByLevel = new Dictionary<int, int>();


        public static GInit DefaultInit = new GInit(
                level: 1,
                exp: 0,
                levelMap: new Dictionary<int, int>()
                {
                    {1, 0},
                    {2, 10},
                    {3, 1000}
                },
                playerDamageByLevel: new Dictionary<int, int>()
                {
                    {1, 1},
                    {2, 5},
                    {3, 10}
                },
                enemyCorvetteHpByLevel:  new Dictionary<int, int>()
                {
                    {1, 2},
                    {2, 2},
                    {3, 2}
                },
                enemyMoveSpeedByLevel: new Dictionary<int, int>()
                {
                    {1, 10},
                    {2, 15},
                    {3, 15}
                },
                enemyMoveMaxSpeedByLevel:new Dictionary<int, int>()
                {
                    {1, 20},
                    {2, 25},
                    {3, 25}
                },
                enemyCorvetteDamageByLevel:  new Dictionary<int, int>()
                {
                    {1, 1},
                    {2, 5},
                    {3, 10}
                },
                currentCoinExpByLevel: new Dictionary<int, int>()
                {
                    {1, 10},
                    {2, 20},
                    {3, 30}
                }
            );

        public static void InitG(GInit gInit)
        {
            LevelMap = gInit.LevelMap;
            CurrentLevel = gInit.CurrentLevel;
            CurrentExp = gInit.CurrentExp;
            _playerDamageByLevel = gInit.PlayerDamageByLevel;
            _enemyCorvetteDamageByLevel = gInit.EnemyCorvetteDamageByLevel;
            _enemyHpByLevel = gInit.EnemyCorvetteHpByLevel;
            _enemyMoveSpeedByLevel = gInit.EnemyMoveSpeedByLevel;
            _enemyMoveMaxSpeedByLevel = gInit.EnemyMoveMaxSpeedByLevel;
            _currentCoinExpByLevel = gInit.CurrentCoinExpByLevel;
            ChangeLevel(CurrentLevel);
        }

        private static void ChangeLevel(int level)
        {
            CurrentLevel = level;
            PlayerDamage = _playerDamageByLevel[_currentLevel];
            EnemyHp = _enemyHpByLevel[_currentLevel];
            EnemyMoveSpeed = _enemyMoveSpeedByLevel[_currentLevel];
            EnemyMoveMaxSpeed = _enemyMoveMaxSpeedByLevel[_currentLevel];
            EnemyCorvetteDamage = _enemyCorvetteDamageByLevel[_currentLevel];
            CurrentCoinExpValue = _currentCoinExpByLevel[_currentLevel];
        }
    }

    public struct GInit
    {
        public  GInit(
            int level, 
            int exp,
            Dictionary<int, int> levelMap,
            Dictionary<int, int> playerDamageByLevel,
            Dictionary<int, int> enemyCorvetteHpByLevel,
            Dictionary<int, int> enemyMoveSpeedByLevel,
            Dictionary<int, int> enemyCorvetteDamageByLevel,
            Dictionary<int, int> currentCoinExpByLevel,
            Dictionary<int, int> enemyMoveMaxSpeedByLevel)
        {
            CurrentLevel = level;
            CurrentExp = exp;
            LevelMap = levelMap;
            PlayerDamageByLevel = playerDamageByLevel;
            EnemyCorvetteHpByLevel = enemyCorvetteHpByLevel;
            EnemyMoveSpeedByLevel = enemyMoveSpeedByLevel;
            EnemyCorvetteDamageByLevel = enemyCorvetteDamageByLevel;
            CurrentCoinExpByLevel = currentCoinExpByLevel;
            EnemyMoveMaxSpeedByLevel = enemyMoveMaxSpeedByLevel;
        }

        public readonly int CurrentLevel;
        public readonly int CurrentExp;
        public readonly Dictionary<int, int> LevelMap;
        public Dictionary<int, int> PlayerDamageByLevel { get; set; }
        public Dictionary<int, int> EnemyMoveMaxSpeedByLevel { get; set; }

        public Dictionary<int, int> EnemyCorvetteHpByLevel;
        public Dictionary<int, int> EnemyMoveSpeedByLevel;
        public Dictionary<int, int> EnemyCorvetteDamageByLevel;
        public Dictionary<int, int> CurrentCoinExpByLevel;
        
    }
}