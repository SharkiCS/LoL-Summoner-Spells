
using System.Collections.Generic;
using System.Linq;
using RiotSharp;

namespace LoL_Summoners_Spells
{
    class SharkiQuerys
    {
        public static string _controlar_excepcion;
        public static RiotSharp.Misc.Region _Region;
        public static string _NombreInvocador;
        public static string _Key;
        public static List <RiotSharp.StaticDataEndpoint.Champion.ChampionStatic> Enemigos = new List<RiotSharp.StaticDataEndpoint.Champion.ChampionStatic>();
        public static List <RiotSharp.StaticDataEndpoint.SummonerSpell.SummonerSpellStatic> Hechizos = new List<RiotSharp.StaticDataEndpoint.SummonerSpell.SummonerSpellStatic>();

        // Comprobar la conexión 
        public static bool Comprobar_Conexion(string key, string nombreInvocador, RiotSharp.Misc.Region region)
        {
            RiotSharp.RiotApi api = RiotApi.GetDevelopmentInstance(key);

            try { api.GetSummonerByName(region, nombreInvocador);
                _NombreInvocador = nombreInvocador;
                _Key = key;
                _Region = region;
                return true; }
            catch (RiotSharpException) { return false; }
        }


        public static void Obtener_Enemigos()
        {
            RiotSharp.RiotApi Api = RiotApi.GetDevelopmentInstance(_Key);
            RiotSharp.StaticRiotApi StaticApi = StaticRiotApi.GetInstance(_Key);

            try
            {
               
                RiotSharp.SummonerEndpoint.Summoner Summoner = Api.GetSummonerByName(_Region, _NombreInvocador);
                List<RiotSharp.SpectatorEndpoint.Participant> Participants = Api.GetCurrentGame(_Region, Summoner.Id).Participants;

                // --- ## Diccionarios para cargar los campeones & hechizos ## --- //

                Dictionary<string, RiotSharp.StaticDataEndpoint.Champion.ChampionStatic>.ValueCollection championlist =
                        StaticApi.GetChampions(_Region, RiotSharp.StaticDataEndpoint.ChampionData.All).Champions.Values;

                Dictionary<string, RiotSharp.StaticDataEndpoint.SummonerSpell.SummonerSpellStatic>.ValueCollection SummonerSpell =
                        StaticApi.GetSummonerSpells(_Region, RiotSharp.StaticDataEndpoint.SummonerSpellData.All).SummonerSpells.Values;

                // --- ## Diccionarios para cargar los campeones & hechizos ## --- //

                int total = Participants.Count;
                int index = Participants.FindIndex(a => a.SummonerName == _NombreInvocador);

                if (index > (total / 2) - 1)
                {
                    for (int i = 0; i <= (total / 2) - 1; i++)
                    {

                        IEnumerable<RiotSharp.StaticDataEndpoint.Champion.ChampionStatic>
                        CampeonWhere = championlist.Where(yourself => yourself.Id == Participants[i].ChampionId);

                        IEnumerable<RiotSharp.StaticDataEndpoint.SummonerSpell.SummonerSpellStatic>
                        Spell1Where = SummonerSpell.Where(yourself => yourself.Id == Participants[i].SummonerSpell1);

                        IEnumerable<RiotSharp.StaticDataEndpoint.SummonerSpell.SummonerSpellStatic>
                        Spell2Where = SummonerSpell.Where(yourself => yourself.Id == Participants[i].SummonerSpell2);

                        Enemigos.Add(CampeonWhere.First());
                        Hechizos.Add(Spell1Where.First());
                        Hechizos.Add(Spell2Where.First());
                    
                       
                    }
                }
                else
                {
                    for (int i = 0; i <= (total / 2) - 1; i++)
                    {

                        IEnumerable<RiotSharp.StaticDataEndpoint.Champion.ChampionStatic>
                        CampeonWhere = championlist.Where(yourself => yourself.Id == Participants[total / 2 + i].ChampionId);

                        IEnumerable<RiotSharp.StaticDataEndpoint.SummonerSpell.SummonerSpellStatic>
                        Spell1Where = SummonerSpell.Where(yourself => yourself.Id == Participants[total / 2 + i].SummonerSpell1);

                        IEnumerable<RiotSharp.StaticDataEndpoint.SummonerSpell.SummonerSpellStatic>
                        Spell2Where = SummonerSpell.Where(yourself => yourself.Id == Participants[total / 2 + i].SummonerSpell2);


                        Enemigos.Add(CampeonWhere.First());
                        Hechizos.Add(Spell1Where.First());
                        Hechizos.Add(Spell2Where.First());

                    }
                }
            }
            catch (RiotSharpException e)
            {
                _controlar_excepcion = e.Message;
            }
        }
    
    }
}
