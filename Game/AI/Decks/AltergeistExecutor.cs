using YGOSharp.OCGWrapper.Enums;
using System.Collections.Generic;
using WindBot;
using WindBot.Game;
using WindBot.Game.AI;

namespace WindBot.Game.AI.Decks
{    
       [Deck("Altergeist", "AI_Altergeist", "Normal")]
    public class  AltergeistExecutor : DefaultExecutor
    {
        public class CardId
        {
            public const int AltergeistKunquery = 52927340;
            public const int AltergeistMarionetter = 53143898;
            public const int AltergeistMultifaker = 42790071;
            public const int Rabbit = 14558127;
            public const int AshBlossom = 59438930;
            public const int AltergeistSilquitous = 89538537;
            public const int MaxxC = 23434538;
            public const int AltergeistMeluseek = 25533642;

            public const int HarpieFeatherDuster = 18144506;
            public const int PotOfDesires = 35261759;
            public const int PotOfDuality = 98645731;
            public const int SecretVillageOfTheSpellcasters = 68462976;

            public const int InfiniteImpermanence = 10045474;
            public const int AltergeistMaterialization = 35146019;
            public const int AltergeistProtocol = 27541563;
            public const int PersonalSpoofing = 53936268;
            public const int AntiSpellFragrance = 58921041;
            public const int ImperialOrder = 61740673;
            public const int SolemnStrike = 40605147;
            public const int SolemnJudgment = 41420027;

            public const int CoralDragon = 42566602;
            public const int TGWonderMagician = 98558751;
            public const int BorreloadDragon = 31833038;
            public const int TheWorldChaliceWarrior = 30194529;
            public const int KnightmareUnicorn = 38342335;
            public const int AltergeistPrimebanshee = 93503294;
            public const int AltergeistHextia = 1508649;
            public const int CrystronNeedlefiber = 50588353;
            public const int Linkuriboh = 41999284;
            public const int RelinquishedAnima = 94259633;
            
        }
        
        public  AltergeistExecutor(GameAI ai, Duel duel)
            : base(ai, duel)
        {
            //counter
            AddExecutor(ExecutorType.ToBattlePhase, ToBattlePhaseeff);
            AddExecutor(ExecutorType.Activate, CardId.SolemnStrike);
            AddExecutor(ExecutorType.Activate, _CardId.GhostBelle, DefaultGhostBelle);
            AddExecutor(ExecutorType.Activate, _CardId.CalledByTheGrave, DefaultCalledByTheGrave);
            AddExecutor(ExecutorType.Activate, _CardId.EffectVeiler, DefaultEffectVeiler);
            AddExecutor(ExecutorType.Activate, _CardId.InfiniteImpermanence, DefaultInfiniteImpermanence);
            AddExecutor(ExecutorType.Activate, _CardId.AshBlossom, DefaultAshBlossomAndJoyousSpring);            
            AddExecutor(ExecutorType.Activate, _CardId.GhostOgreAndSnowRabbit, DefaultGhostOgreAndSnowRabbit);

            //chain
            AddExecutor(ExecutorType.Activate, CardId.AltergeistKunquery, AltergeistKunqueryeff);
            AddExecutor(ExecutorType.Activate, CardId.AltergeistMarionetter, AltergeistMarionettereff);
            AddExecutor(ExecutorType.Activate, CardId.AltergeistMultifaker, AltergeistMultifakereff);
            AddExecutor(ExecutorType.Activate, CardId.AltergeistMeluseek, AltergeistMeluseekeff);
            AddExecutor(ExecutorType.Activate, CardId.AltergeistSilquitous, AltergeistSilquitouseff);

            //first
            AddExecutor(ExecutorType.Activate, CardId.AntiSpellFragrance);
            AddExecutor(ExecutorType.Activate, _CardId.MaxxC, DefaultMaxxC);
            AddExecutor(ExecutorType.Activate, CardId.HarpieFeatherDuster, DefaultHarpiesFeatherDusterFirst);
            AddExecutor(ExecutorType.Activate, CardId.PotOfDesires, PotOfDesireseff);
            AddExecutor(ExecutorType.Activate, CardId.SecretVillageOfTheSpellcasters, SecretVillageOfTheSpellcasterseff);
            //summon
            AddExecutor(ExecutorType.Summon, CardId.AltergeistMeluseek, AltergeistMeluseeksummon);
            //set
            AddExecutor(ExecutorType.SpellSet, CardId.ImperialOrder, ImperialOrderset);
            AddExecutor(ExecutorType.SpellSet, CardId.SolemnJudgment);
            AddExecutor(ExecutorType.SpellSet, CardId.SolemnStrike, SolemnStrikeset);
            AddExecutor(ExecutorType.SpellSet, CardId.InfiniteImpermanence, InfiniteImpermanenceset);
            AddExecutor(ExecutorType.SpellSet, CardId.AntiSpellFragrance, AntiSpellFragranceset);
            AddExecutor(ExecutorType.SpellSet, CardId.AltergeistProtocol, AltergeistProtocolset);
            AddExecutor(ExecutorType.SpellSet, CardId.PersonalSpoofing, PersonalSpoofingset);
            AddExecutor(ExecutorType.SpellSet, CardId.AltergeistMaterialization, AltergeistMaterializationset);
            AddExecutor(ExecutorType.SpellSet, Spellset);
            AddExecutor(ExecutorType.Repos, DefaultMonsterRepos);
           
        }
        bool AltergeistMultifakereff_used = false;
        bool AltergeistMarionettereff_used = false;
        bool AltergeistSilquitouseff_used_1 = false;
        bool AltergeistSilquitouseff_used_2 = false;
        bool AltergeistMeluseekeff_used = false;
        bool summon_used = false;
        bool Meluseek_summon = false;
        bool Marionetter_summon = false;
        public override void OnNewTurn()
        {
            AltergeistMultifakereff_used = false;
            AltergeistMarionettereff_used = false;
            AltergeistSilquitouseff_used_1 = false;
            AltergeistSilquitouseff_used_2 = false;
            AltergeistMeluseekeff_used = false;
            Meluseek_summon = false;
            Marionetter_summon = false;
            summon_used = false;
            base.OnNewTurn();
        }

        private bool ToBattlePhaseeff()
        {
            if(!summon_used)
            {
                if(Bot.HasInHand(CardId.AltergeistMarionetter) && Bot.HasInHand(CardId.AltergeistMeluseek))
                {
                    if ((HasOneTrapSet() || HasTrapInHand()) && !Bot.HasInHand(CardId.AltergeistMultifaker))
                        Meluseek_summon = true;
                    else if (EnemyHasFloodgate())
                        Meluseek_summon = true;
                    else
                        Marionetter_summon = true;
                }
                else if(Bot.HasInHand(CardId.AltergeistMarionetter))
                {
                    Marionetter_summon = true;
                }
                else if(Bot.HasInHand(CardId.AltergeistMeluseek))
                {
                    Meluseek_summon = true;
                }
            }
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
        private bool AltergeistKunqueryeff()
        {
            AI.SelectPosition(CardPosition.FaceUpDefence);
            ClientCard target = null;
            foreach(ClientCard m in Enemy.GetMonsters())
            {
                if (m.IsMonsterDangerous() || m.IsMonsterInvincible())
                    target = m;
            }
            if(target==null)
            {
                target = AI.Utils.GetBestEnemyCard(true,true);
            }
            AI.SelectCard(target);
            return true;
        }

        private bool AltergeistMarionettereff()
        {
            if(ActivateDescription==-1)
            {
                if (Bot.HasInHandOrInSpellZone(CardId.AltergeistProtocol))
                    AI.SelectCard(CardId.AltergeistMaterialization);
                else
                    AI.SelectCard(CardId.AltergeistProtocol);
            }
            if(Bot.HasInGraveyard(CardId.AltergeistMultifaker) && !AltergeistMultifakereff_used)
            {
                AI.SelectCard(CardId.AltergeistMultifaker);
                AltergeistMarionettereff_used = true;
                return true;                
            }
            if(Enemy.GetFieldCount()>0 && Bot.HasInGraveyard(CardId.AltergeistMeluseek))
            {
                AI.SelectCard(CardId.AltergeistMeluseek);
                AltergeistMarionettereff_used = true;
                return true;
            }
            return false;
        }

        private bool AltergeistMultifakereff()
        {
            if(Duel.Player==1)
            {
                AI.SelectPosition(CardPosition.FaceUpDefence);
                if (!Bot.HasInMonstersZone(CardId.AltergeistSilquitous) && Bot.GetRemainingCount(CardId.AltergeistSilquitous,2)>0)
                    AI.SelectCard(CardId.AltergeistSilquitous);
                else
                    AI.SelectCard(new[] { CardId.AltergeistMeluseek, CardId.AltergeistKunquery });
            }
            if(Duel.Player==0)
            {
                if (Enemy.GetFieldCount() > 0 && Bot.GetRemainingCount(CardId.AltergeistMeluseek,3)>0)
                    AI.SelectCard(CardId.AltergeistMeluseek);
                else
                    AI.SelectCard(new[] { CardId.AltergeistSilquitous, CardId.AltergeistKunquery });
            }
            AltergeistMultifakereff_used = true;
            return true;            
        }

        private bool AltergeistMeluseekeff()
        {
            if (Card.Location == CardLocation.Grave)
            {
                AltergeistMeluseekeff_used = true;
                if(!Bot.HasInHand(CardId.AltergeistMultifaker) && 
                    Bot.GetRemainingCount(CardId.AltergeistMultifaker,3)>0)
                {
                    AI.SelectCard(CardId.AltergeistMultifaker);
                    return true;
                }
                AI.SelectCard(new[] { CardId.AltergeistMarionetter, CardId.AltergeistKunquery });
                return true;
            }
            AI.SelectCard(AI.Utils.GetBestEnemyCard(false, true));
            return true;
        }

        private bool AltergeistSilquitouseff()
        {
            if(Card.Location==CardLocation.MonsterZone)
            {
                if (AI.Utils.ChainContainsCard(CardId.AltergeistMaterialization) ||(Enemy.BattlingMonster != null && Duel.Player == 1))
                {
                    AltergeistSilquitouseff_used_1 = true;
                    AI.SelectCard(AI.Utils.GetBestEnemyCard());
                    AI.SelectCard(new[] { CardId.AltergeistMultifaker, CardId.AltergeistKunquery, CardId.AltergeistMarionetter });
                    return true;
                }                
            }
            else
            {
                if(Bot.HasInHand(CardId.AltergeistMultifaker) && !Bot.HasInHandOrInSpellZone(CardId.AltergeistProtocol))
                {
                    AI.SelectCard(CardId.AltergeistProtocol);
                    AltergeistSilquitouseff_used_2 = true;
                    return true;
                }
                else
                {
                    AI.SelectCard(CardId.AltergeistMaterialization);
                    AltergeistSilquitouseff_used_2 = true;
                    return true;
                }
            }
            return false;
        }

        private bool PotOfDesireseff()
        {
            return Bot.Deck.Count >= 15;
        }

        private bool SecretVillageOfTheSpellcasterseff()
        {
            if(Card.Location==CardLocation.Hand)
            {
                if (Bot.HasInSpellZone(CardId.SecretVillageOfTheSpellcasters))
                    return true;
            }
            if (Card.IsFacedown())
                return true;
            return false;
        }

        private bool AltergeistMeluseeksummon()
        {
            if (Meluseek_summon) return true;
            return false;
        }
        private bool ImperialOrderset()
        {
            if (Duel.Turn > 1 && Duel.Phase == DuelPhase.Main1 && Bot.HasAttackingMonster())
                return false;
            return true;
        }
        private bool SolemnStrikeset()
        {
            if (Duel.Turn > 1 && Duel.Phase == DuelPhase.Main1 && Bot.HasAttackingMonster())
                return false;
            return true;
        }

        private bool InfiniteImpermanenceset()
        {
            if (Duel.Turn > 1 && Duel.Phase == DuelPhase.Main1 && Bot.HasAttackingMonster())
                return false;
            return !Bot.IsFieldEmpty();
        }
        private bool AntiSpellFragranceset()
        {
            if (Duel.Turn > 1 && Duel.Phase == DuelPhase.Main1 && Bot.HasAttackingMonster())
                return false;
            if (Bot.Hand.Count >= 6) return true;
            if (Bot.HasInSpellZone(CardId.AntiSpellFragrance)) return false;
            return true;
        }

        private bool AltergeistProtocolset()
        {
            if (Duel.Turn > 1 && Duel.Phase == DuelPhase.Main1 && Bot.HasAttackingMonster())
                return false;
            if (Bot.Hand.Count >= 6) return true;
            if (Bot.HasInSpellZone(CardId.AltergeistProtocol))
            {
                if(HasOneTrapSet()) return false;
            }            
            return true;
        }

        private bool PersonalSpoofingset()
        {
            int personal_count = 0;
            foreach(ClientCard m in Bot.GetSpells())
            {
                if (Card.Id == CardId.PersonalSpoofing)
                    personal_count++;
            }
            if (Duel.Turn > 1 && Duel.Phase == DuelPhase.Main1 && Bot.HasAttackingMonster())
                return false;
            if (Bot.Hand.Count >= 6) return true;
            if (personal_count == 2) return false;
            return true;
        }

        private bool AltergeistMaterializationset()
        {
            if (Duel.Turn > 1 && Duel.Phase == DuelPhase.Main1 && Bot.HasAttackingMonster())
                return false;
            if (Bot.Hand.Count >= 6) return true;
            if (Bot.HasInSpellZone(CardId.AltergeistMaterialization)) return false;
            if (Bot.GetGraveyardMonsters().Count == 0) return false;
            return true;
        }

        private bool Spellset()
        {
            if(Bot.HasInSpellZone(CardId.AntiSpellFragrance) && Card.HasType(CardType.Spell))
            {
                if (Duel.Turn > 1 && Duel.Phase == DuelPhase.Main1 && Bot.HasAttackingMonster())
                    return false;
                return true;
            }
            return false;
        }

        public override bool OnSelectHand()
        {
            return true;            
        }
        private bool EnemyHasFloodgate()
        {
            foreach(ClientCard m in Enemy.GetMonsters())
            {
                if (m.IsFloodgate() || m.IsMonsterInvincible()) return true;
            }
            foreach(ClientCard m in Enemy.GetSpells())
            {
                if (m.IsFloodgate()) return true;
            }
            return false;
        }
        private bool HasTrapInHand()
        {
            foreach (ClientCard m in Bot.Hand)
            {
                if (m.HasType(CardType.Trap)) return true;                
            }
            return false;
        }

        private bool HasOneTrapSet()
        {
            foreach(ClientCard m in Bot.GetSpells())
            {
                if(m.HasType(CardType.Trap) && m.IsFacedown())
                {
                    return true;
                }
            }
            return false;
        }
    }
}