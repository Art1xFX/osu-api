using JsonNet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;

namespace Osu
{
    public class Match
    {
        public static Match Parse(string s)
        {
            using (var stringReader = new StringReader(s))
            using (var jsonReader = new JsonTextReader(stringReader))
            {
                return new Match(jsonReader);
            }
        }

        public static bool TryParse(string s, out Match result)
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


        internal Match(JsonTextReader jsonReader)
        {
            int Depth = jsonReader.Depth;
            while (jsonReader.Read())
            {
                switch (jsonReader.TokenType)
                {
                    case JsonToken.PropertyName:
                        switch (jsonReader.Value.ToString())
                        {
                            case "match_id":
                                this.MatchId = long.Parse(jsonReader.ReadAsString());
                                break;
                            case "name":
                                this.Name = jsonReader.ReadAsString();
                                break;
                            case "start_time":
                                this.StartTime = jsonReader.ReadAsDateTime();
                                break;
                            case "end_time":
                                this.EndTime = jsonReader.ReadAsDateTime();
                                break;
                            case "games":
                                IList<Game> games = new List<Game>();
                                while (jsonReader.Read())
                                {
                                    if (jsonReader.TokenType == JsonToken.StartObject)
                                        games.Add(new Game(jsonReader));
                                }
                                this.Games = new ReadOnlyCollection<Game>(games);
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


        public long? MatchId { get; internal set; }

        public string Name { get; internal set; }

        public DateTime? StartTime { get; internal set; }

        public DateTime? EndTime { get; internal set; }

        public ReadOnlyCollection<Game> Games { get; internal set; }

    }
}
