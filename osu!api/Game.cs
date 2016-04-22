using JsonNet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Osu
{
    public class Game
    {
        public static Game Parse(string s)
        {
            using (var stringReader = new StringReader(s))
            using (var jsonReader = new JsonTextReader(stringReader))
            {
                return new Game(jsonReader);
            }
        }

        public static bool TryParse(string s, out Game result)
        {
            try
            {
                result = Parse(s);
                return true;
            }
            catch
            {
                result = null;
                return false;
            }
        }


        internal Game(JsonTextReader jsonReader)
        {
            int Depth = jsonReader.Depth;
            while (jsonReader.Read())
            {
                switch (jsonReader.TokenType)
                {
                    case JsonToken.PropertyName:
                        switch (jsonReader.Value.ToString())
                        {
                            case "game_id":
                                this.GameId = long.Parse(jsonReader.ReadAsString());
                                break;
                            case "start_time":
                                this.StartTime = jsonReader.ReadAsDateTime();
                                break;
                            case "end_time":
                                this.EndTime = jsonReader.ReadAsDateTime();
                                break;
                            case "beatmap_id":
                                this.Beatmap_Id = long.Parse(jsonReader.ReadAsString());
                                break;
                            case "play_mode":
                                this.PlayMode = (Mode)jsonReader.ReadAsInt32();
                                break;
                            case "match_type":
                                this.MatchType = jsonReader.ReadAsInt32();
                                break;
                            case "scoring_type":
                                this.ScoringType = (WinningCondition)jsonReader.ReadAsInt32();
                                break;
                            case "team_type":
                                this.TeamType = (TeamType)jsonReader.ReadAsInt32();
                                break;
                            case "mods":
                                this.Mods = (Mods)jsonReader.ReadAsInt32();
                                break;
                            case "scores":
                                IList<Scores> scores = new List<Scores>();
                                while (jsonReader.Read())
                                {
                                    if (jsonReader.TokenType == JsonToken.StartObject)
                                        scores.Add(new Scores(jsonReader));
                                }
                                this.Scores = new ReadOnlyCollection<Osu.Scores>(scores);
                                break;
                            default:

                                break;
                        }
                        break;
                    case JsonToken.EndObject:
                        if (jsonReader.Depth == Depth)
                            return;
                        break;
                }
            }
        }


        public long? GameId { get; internal set; }

        public DateTime? StartTime { get; internal set; }

        public DateTime? EndTime { get; internal set; }

        public long? Beatmap_Id { get; internal set; }

        public Mode? PlayMode { get; internal set; }

        public int? MatchType { get; internal set; }

        public WinningCondition? ScoringType { get; internal set; }

        public TeamType? TeamType { get; internal set; }

        public Mods? Mods { get; internal set; }

        public ReadOnlyCollection<Scores> Scores { get; internal set; }

    }
}
