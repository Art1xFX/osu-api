﻿using JsonNet;
using System;
using System.IO;

namespace Osu
{
    public class Scores
    {
        public static Scores Parse(string s)
        {
            using (var stringReader = new StringReader(s))
            using (var jsonReader = new JsonTextReader(stringReader))
            {
                return new Scores(jsonReader);
            }
        }

        public static bool TryParse(string s, out Scores result)
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


        internal Scores(JsonTextReader jsonReader)
        {
            int Depth = jsonReader.Depth;
            while (jsonReader.Read())
            {
                switch (jsonReader.TokenType)
                {
                    case JsonToken.PropertyName:
                        switch (jsonReader.Value.ToString())
                        {
                            case "score":
                                this.Score = jsonReader.ReadAsInt32();
                                break;
                            case "username":
                                this.Username = jsonReader.ReadAsString();
                                break;
                            case "count300":
                                this.Count300 = jsonReader.ReadAsInt32();
                                break;
                            case "count100":
                                this.Count100 = jsonReader.ReadAsInt32();
                                break;
                            case "count50":
                                this.Count50 = jsonReader.ReadAsInt32();
                                break;
                            case "countmiss":
                                this.CountMiss = jsonReader.ReadAsInt32();
                                break;
                            case "maxcombo":
                                this.MaxCombo = jsonReader.ReadAsInt32();
                                break;
                            case "countkatu":
                                this.CountKatu = jsonReader.ReadAsInt32();
                                break;
                            case "countgeki":
                                this.CountGeki = jsonReader.ReadAsInt32();
                                break;
                            case "perfect":
                                this.Perfect = Convert.ToBoolean(jsonReader.ReadAsInt32());
                                break;
                            case "enabled_mods":
                                this.EnabledMods = (Mods)jsonReader.ReadAsInt32();
                                break;
                            case "user_id":
                                this.UserId = jsonReader.ReadAsInt32();
                                break;
                            case "date":
                                this.Date = jsonReader.ReadAsDateTime();
                                break;
                            case "rank":
                                this.Rank = jsonReader.ReadAsString();
                                break;
                            case "pp":
                                this.PP = jsonReader.ReadAsDecimal();
                                break;
                            case "score_id":
                                this.ScoreId = jsonReader.ReadAsInt32();
                                break;
                            case "beatmap_id":
                                this.BeatmapId = long.Parse(jsonReader.ReadAsString());
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



        public long? BeatmapId { get; internal set; }

        public long? ScoreId { get; internal set; }

        public string Username { get; internal set; }

        public int? Score { get; internal set; }

        public int? Count300 { get; internal set; }

        public int? Count100 { get; internal set; }

        public int? Count50 { get; internal set; }

        public int? CountMiss { get; internal set; }

        public int? MaxCombo { get; internal set; }

        public int? CountKatu { get; internal set; }

        public int? CountGeki { get; internal set; }

        public bool? Perfect { get; internal set; }

        public Mods? EnabledMods { get; internal set; }

        public int? UserId { get; internal set; }

        public DateTime? Date { get; internal set; }

        public string Rank { get; internal set; }

        public decimal? PP { get; internal set; }

        public int? Pass { get; internal set; }

        public int? Slot { get; internal set; }

        public int? Team { get; internal set; }

    }

}
