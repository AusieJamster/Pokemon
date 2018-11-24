using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    public struct StatValues {

        public int attack { get; private set; }
        public int defense { get; private set; }
        public int specialAttack { get; private set; }
        public int specialDefense { get; private set; }
        public int speed { get; private set; }
        public int hitpoints { get; private set; }

        public StatValues(int hp, int atk, int def, int sAtk, int sDef, int spd)
        {
            hitpoints = hp;
            attack = atk;
            defense = def;
            specialAttack = sAtk;
            specialDefense = sDef;
            speed = spd;
        }
        public static bool operator ==(StatValues c1, StatValues c2)
        {
            int v1 = c1.attack + c1.defense + c1.hitpoints + c1.specialAttack + c1.specialDefense + c1.speed;
            int v2 = c2.attack + c2.defense + c2.hitpoints + c2.specialAttack + c2.specialDefense + c2.speed;

            return v1.Equals(v2);
        }
        public static bool operator !=(StatValues c1, StatValues c2)
        {
            int v1 = c1.attack + c1.defense + c1.hitpoints + c1.specialAttack + c1.specialDefense + c1.speed;
            int v2 = c2.attack + c2.defense + c2.hitpoints + c2.specialAttack + c2.specialDefense + c2.speed;

            return !v1.Equals(v2);
        }
        public static bool operator >=(StatValues c1, StatValues c2)
        {
            int v1 = c1.attack + c1.defense + c1.hitpoints + c1.specialAttack + c1.specialDefense + c1.speed;
            int v2 = c2.attack + c2.defense + c2.hitpoints + c2.specialAttack + c2.specialDefense + c2.speed;

            return v1 >= v2;
        }
        public static bool operator <=(StatValues c1, StatValues c2)
        {
            int v1 = c1.attack + c1.defense + c1.hitpoints + c1.specialAttack + c1.specialDefense + c1.speed;
            int v2 = c2.attack + c2.defense + c2.hitpoints + c2.specialAttack + c2.specialDefense + c2.speed;

            return v1 <= v2;
        }
        public static bool operator >(StatValues c1, StatValues c2)
        {
            int v1 = c1.attack + c1.defense + c1.hitpoints + c1.specialAttack + c1.specialDefense + c1.speed;
            int v2 = c2.attack + c2.defense + c2.hitpoints + c2.specialAttack + c2.specialDefense + c2.speed;

            return v1 > v2;
        }
        public static bool operator <(StatValues c1, StatValues c2)
        {
            int v1 = c1.attack + c1.defense + c1.hitpoints + c1.specialAttack + c1.specialDefense + c1.speed;
            int v2 = c2.attack + c2.defense + c2.hitpoints + c2.specialAttack + c2.specialDefense + c2.speed;

            return v1 < v2;
        }
    }

    int id;
    PokemonBreed type;
    int level;
    
    StatValues baseValues;
    StatValues individualValues;
    StatValues effortValues;
    NatureTypes nature;

    // not always needed value
    int exp;
    string nickname;


    public Pokemon(PokemonBreed breed, int minLevel, int maxLevel)
    {

    }

    public Pokemon(string name, PokemonBreed breed, int lvl, int nature, StatValues iv, StatValues ev)
    {

    }

    private StatValues GetValuesFromID(int value)
    {
        List<StatValues> baseStats = new List<StatValues>() {
            new StatValues(45, 49, 49, 65, 65, 45),
            new StatValues(60, 62, 63, 80, 80, 60),
            new StatValues(80, 82, 83, 100, 100, 80),
            new StatValues(39, 52, 43, 60, 50, 65),
            new StatValues(58, 64, 58, 80, 65, 80),
            new StatValues(78, 84, 78, 109, 85, 100),
            new StatValues(44, 48, 65, 50, 64, 43),
            new StatValues(59, 63, 80, 65, 80, 58),
            new StatValues(79, 83, 100, 85, 105, 78),
            new StatValues(45, 30, 35, 20, 20, 45),
            new StatValues(50, 20, 55, 25, 25, 30),
            new StatValues(60, 45, 50, 80, 80, 70),
            new StatValues(40, 35, 30, 20, 20, 50),
            new StatValues(45, 25, 50, 25, 25, 35),
            new StatValues(65, 80, 40, 45, 80, 75),
            new StatValues(40, 45, 40, 35, 35, 56),
            new StatValues(63, 60, 55, 50, 50, 71),
            new StatValues(83, 80, 75, 70, 70, 91),
            new StatValues(30, 56, 35, 25, 35, 72),
            new StatValues(55, 81, 60, 50, 70, 97),
            new StatValues(40, 60, 30, 31, 31, 70),
            new StatValues(65, 90, 65, 61, 61, 100),
            new StatValues(35, 60, 44, 40, 54, 55),
            new StatValues(60, 85, 69, 65, 79, 80),
            new StatValues(35, 55, 30, 50, 40, 90),
            new StatValues(60, 90, 55, 90, 80, 100),
            new StatValues(50, 75, 85, 20, 30, 40),
            new StatValues(75, 100, 110, 45, 55, 65),
            new StatValues(55, 47, 52, 40, 40, 41),
            new StatValues(70, 62, 67, 55, 55, 56),
            new StatValues(90, 82, 87, 75, 85, 76),
            new StatValues(46, 57, 40, 40, 40, 50),
            new StatValues(61, 72, 57, 55, 55, 65),
            new StatValues(81, 92, 77, 85, 75, 85),
            new StatValues(70, 45, 48, 60, 65, 35),
            new StatValues(95, 70, 73, 85, 90, 60),
            new StatValues(38, 41, 40, 50, 65, 65),
            new StatValues(73, 76, 75, 81, 100, 100),
            new StatValues(115, 45, 20, 45, 25, 20),
            new StatValues(140, 70, 45, 75, 50, 45),
            new StatValues(40, 45, 35, 30, 40, 55),
            new StatValues(75, 80, 70, 65, 75, 90),
            new StatValues(45, 50, 55, 75, 65, 30),
            new StatValues(60, 65, 70, 85, 75, 40),
            new StatValues(75, 80, 85, 100, 90, 50),
            new StatValues(35, 70, 55, 45, 55, 25),
            new StatValues(60, 95, 80, 60, 80, 30),
            new StatValues(60, 55, 50, 40, 55, 45),
            new StatValues(70, 65, 60, 90, 75, 90),
            new StatValues(10, 55, 25, 35, 45, 95),
            new StatValues(35, 100, 50, 50, 70, 120),
            new StatValues(40, 45, 35, 40, 40, 90),
            new StatValues(65, 70, 60, 65, 65, 115),
            new StatValues(50, 52, 48, 65, 50, 55),
            new StatValues(80, 82, 78, 95, 80, 85),
            new StatValues(40, 80, 35, 35, 45, 70),
            new StatValues(65, 105, 60, 60, 70, 95),
            new StatValues(55, 70, 45, 70, 50, 60),
            new StatValues(90, 110, 80, 100, 80, 95),
            new StatValues(40, 50, 40, 40, 40, 90),
            new StatValues(65, 65, 65, 50, 50, 90),
            new StatValues(90, 95, 95, 70, 90, 70),
            new StatValues(25, 20, 15, 105, 55, 90),
            new StatValues(40, 35, 30, 120, 70, 105),
            new StatValues(55, 50, 45, 135, 95, 120),
            new StatValues(70, 80, 50, 35, 35, 35),
            new StatValues(80, 100, 70, 50, 60, 45),
            new StatValues(90, 130, 80, 65, 85, 55),
            new StatValues(50, 75, 35, 70, 30, 40),
            new StatValues(65, 90, 50, 85, 45, 55),
            new StatValues(80, 105, 65, 100, 60, 70),
            new StatValues(40, 40, 35, 50, 100, 70),
            new StatValues(80, 70, 65, 80, 120, 100),
            new StatValues(40, 80, 100, 30, 30, 20),
            new StatValues(55, 95, 115, 45, 45, 35),
            new StatValues(80, 120, 130, 55, 65, 45),
            new StatValues(50, 85, 55, 65, 65, 90),
            new StatValues(65, 100, 70, 80, 80, 105),
            new StatValues(90, 65, 65, 40, 40, 15),
            new StatValues(95, 75, 110, 100, 80, 30),
            new StatValues(25, 35, 70, 95, 55, 45),
            new StatValues(50, 60, 95, 120, 70, 70),
            new StatValues(52, 65, 55, 58, 62, 60),
            new StatValues(35, 85, 45, 35, 35, 75),
            new StatValues(60, 110, 70, 60, 60, 100),
            new StatValues(65, 45, 55, 45, 70, 45),
            new StatValues(90, 70, 80, 70, 95, 70),
            new StatValues(80, 80, 50, 40, 50, 25),
            new StatValues(105, 105, 75, 65, 100, 50),
            new StatValues(30, 65, 100, 45, 25, 40),
            new StatValues(50, 95, 180, 85, 45, 70),
            new StatValues(30, 35, 30, 100, 35, 80),
            new StatValues(45, 50, 45, 115, 55, 95),
            new StatValues(60, 65, 60, 130, 75, 110),
            new StatValues(35, 45, 160, 30, 45, 70),
            new StatValues(60, 48, 45, 43, 90, 42),
            new StatValues(85, 73, 70, 73, 115, 67),
            new StatValues(30, 105, 90, 25, 25, 50),
            new StatValues(55, 130, 115, 50, 50, 75),
            new StatValues(40, 30, 50, 55, 55, 100),
            new StatValues(60, 50, 70, 80, 80, 140),
            new StatValues(60, 40, 80, 60, 45, 40),
            new StatValues(95, 95, 85, 125, 75, 55),
            new StatValues(50, 50, 95, 40, 50, 35),
            new StatValues(60, 80, 110, 50, 80, 45),
            new StatValues(50, 120, 53, 35, 110, 87),
            new StatValues(50, 105, 79, 35, 110, 76),
            new StatValues(90, 55, 75, 60, 75, 30),
            new StatValues(40, 65, 95, 60, 45, 35),
            new StatValues(65, 90, 120, 85, 70, 60),
            new StatValues(80, 85, 95, 30, 30, 25),
            new StatValues(105, 130, 120, 45, 45, 40),
            new StatValues(250, 5, 5, 35, 105, 50),
            new StatValues(65, 55, 115, 100, 40, 60),
            new StatValues(105, 95, 80, 40, 80, 90),
            new StatValues(30, 40, 70, 70, 25, 60),
            new StatValues(55, 65, 95, 95, 45, 85),
            new StatValues(45, 67, 60, 35, 50, 63),
            new StatValues(80, 92, 65, 65, 80, 68),
            new StatValues(30, 45, 55, 70, 55, 85),
            new StatValues(60, 75, 85, 100, 85, 115),
            new StatValues(40, 45, 65, 100, 120, 90),
            new StatValues(70, 110, 80, 55, 80, 105),
            new StatValues(65, 50, 35, 115, 95, 95),
            new StatValues(65, 83, 57, 95, 85, 105),
            new StatValues(65, 95, 57, 100, 85, 93),
            new StatValues(65, 125, 100, 55, 70, 85),
            new StatValues(75, 100, 95, 40, 70, 110),
            new StatValues(20, 10, 55, 15, 20, 80),
            new StatValues(95, 125, 79, 60, 100, 81),
            new StatValues(130, 85, 80, 85, 95, 60),
            new StatValues(48, 48, 48, 48, 48, 48),
            new StatValues(55, 55, 50, 45, 65, 55),
            new StatValues(130, 65, 60, 110, 95, 65),
            new StatValues(65, 65, 60, 110, 95, 130),
            new StatValues(65, 130, 60, 95, 110, 65),
            new StatValues(65, 60, 70, 85, 75, 40),
            new StatValues(35, 40, 100, 90, 55, 35),
            new StatValues(70, 60, 125, 115, 70, 55),
            new StatValues(30, 80, 90, 55, 45, 55),
            new StatValues(60, 115, 105, 65, 70, 80),
            new StatValues(80, 105, 65, 60, 75, 130),
            new StatValues(160, 110, 65, 65, 110, 30),
            new StatValues(90, 85, 100, 95, 125, 85),
            new StatValues(90, 90, 85, 125, 90, 100),
            new StatValues(90, 100, 90, 125, 85, 90),
            new StatValues(41, 64, 45, 50, 50, 50),
            new StatValues(61, 84, 65, 70, 70, 70),
            new StatValues(91, 134, 95, 100, 100, 80),
            new StatValues(106, 110, 90, 154, 90, 130),
            new StatValues(100, 100, 100, 100, 100, 100)
        };
        return baseStats[value];
    }

    private int GetFinalHitpoints()
    {
        return Mathf.FloorToInt((2 * baseValues.hitpoints + individualValues.hitpoints + 
            Mathf.Floor(effortValues.hitpoints / 4)) * level / 100 + level + 10);
    }

    private int GetFinalStat(Stat s) {
        float bValue = 0;
        float ivValue = 0;
        float evValue = 0;
        float nValue = 0;

        switch (s)
        {
            case Stat.Hitpoints:
                return GetFinalHitpoints();
            case Stat.Attack:
                bValue = baseValues.attack;
                ivValue = individualValues.attack;
                evValue = effortValues.attack;
                nValue = 1f + GetValuesFromNature(nature).attack / 10f;
                break;
            case Stat.Defence:
                bValue = baseValues.defense;
                ivValue = individualValues.defense;
                evValue = effortValues.defense;
                nValue = 1f + GetValuesFromNature(nature).defense / 10f;
                break;
            case Stat.SpecialAttack:
                bValue = baseValues.specialAttack;
                ivValue = individualValues.specialAttack;
                evValue = effortValues.specialAttack;
                nValue = 1f + GetValuesFromNature(nature).specialAttack / 10f;
                break;
            case Stat.SpecialDefense:
                bValue = baseValues.specialDefense;
                ivValue = individualValues.specialDefense;
                evValue = effortValues.specialDefense;
                nValue = 1f + GetValuesFromNature(nature).specialDefense / 10f;
                break;
            case Stat.Speed:
                bValue = baseValues.speed;
                ivValue = individualValues.speed;
                evValue = effortValues.speed;
                nValue = 1f + GetValuesFromNature(nature).speed / 10f;
                break;
            default:
                throw new System.Exception("Unknown Stat Type: " + s.ToString());
        }

        return Mathf.FloorToInt(Mathf.Floor(2f * bValue + ivValue + Mathf.Floor(evValue / 4f))
            * level / 100f + 5f * nValue);
    }

    private enum Stat
    {
        Hitpoints,
        Attack,
        Defence,
        SpecialAttack,
        SpecialDefense,
        Speed
    }

    private StatValues GetValuesFromNature(NatureTypes nature)
    {
        switch (nature)
        {
            case NatureTypes.Hardy:
            case NatureTypes.Docile:
            case NatureTypes.Serious:
            case NatureTypes.Bashful:
            case NatureTypes.Quirky:
                return new StatValues(0, 0, 0, 0, 0, 0);
            case NatureTypes.Lonely:
                return new StatValues(0, 1, -1, 0, 0, 0);
            case NatureTypes.Brave:
                return new StatValues(0, 1, 0, 0, 0, -1);
            case NatureTypes.Adamant:
                return new StatValues(0, 1, 0, -1, 0, 0);
            case NatureTypes.Naughty:
                return new StatValues(0, 1, 0, 0, -1, 0);
            case NatureTypes.Bold:
                return new StatValues(0, -1, 1, 0, 0, 0);
            case NatureTypes.Relaxed:
                return new StatValues(0, 0, 1, 0, 0, -1);
            case NatureTypes.Impish:
                return new StatValues(0, 0, 1, -1, 0, 0);
            case NatureTypes.Lax:
                return new StatValues(0, 0, 1, 0, -1, 0);
            case NatureTypes.Timid:
                return new StatValues(0, -1, 0, 0, 0, 1);
            case NatureTypes.Hasty:
                return new StatValues(0, 0, -1, 0, 0, 1);
            case NatureTypes.Jolly:
                return new StatValues(0, 0, 0, -1, 0, 1);
            case NatureTypes.Naive:
                return new StatValues(0, 0, 0, 0, -1, 1);
            case NatureTypes.Modest:
                return new StatValues(0, -1, 0, 1, 0, 0);
            case NatureTypes.Mild:
                return new StatValues(0, 0, -1, 1, 0, 0);
            case NatureTypes.Quiet:
                return new StatValues(0, 0, 0, 1, 0, -1);
            case NatureTypes.Rash:
                return new StatValues(0, 0, 0, 1, -1, 0);
            case NatureTypes.Calm:
                return new StatValues(0, -1, 0, 0, 1, 0);
            case NatureTypes.Gentle:
                return new StatValues(0, 0, -1, 0, 1, 0);
            case NatureTypes.Sassy:
                return new StatValues(0, 0, 0, 0, 1, -1);
            case NatureTypes.Careful:
                return new StatValues(0, 0, 0, -1, 1, 0);
            default:
                throw new System.Exception("Unknown nature request: " + nature);
        }
    }

    public enum PokemonBreed
    {
        Bulbasaur,
        Ivysaur,
        Venusaur,
        Charmander,
        Charmeleon,
        Charizard,
        Squirtle,
        Wartortle,
        Blastoise,
        Caterpie,
        Metapod,
        Butterfree,
        Weedle,
        Kakuna,
        Beedrill,
        Pidgey,
        Pidgeotto,
        Pidgeot,
        Rattata,
        Raticate,
        Spearow,
        Fearow,
        Ekans,
        Arbok,
        Pikachu,
        Raichu,
        Sandshrew,
        Sandslash,
        Nidoran_F,
        Nidorina,
        Nidoqueen,
        Nidoran_M,
        Nidorino,
        Nidaking,
        Clefairy,
        Clefable,
        Vulpix,
        Ninetales,
        Jigglypuff,
        Wigglytuff,
        Zubat,
        Golbat,
        Oddish,
        Gloom,
        Vileplume,
        Paras,
        Parasect,
        Venonat,
        Venomoth,
        Diglett,
        Dugtrio,
        Meowth,
        Persian,
        Psyduck,
        Golduck,
        Mankey,
        Primeape,
        Growlithe,
        Arcanine,
        Poliwag,
        Poliwhirl,
        Poliwrath,
        Abra,
        Kadabra,
        Alakazam,
        Machop,
        Machoke,
        Machamp,
        Bellsprout,
        Weepinbell,
        Victreebel,
        Tentacool,
        Tentacruel,
        Geodude,
        Graveler,
        Golem,
        Ponyta,
        Rapidash,
        Slowpoke,
        Slowbro,
        Magnemite,
        Magneton,
        Farfetchd,
        Doduo,
        Dodrio,
        Seel,
        Dewgong,
        Grimer,
        Muk,
        Shellder,
        Cloyster,
        Gastly,
        Haunter,
        Gengar,
        Onix,
        Drowzee,
        Hypno,
        Krabby,
        Kingler,
        Voltorb,
        Electrode,
        Exeggcute,
        Exeggutor,
        Cubone,
        Marowak,
        Hitonlee,
        Hitmonchan,
        Lickitung,
        Koffing,
        Weezing,
        Rhyhorn,
        Rhydon,
        Chansey,
        Tangela,
        Kangaskhan,
        Horsea,
        Seadra,
        Goldeen,
        Seaking,
        Staryu,
        Starmie,
        MrMime,
        Scyther,
        Jynx,
        Electabuzz,
        Magmar,
        Pinsir,
        Tauros,
        Magikarp,
        Gyarados,
        Lapras,
        Ditto,
        Eevee,
        Vaporeon,
        Jolteon,
        Flareon,
        Porygon,
        Omanyte,
        Omastar,
        Kabuto,
        Kabutops,
        Aerodactyl,
        Snorlax,
        Articuno,
        Zapdos,
        Moltres,
        Dratini,
        Dragonair,
        Dragonite,
        Mewtwo,
        Mew
    }

    public enum NatureTypes
    {
        Hardy,
        Lonely,
        Brave,
        Adamant,
        Naughty,
        Bold,
        Docile,
        Relaxed,
        Impish,
        Lax,
        Timid,
        Hasty,
        Serious,
        Jolly,
        Naive,
        Modest,
        Mild,
        Quiet,
        Bashful,
        Rash,
        Calm,
        Gentle,
        Sassy,
        Careful,
        Quirky
    }
}