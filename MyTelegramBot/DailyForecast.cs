namespace MyTelegramBot
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    public partial class DailyForecast
    {
        [JsonProperty("Headline")]
        public Headline Headline { get; set; }

        [JsonProperty("DailyForecasts")]
        public List<DayForecast> DailyForecasts { get; set; }
    }

    public partial class DayForecast
    {
        [JsonProperty("Date")]
        public System.DateTime Date { get; set; }

        [JsonProperty("EpochDate")]
        public long EpochDate { get; set; }

        [JsonProperty("Sun")]
        public Sun Sun { get; set; }

        [JsonProperty("Moon")]
        public Moon Moon { get; set; }

        [JsonProperty("Temperature")]
        public Temperature Temperature { get; set; }

        [JsonProperty("RealFeelTemperature")]
        public Temperature RealFeelTemperature { get; set; }

        [JsonProperty("RealFeelTemperatureShade")]
        public RealFeelTemperatureShade RealFeelTemperatureShade { get; set; }

        [JsonProperty("HoursOfSun")]
        public double HoursOfSun { get; set; }

        [JsonProperty("DegreeDaySummary")]
        public DegreeDaySummary DegreeDaySummary { get; set; }

        [JsonProperty("AirAndPollen")]
        public List<AirAndPollen> AirAndPollen { get; set; }

        [JsonProperty("Day")]
        public Day Day { get; set; }

        [JsonProperty("Night")]
        public Day Night { get; set; }

        [JsonProperty("Sources")]
        public List<string> Sources { get; set; }

        [JsonProperty("MobileLink")]
        public string MobileLink { get; set; }

        [JsonProperty("Link")]
        public string Link { get; set; }
    }

    public partial class AirAndPollen
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Value")]
        public long Value { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("CategoryValue")]
        public long CategoryValue { get; set; }

        [JsonProperty("Type")]
        public string Type { get; set; }
    }

    public partial class Day
    {
        [JsonProperty("Icon")]
        public long Icon { get; set; }

        [JsonProperty("IconPhrase")]
        public string IconPhrase { get; set; }

        [JsonProperty("ShortPhrase")]
        public string ShortPhrase { get; set; }

        [JsonProperty("LongPhrase")]
        public string LongPhrase { get; set; }

        [JsonProperty("PrecipitationProbability")]
        public long PrecipitationProbability { get; set; }

        [JsonProperty("ThunderstormProbability")]
        public long ThunderstormProbability { get; set; }

        [JsonProperty("RainProbability")]
        public long RainProbability { get; set; }

        [JsonProperty("SnowProbability")]
        public long SnowProbability { get; set; }

        [JsonProperty("IceProbability")]
        public long IceProbability { get; set; }

        [JsonProperty("Wind")]
        public Wind Wind { get; set; }

        [JsonProperty("WindGust")]
        public Wind WindGust { get; set; }

        [JsonProperty("TotalLiquid")]
        public Ice TotalLiquid { get; set; }

        [JsonProperty("Rain")]
        public Ice Rain { get; set; }

        [JsonProperty("Snow")]
        public Ice Snow { get; set; }

        [JsonProperty("Ice")]
        public Ice Ice { get; set; }

        [JsonProperty("HoursOfPrecipitation")]
        public long HoursOfPrecipitation { get; set; }

        [JsonProperty("HoursOfRain")]
        public long HoursOfRain { get; set; }

        [JsonProperty("HoursOfSnow")]
        public long HoursOfSnow { get; set; }

        [JsonProperty("HoursOfIce")]
        public long HoursOfIce { get; set; }

        [JsonProperty("CloudCover")]
        public long CloudCover { get; set; }
    }

    public partial class Ice
    {
        [JsonProperty("Value")]
        public long Value { get; set; }

        [JsonProperty("Unit")]
        public string Unit { get; set; }

        [JsonProperty("UnitType")]
        public long UnitType { get; set; }
    }

    public partial class Wind
    {
        [JsonProperty("Speed")]
        public Speed Speed { get; set; }

        [JsonProperty("Direction")]
        public Direction Direction { get; set; }
    }

    public partial class Direction
    {
        [JsonProperty("Degrees")]
        public long Degrees { get; set; }

        [JsonProperty("Localized")]
        public string Localized { get; set; }

        [JsonProperty("English")]
        public string English { get; set; }
    }

    public partial class Speed
    {
        [JsonProperty("Value")]
        public double Value { get; set; }

        [JsonProperty("Unit")]
        public string Unit { get; set; }

        [JsonProperty("UnitType")]
        public long UnitType { get; set; }
    }

    public partial class DegreeDaySummary
    {
        [JsonProperty("Heating")]
        public Ice Heating { get; set; }

        [JsonProperty("Cooling")]
        public Ice Cooling { get; set; }
    }

    public partial class Moon
    {
        [JsonProperty("Rise")]
        public System.DateTime Rise { get; set; }

        [JsonProperty("EpochRise")]
        public long EpochRise { get; set; }

        [JsonProperty("Set")]
        public System.DateTime Set { get; set; }

        [JsonProperty("EpochSet")]
        public long EpochSet { get; set; }

        [JsonProperty("Phase")]
        public string Phase { get; set; }

        [JsonProperty("Age")]
        public long Age { get; set; }
    }

    public partial class Temperature
    {
        [JsonProperty("Minimum")]
        public Speed Minimum { get; set; }

        [JsonProperty("Maximum")]
        public Speed Maximum { get; set; }
    }

    public partial class RealFeelTemperatureShade
    {
        [JsonProperty("Minimum")]
        public Speed Minimum { get; set; }

        [JsonProperty("Maximum")]
        public Ice Maximum { get; set; }
    }

    public partial class Sun
    {
        [JsonProperty("Rise")]
        public System.DateTime Rise { get; set; }

        [JsonProperty("EpochRise")]
        public long EpochRise { get; set; }

        [JsonProperty("Set")]
        public System.DateTime Set { get; set; }

        [JsonProperty("EpochSet")]
        public long EpochSet { get; set; }
    }

    public partial class Headline
    {
        [JsonProperty("EffectiveDate")]
        public System.DateTime EffectiveDate { get; set; }

        [JsonProperty("EffectiveEpochDate")]
        public long EffectiveEpochDate { get; set; }

        [JsonProperty("Severity")]
        public long Severity { get; set; }

        [JsonProperty("Text")]
        public string Text { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }

        [JsonProperty("EndDate")]
        public System.DateTime EndDate { get; set; }

        [JsonProperty("EndEpochDate")]
        public long EndEpochDate { get; set; }

        [JsonProperty("MobileLink")]
        public string MobileLink { get; set; }

        [JsonProperty("Link")]
        public string Link { get; set; }
    }

    public partial class DailyForecast
    {
        public static DailyForecast FromJson(string json) => JsonConvert.DeserializeObject<DailyForecast>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this DailyForecast self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}

