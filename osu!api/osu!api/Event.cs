using JsonNet;
using System;
using System.IO;

namespace Osu
{
    public class Event
    {
        public static Event Parse(string s)
        {
            using (var stringReader = new StringReader(s))
            using (var jsonReader = new JsonTextReader(stringReader))
            {
                return new Event(jsonReader);
            }
        }

        public static bool TryParse(string s, out Event result)
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


        internal Event(JsonTextReader jsonReader)
        {
            int Depth = jsonReader.Depth;
            while (jsonReader.Read())
            {
                switch (jsonReader.TokenType)
                {
                    case JsonToken.PropertyName:
                        switch (jsonReader.Value.ToString())
                        {
                            case "display_html":
                                this.DisplayHtml = jsonReader.ReadAsString();
                                break;
                            case "beatmap_id":
                                this.BeatmapId = jsonReader.ReadAsInt32();
                                break;
                            case "beatmapset_id":
                                this.BeatmapSetId = jsonReader.ReadAsInt32();
                                break;
                            case "date":
                                this.Date = jsonReader.ReadAsDateTime();
                                break;
                            case "epicfactor":
                                this.Epificator = jsonReader.ReadAsInt32();
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


        public string DisplayHtml { get; internal set; }

        public int? BeatmapId { get; internal set; }

        public int? BeatmapSetId { get; internal set; }

        public DateTime? Date { get; internal set; }

        /// <summary>
        /// How "epic" this event is (between 1 and 32).
        /// </summary>
        public int? Epificator { get; internal set; }

    }

}
