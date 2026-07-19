using System;
using System.Collections.Generic;
using Source.StateMachine;

namespace Source
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
        public static Dictionary<GameScene, int> FastTravelLVL { get; set; }
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

        //FastTravel

        public static Dictionary<int, AlterHole> GloryHoles { get; set; }
        public static float AttractionForce { get; set; }

        private static  Dictionary<int, int> _enemyCorvetteDamageByLevel = new Dictionary<int, int>();
        public static int CurrentCoinExpValue { get; set; }
        private static  Dictionary<int, int> _currentCoinExpByLevel = new Dictionary<int, int>();
        
        private static int MaxLevel { get; set; }
        
        public static GInit DefaultInit = new GInit(
                level: 1,
                exp: 0,
                maxLevel: 5,
                levelMap: new Dictionary<int, int>()
                {
                    {1, 0},
                    {2, 10},
                    {3, 200},
                    {4, 400},
                    {5, 700}
                },
                playerDamageByLevel: new Dictionary<int, int>()
                {
                    {1, 12},
                    {2, 24},
                    {3, 36},
                    {4, 48},
                    {5, 48}
                },
                enemyCorvetteHpByLevel:  new Dictionary<int, int>()
                {
                    {1, 100},
                    {2, 105},
                    {3, 110},
                    {4, 115},
                    {5, 115}
                },
                enemyMoveSpeedByLevel: new Dictionary<int, int>()
                {
                    {1, 10},
                    {2, 15},
                    {3, 30},
                    {4, 50},
                    {5, 50}
                },
                enemyMoveMaxSpeedByLevel:new Dictionary<int, int>()
                {
                    {1, 20},
                    {2, 35},
                    {3, 50},
                    {4, 65},
                    {5, 65}
                },
                enemyCorvetteDamageByLevel:  new Dictionary<int, int>()
                {
                    {1, 15},
                    {2, 30},
                    {3, 45},
                    {4, 60},
                    {5, 60}
                },
                currentCoinExpByLevel: new Dictionary<int, int>()
                {
                    {1, 10},
                    {2, 20},
                    {3, 30},
                    {4, 40},
                    {5, 30}
                },
                fastTravelLevel: new Dictionary<GameScene, int>()
                {
                    { GameScene.Earth, 1},
                    {GameScene.Mars, 3},
                    { GameScene.Moon, 2}
                },
                attractionForce: 200f
            );

        public static void InitG(GInit gInit)
        {
            LevelMap = gInit.LevelMap;
            CurrentLevel = gInit.CurrentLevel;
            CurrentExp = gInit.CurrentExp;
            MaxLevel = gInit.MaxLevel;
            AttractionForce = gInit.AttractionForce;
            FastTravelLVL = gInit.FastTravelLevel;
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
            if (level >= MaxLevel)
            {
                Main.Instance.Victory();
            }
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
            int maxLevel,
            float attractionForce,
            Dictionary<int, int> levelMap,
            Dictionary<int, int> playerDamageByLevel,
            Dictionary<int, int> enemyCorvetteHpByLevel,
            Dictionary<int, int> enemyMoveSpeedByLevel,
            Dictionary<int, int> enemyCorvetteDamageByLevel,
            Dictionary<int, int> currentCoinExpByLevel,
            Dictionary<int, int> enemyMoveMaxSpeedByLevel,
            Dictionary<GameScene, int> fastTravelLevel)
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
            MaxLevel = maxLevel;
            FastTravelLevel = fastTravelLevel;
            AttractionForce =  attractionForce;
        }

        public readonly int CurrentLevel;
        public readonly int CurrentExp;
        public readonly Dictionary<int, int> LevelMap;
        public readonly int MaxLevel;
        public readonly float AttractionForce;
        public Dictionary<int, int> PlayerDamageByLevel { get; set; }
        public Dictionary<int, int> EnemyMoveMaxSpeedByLevel { get; set; }

        public Dictionary<int, int> EnemyCorvetteHpByLevel;
        public Dictionary<int, int> EnemyMoveSpeedByLevel;
        public Dictionary<int, int> EnemyCorvetteDamageByLevel;
        public Dictionary<int, int> CurrentCoinExpByLevel;
        public Dictionary<GameScene, int>  FastTravelLevel;
    }
}