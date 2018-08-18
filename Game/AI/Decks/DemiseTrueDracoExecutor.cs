using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    [Deck("DemiseTrueDraco", "AI_DemiseTrueDraco", "Normal")]
    public class DemiseTrueDracoExecutor : DefaultExecutor
    {
        public class CardId
        {            
            public const int TheTrueDracombatant = 57761191;
            public const int TheTrueDracofighter = 58984738;
            public const int TheTrueDracocavalry = 94982447;
            public const int TheTrueDracowarrior = 22499034;
            public const int TheTrueDracocaster = 95004025;
            public const int InspectorBoarder = 15397015;
            public const int MaxxC = 23434538;

            public const int CardOfDemise = 59750328;
            public const int PotOfDuality = 98645731;
            public const int Scapegoat = 73915051;
            public const int TheMonarchsStormfort = 79844764;
            public const int TrueDracoHeritage = 49430782;
            public const int DisciplesOfTheTrueDracophoenix = 75425320;

            public const int WakingTheDragon = 10813327;
            public const int WaterfallOfDragonSouls = 23068051;
            public const int VanityEmptiness = 5851097;
            public const int TrueKingReturn = 35125879;
            public const int TrueDracoApocalypse = 61529473;
            public const int ImperialOrder = 61740673;
            public const int PhantomKnightSword = 61936647;

            public const int NaturiaExterio = 99916754;
            public const int BloomDivaTheMelodiousChoir = 84988419;
            public const int SuperheavySamuraiSteamTrainKing = 17775525;
            public const int CrystalWingSynchroDragon = 50954680;
            public const int RaidraptorUltimateFalcon = 86221741;
            public const int BorreloadDragon = 31833038;
            public const int BorrelswordDragon = 85289965;
            public const int TheWorldChaliceWarrior = 30194529;
            public const int KnightmarePhoenix = 2857636;
            public const int KnightmareCerberus = 75452921;
            public const int MissusRadiant = 3987233;
            public const int Linkuriboh = 41999284;
        }

        public DemiseTrueDracoExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            //counter
            AddExecutor(ExecutorType.ToBattlePhase, ToBattlePhaseeff);           
            AddExecutor(ExecutorType.Activate, _CardId.GhostBelle, DefaultGhostBelle);
            AddExecutor(ExecutorType.Activate, _CardId.CalledByTheGrave, DefaultCalledByTheGrave);
            AddExecutor(ExecutorType.Activate, _CardId.EffectVeiler, DefaultEffectVeiler);
            AddExecutor(ExecutorType.Activate, _CardId.InfiniteImpermanence, DefaultInfiniteImpermanence);
            AddExecutor(ExecutorType.Activate, _CardId.AshBlossom, DefaultAshBlossomAndJoyousSpring);
            AddExecutor(ExecutorType.Activate, _CardId.GhostOgreAndSnowRabbit, DefaultGhostOgreAndSnowRabbit);

        }

        private bool ToBattlePhaseeff()
        {
            if (Enemy.GetMonsterCount() == 0)
            {
                if (AI.Utils.GetTotalAttackingMonsterAttack(0) >= Enemy.LifePoints)
                {
                    AI.ManualPhaseChange = true;
                    return true;
                }
            }
            return false;
        }

    }
}