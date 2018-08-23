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
            AddExecutor(ExecutorType.GoToBattlePhase, ToBattlePhaseeff);           
            AddExecutor(ExecutorType.Activate, _CardId.GhostBelle, DefaultGhostBelleAndHauntedMansion);
            AddExecutor(ExecutorType.Activate, _CardId.CalledByTheGrave, DefaultCalledByTheGrave);
            AddExecutor(ExecutorType.Activate, _CardId.EffectVeiler, DefaultEffectVeiler);
            AddExecutor(ExecutorType.Activate, _CardId.InfiniteImpermanence, DefaultInfiniteImpermanence);
            AddExecutor(ExecutorType.Activate, _CardId.AshBlossom, DefaultAshBlossomAndJoyousSpring);
            AddExecutor(ExecutorType.Activate, _CardId.GhostOgreAndSnowRabbit, DefaultGhostOgreAndSnowRabbit);

            //chain
            AddExecutor(ExecutorType.Activate, CardId.Scapegoat, DefaultScapegoat);
            AddExecutor(ExecutorType.Activate, CardId.TheTrueDracofighter, TheTrueDracofightereff);
            AddExecutor(ExecutorType.Activate, CardId.TheTrueDracocaster, TheTrueDracocastereff);
            AddExecutor(ExecutorType.Activate, CardId.TheTrueDracowarrior, TheTrueDracowarrioreff);
            AddExecutor(ExecutorType.Activate, CardId.TheTrueDracocavalry, TheTrueDracocavalryeff);

            //sp
            AddExecutor(ExecutorType.Activate, CardId.WakingTheDragon, WakingTheDragoneff);
            AddExecutor(ExecutorType.SpSummon, CardId.BorrelswordDragon, BorrelswordDragonsp);
            AddExecutor(ExecutorType.Activate, CardId.BorrelswordDragon, BorrelswordDragoneff);
            AddExecutor(ExecutorType.SpSummon, CardId.MissusRadiant, MissusRadiantsp);
            AddExecutor(ExecutorType.Activate, CardId.MissusRadiant, MissusRadianteff);
            AddExecutor(ExecutorType.SpSummon, CardId.Linkuriboh);
            AddExecutor(ExecutorType.Activate, CardId.Linkuriboh);
            //normal summon            
            AddExecutor(ExecutorType.Summon, CardId.InspectorBoarder, InspectorBoardersummon);
            AddExecutor(ExecutorType.Summon, CardId.TheTrueDracombatant, TheTrueDracombatantsummon);

            //spell set
            AddExecutor(ExecutorType.SpellSet, CardId.Scapegoat, NoSetAlreadyDone);
            AddExecutor(ExecutorType.SpellSet, CardId.ImperialOrder);
            AddExecutor(ExecutorType.SpellSet, CardId.VanityEmptiness);
            AddExecutor(ExecutorType.SpellSet, CardId.PhantomKnightSword);
            AddExecutor(ExecutorType.SpellSet, CardId.WaterfallOfDragonSouls, NoSetAlreadyDone);
            AddExecutor(ExecutorType.SpellSet, CardId.TheMonarchsStormfort, NoSetAlreadyDone);
            AddExecutor(ExecutorType.SpellSet, CardId.WakingTheDragon, NormalSpellSet);
            AddExecutor(ExecutorType.SpellSet, CardId.TrueDracoApocalypse);
            AddExecutor(ExecutorType.SpellSet, CardOfDemiseSet);
            AddExecutor(ExecutorType.Repos, MonsterRepos);
        }
        bool summon_used = false;
        bool CardOfDemiseeff_used = false;
        bool TheMonarchsStormforteff_used = false;
        public override void OnNewTurn()
        {
            summon_used = false;
            CardOfDemiseeff_used = false;
            TheMonarchsStormforteff_used = false;
            base.OnNewTurn();
        }

        private bool ToBattlePhaseeff()
        {
            if (Enemy.GetMonsterCount() == 0)
            {
                if (AI.Utils.GetTotalAttackingMonsterAttack(0) >= Enemy.LifePoints)
                {                   
                    return true;
                }
            }
            return false;
        }       

        private bool TheTrueDracofightereff()
        {
            AI.SelectCard(CardId.TrueKingReturn);
            AI.SelectOption(1);
            return true;
        }

        private bool TheTrueDracocastereff()
        {
            AI.SelectOption(1);
            return true;
        }

        private bool TheTrueDracowarrioreff()
        {
            AI.SelectCard(CardId.TheTrueDracofighter);
            AI.SelectOption(1);
            return true;
        }

        private bool TheTrueDracocavalryeff()
        {
            AI.SelectCard(new[] {
                CardId.TheTrueDracombatant,
                CardId.TheTrueDracocavalry,
                CardId.TheTrueDracowarrior,
                CardId.TheTrueDracocaster});
            return true;
        }

        private bool WakingTheDragoneff()
        {
            if(Enemy.HasInMonstersZone(CardId.BorrelswordDragon) && Bot.HasInExtra(CardId.BorreloadDragon))
            {
                AI.SelectCard(CardId.BorreloadDragon);
            }
            else if (Enemy.HasInMonstersZone(CardId.BorrelswordDragon) && Bot.HasInExtra(CardId.SuperheavySamuraiSteamTrainKing))
            {
                AI.SelectCard(CardId.SuperheavySamuraiSteamTrainKing);
                AI.SelectPosition(CardPosition.FaceUpDefence);
            }
            else 
            AI.SelectCard(new[]
            {
                CardId.RaidraptorUltimateFalcon,
                CardId.BorreloadDragon,
                CardId.BorrelswordDragon,
            });
            return true;
        }

        private bool BorrelswordDragonsp()
        {

            if (!Bot.HasInMonstersZone(CardId.MissusRadiant))
                return false;
            IList<ClientCard> material_list = new List<ClientCard>();
            foreach (ClientCard m in Bot.GetMonsters())
            {
                if (m.Id == CardId.MissusRadiant)
                {
                    material_list.Add(m);
                    break;
                }
            }
            foreach (ClientCard m in Bot.GetMonsters())
            {
                if (m.Id == CardId.Linkuriboh)
                {
                    material_list.Add(m);
                    if (material_list.Count == 3)
                        break;
                }
            }
            if (material_list.Count == 3)
            {
                AI.SelectMaterials(material_list);
                return true;
            }
            return false;
        }

        private bool BorrelswordDragoneff()
        {
            if (ActivateDescription == AI.Utils.GetStringId(CardId.BorrelswordDragon, 0))
            {
                if (AI.Utils.IsChainTarget(Card) && AI.Utils.GetBestEnemyMonster(true, true) != null)
                {
                    AI.SelectCard(AI.Utils.GetBestEnemyMonster(true, true));
                    return true;
                }
                if (Duel.Player == 1 && Bot.BattlingMonster == Card)
                {
                    AI.SelectCard(Enemy.BattlingMonster);
                    return true;
                }
                if (Duel.Player == 1 && Bot.BattlingMonster != null &&
                    (Enemy.BattlingMonster.Attack - Bot.BattlingMonster.Attack) >= Bot.LifePoints)
                {
                    AI.SelectCard(Enemy.BattlingMonster);
                    return true;
                }
                if (Duel.Player == 0 && Duel.Phase == DuelPhase.BattleStart)
                {
                    foreach (ClientCard check in Enemy.GetMonsters())
                    {
                        if (check.IsAttack() && !check.HasType(CardType.Link))
                        {
                            AI.SelectCard(check);
                            return true;
                        }
                    }
                }
                return false;
            }
            return true;
        }

        private bool MissusRadiantsp()
        {
            IList<ClientCard> material_list = new List<ClientCard>();
            foreach (ClientCard monster in Bot.GetMonsters())
            {
                if (monster.Level == 1)
                    material_list.Add(monster);
                if (material_list.Count == 2) break;
            }
            if (material_list.Count < 2) return false;
            if (Bot.HasInMonstersZone(CardId.MissusRadiant)) return false;
            AI.SelectMaterials(material_list);
            if ((Bot.MonsterZone[0] == null || Bot.MonsterZone[0].Level == 1) &&
                (Bot.MonsterZone[2] == null || Bot.MonsterZone[2].Level == 1) &&
                Bot.MonsterZone[5] == null)
                AI.SelectPlace(Zones.z5);
            else
                AI.SelectPlace(Zones.z6);
            return true;
        }

        private bool MissusRadianteff()
        {
            AI.SelectCard(new[]
           {
                CardId.MaxxC,
                CardId.MissusRadiant,
            });
            return true;
        }

        private bool Linkuribohsp()
        {
            foreach (ClientCard c in Bot.GetMonsters())
            {
                if (c.Level == 1)
                {
                    AI.SelectMaterials(c);
                    return true;
                }
            }
            return false;
        }

        private bool Linkuriboheff()
        {
            if (Duel.LastChainPlayer == 0 && AI.Utils.GetLastChainCard().Id == CardId.Linkuriboh) return false;
            return true;
        }

        private bool InspectorBoardersummon()
        {
            AI.SelectPlace(Zones.z1| Zones.z3);
            summon_used = true;
            return true;
        }

        private bool TheTrueDracombatantsummon()
        {
            return false;
        }
        private bool NoSetAlreadyDone()
        {
            if (Duel.Turn > 1 && Duel.Phase == DuelPhase.Main1 && Bot.HasAttackingMonster())
                return false;
            if (Bot.HasInSpellZone(Card.Id)) return false;
            return true;
        }

        private bool NormalSpellSet()
        {
            if (Duel.Turn > 1 && Duel.Phase == DuelPhase.Main1 && Bot.HasAttackingMonster())
                return false;
            return true;          
        }

        private bool CardOfDemiseSet()
        {
            if (Card.HasType(CardType.Field)) return false;
            if (CardOfDemiseeff_used) return true;
            if (Bot.HasInHandOrInSpellZone(CardId.CardOfDemise) && !CardOfDemiseeff_used)
            {
                int hand_spell_count = 0;
                foreach (ClientCard s in Bot.Hand)
                {
                    if (s.HasType(CardType.Trap) || s.HasType(CardType.Spell) && !s.HasType(CardType.Field))
                        hand_spell_count++;
                }
                int zone_count = 5 - Bot.GetSpellCountWithoutField();
                return zone_count - hand_spell_count >= 1;
            }           
            return false;
        }
        public override bool OnSelectHand()
        {
            return true;
        }

        private bool MonsterRepos()
        {            
            return DefaultMonsterRepos();
        }
    }
}