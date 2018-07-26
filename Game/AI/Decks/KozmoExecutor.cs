using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{
    [Deck("Kozmo", "AI_Kozmo", "Normal")]
    public class KozmoExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int KozmoDarkEclipser = 64063868;
            public const int KozmoDarkDestroyer = 55885348;
            public const int KozmoForerunner = 20849090;
            public const int KozmoSliprider = 94454495;
            public const int KozmollDarkLady = 12408276;
            public const int KozmollWichedwitch = 93302695;
            public const int KozmoSoartroopers = 31061682;
            public const int AshBlossom = 14558127;
            public const int Rabbit = 59438930;
            public const int KozmoStrawman = 56907986;
            public const int MaxxC = 23434538;
            public const int GlowUpBulb = 67441435;
            public const int KozmoTincan = 64280356;
            public const int EaterOfMillions = 97268402;
            public const int EffectVeiler = 63845230;

            public const int AllureOfDarkness = 1475311;
            public const int HarpieFeatherDuster = 18144506;
            public const int Reasoning = 58577036;
            public const int Terraforming = 73628505;
            public const int MonsterReborn = 83764718;
            public const int CalledByTheGrave = 24224830;
            public const int EmergencyTeleport = 67723438;
            public const int Kozmotown = 67237709;
            public const int CallOfTheHaunted = 97077563;

            public const int TGWonderMagician = 98558751;
            public const int CrystronNeedlefiber = 50588353;
            public const int BorreloadDragon = 31833038;
            public const int BirrelswordDragon = 85289965;
            public const int Linkuriboh = 41999284;
            
            public const int KnightmareGryphon = 65330383;

        }

        public KozmoExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            //counter
            AddExecutor(ExecutorType.Activate, CardId.EffectVeiler, DefaultEffectVeiler);
            AddExecutor(ExecutorType.Activate, CardId.AshBlossom, DefaultAshBlossomAndJoyousSpring);
            AddExecutor(ExecutorType.Activate, CardId.MaxxC, MaxxCeff);            
            AddExecutor(ExecutorType.Activate, CardId.CalledByTheGrave, DefaultCalledByTheGrave);
            AddExecutor(ExecutorType.Activate, CardId.Rabbit, DefaultGhostOgreAndSnowRabbit);
            //first
            AddExecutor(ExecutorType.Activate, CardId.HarpieFeatherDuster, DefaultHarpiesFeatherDusterFirst);
            AddExecutor(ExecutorType.Activate, CardId.Terraforming);
            AddExecutor(ExecutorType.Activate, CardId.Reasoning);
            //chain
            AddExecutor(ExecutorType.Activate, CardId.KozmoDarkEclipser, KozmoDarkEclipsereff);
            AddExecutor(ExecutorType.Activate, CardId.KozmoDarkDestroyer, KozmoDarkDestroyereff);
            AddExecutor(ExecutorType.Activate, CardId.KozmoForerunner, KozmoForerunnereff);
            AddExecutor(ExecutorType.Activate, CardId.KozmoSliprider, KozmoSlipridereff);
            //summon
            AddExecutor(ExecutorType.Summon, CardId.KozmoTincan, KozmoTincansummon);
            AddExecutor(ExecutorType.Activate, CardId.EmergencyTeleport, EmergencyTeleporteff);
            
            //sp
            AddExecutor(ExecutorType.SpSummon, CardId.EaterOfMillions, EaterOfMillionssp);
            AddExecutor(ExecutorType.Activate, CardId.EaterOfMillions, EaterOfMillionseff);

            AddExecutor(ExecutorType.Repos, MonsterRepos);
        }

        bool EmergencyTeleport_used = false;
        public override void OnNewTurn()
        {
            EmergencyTeleport_used = false;
            base.OnNewTurn();
        }
        private bool MaxxCeff()
        {
            return Duel.Player == 1;
        }

        private bool KozmoDarkEclipsereff()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                AI.SelectCard(new[] {CardId.KozmoDarkDestroyer, CardId.KozmoForerunner, CardId.KozmollDarkLady, CardId.KozmoSliprider });
                return true;
            }
            if (Card.Location == CardLocation.Grave)
            {
                AI.SelectCard(new[] { CardId.KozmoDarkDestroyer, CardId.KozmoForerunner, CardId.KozmollDarkLady, CardId.KozmoSliprider });
                return true;
            }
            return false;
        }
        private bool KozmoDarkDestroyereff()
        {
            if(Card.Location==CardLocation.MonsterZone)
            {
                if(Enemy.GetMonsterCount()>0)
                {
                    AI.SelectCard(AI.Utils.GetBestEnemyMonster(false, true));
                    return true;
                }
            }
            if(Card.Location==CardLocation.Grave)
            {                
                AI.SelectCard(new[] {CardId.KozmoForerunner,CardId.KozmollDarkLady,CardId.KozmoSliprider});
                if (Enemy.RemainAttackerCount == 0 && Bot.GetRemainingCount(CardId.KozmoTincan, 3) > 2)
                    AI.SelectCard(CardId.KozmoTincan);
                return true;
            }
            return false;
        }

        private bool KozmoForerunnereff()
        {
            AI.SelectCard(new []{ CardId.KozmollDarkLady, CardId.KozmoSliprider });
            if (Enemy.RemainAttackerCount == 0 && Bot.GetRemainingCount(CardId.KozmoTincan, 3) > 2 && Duel.Phase == DuelPhase.BattleStart)
                AI.SelectCard(CardId.KozmoTincan);
            return true;
        }

        private bool KozmoSlipridereff()
        {
            if (Card.Location == CardLocation.MonsterZone)
            {
                if (Enemy.GetSpellCount() > 0)
                {
                    AI.SelectCard(AI.Utils.GetBestEnemySpell());
                    return true;
                }
            }
            if(Card.Location==CardLocation.Grave)
            {
                AI.SelectCard(new[] { CardId.KozmollWichedwitch });
                if (Enemy.RemainAttackerCount == 0 && Bot.GetRemainingCount(CardId.KozmoTincan, 3) > 2 && Duel.Phase==DuelPhase.BattleStart)
                    AI.SelectCard(CardId.KozmoTincan);
            }
            return false;
        }
        private bool KozmoTincansummon()
        {
            return true;
        }
        private bool EmergencyTeleporteff()
        {
            if (Bot.HasInMonstersZone(CardId.KozmoTincan)) return false;
            if (EmergencyTeleport_used && Bot.HasInMonstersZone(CardId.KozmoTincan))
                return false;
            if(Bot.GetRemainingCount(CardId.KozmoTincan,3)>0)
            {
                EmergencyTeleport_used = true;
                AI.SelectCard(CardId.KozmoTincan);
                return true;
            }            
            return false;
        }

        private bool EaterOfMillionssp()
        {
            if (Bot.MonsterZone[0] == null)
                AI.SelectPlace(Zones.z0);
            else
                AI.SelectPlace(Zones.z4);
            if (Enemy.HasInMonstersZone(CardId.KnightmareGryphon, true)) return false;            
            if (AI.Utils.GetProblematicEnemyMonster() == null && Bot.ExtraDeck.Count < 5) return false;
            if (Bot.GetMonstersInMainZone().Count >= 5) return false;
            if (AI.Utils.IsTurn1OrMain2()) return false;
            AI.SelectPosition(CardPosition.FaceUpAttack);
            IList<ClientCard> targets = new List<ClientCard>();
            foreach (ClientCard e_c in Bot.ExtraDeck)
            {
                targets.Add(e_c);
                if (targets.Count >= 5)
                {
                    AI.SelectCard(targets);
                    /*AI.SelectCard(new[] {
                        CardId.BingirsuTheWorldChaliceWarrior,
                        CardId.TopologicTrisbaena,
                        CardId.KnightmareCerberus,
                        CardId.KnightmarePhoenix,
                        CardId.KnightmareUnicorn,
                        CardId.BrandishMaidenKagari,
                        CardId.HeavymetalfoesElectrumite,
                        CardId.CrystronNeedlefiber,
                        CardId.FirewallDragon,
                        CardId.BirrelswordDragon,
                        CardId.RaidraptorUltimateFalcon,
                    });*/
                    AI.SelectPlace(Zones.z4 | Zones.z0);
                    return true;
                }
            }
            Logger.DebugWriteLine("*** Eater use up the extra deck.");
            foreach (ClientCard s_c in Bot.GetSpells())
            {
                targets.Add(s_c);
                if (targets.Count >= 5)
                {
                    AI.SelectCard(targets);
                    return true;
                }
            }
            return false;
        }
        private bool EaterOfMillionseff()
        {
            if (Enemy.BattlingMonster.HasPosition(CardPosition.Attack) && (Bot.BattlingMonster.Attack - Enemy.BattlingMonster.GetDefensePower() >= Enemy.LifePoints)) return false;
            return true;
        }
        public override bool OnPreBattleBetween(ClientCard attacker, ClientCard defender)
        {
            
            return base.OnPreBattleBetween(attacker, defender);
        }
        public override ClientCard OnSelectAttacker(IList<ClientCard> attackers, IList<ClientCard> defenders)
        {
            for (int i = 0; i < attackers.Count; ++i)
            {
                ClientCard attacker = attackers[i];
                if (attacker.Id == CardId.BirrelswordDragon || attacker.Id == CardId.EaterOfMillions) return attacker;
            }
            return null;
        }
        private bool MonsterRepos()
        {
            if (Card.Id == CardId.EaterOfMillions && Card.IsAttack()) return false;
            return DefaultMonsterRepos();
        }
        public override bool OnSelectHand()
        {
            return true;
        }

    }
}