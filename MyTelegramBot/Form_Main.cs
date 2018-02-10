using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//---------------------------
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

using System.Net.Http;



namespace MyTelegramBot
{
    public partial class Form_Main : Form
    {
        static TelegramBotClient bot = new TelegramBotClient(Properties.Settings.Default.BotToken);
        static public User Robot;
        public Form_Main()
        {
            InitializeComponent();

        }


        static async Task RunBot()
        {
            Robot = await bot.GetMeAsync();
            int botOfset = 0;
            while (true)
            {
                var Updates = await bot.GetUpdatesAsync(offset: botOfset);
                foreach (var update in Updates)
                {
                    long msgChatId = update.Message.Chat.Id;
                    string msgText = update.Message.Text;
                    User msgSender = update.Message.From;

                    botOfset = update.Id + 1;

                    switch (update.Message.Type)
                    {
                        case MessageType.UnknownMessage:
                            break;
                        case MessageType.TextMessage:
                            {
                                switch (update.Message.Chat.Type)
                                {
                                    case ChatType.Private:
                                        {
                                            if (msgText == "/start")
                                            {
                                                await bot.SendTextMessageAsync(msgChatId, "سلام. چه خبر " + update.Message.From.FirstName);
                                            }
                                        }
                                        break;
                                }
                            }
                            break;
                        case MessageType.PhotoMessage:
                            break;
                        case MessageType.AudioMessage:
                            break;
                        case MessageType.VideoMessage:
                            break;
                        case MessageType.VoiceMessage:
                            break;
                        case MessageType.DocumentMessage:
                            break;
                        case MessageType.StickerMessage:
                            break;
                        case MessageType.LocationMessage:
                            {
                                var values = new Dictionary<string, string>
                                {
                                   { "Key", "LocalizedName" }
                                };

                                Location msgLocation = update.Message.Location;
                                HttpClient httpClient = new HttpClient();
                                var content = new FormUrlEncodedContent(values);

                                var jsonString = await httpClient.GetStringAsync(
                                    "http://dataservice.accuweather.com/locations/v1/cities/geoposition/search?apikey=" +
                                    Properties.Settings.Default.AccuweatherAPIKey + "&q=" +
                                    msgLocation.Latitude.ToString().Replace('/', '.') + "," + msgLocation.Longitude.ToString().Replace('/', '.') +
                                    "&details=false HTTP/1.1"
                                    );

                                string locationKey = Newtonsoft.Json.Linq.JObject.Parse(jsonString)["Key"].ToString();

                                var jsonString_5DayForecast = await httpClient.GetStringAsync("https://developer.accuweather.com/forecasts/v1/daily/5day/" + locationKey + "?apikey=" + Properties.Settings.Default.AccuweatherAPIKey + "&language=fa-Ir&metric=true HTTP / 1.1");

                                var Forecasts = DailyForecast.FromJson(jsonString);


                                switch (update.Message.Chat.Type)
                                {
                                    case ChatType.Private:
                                        {
                                            foreach (DayForecast dayAndNight in Forecasts.DailyForecasts)
                                            {
                                                await bot.SendTextMessageAsync(msgChatId, "Date: " + dayAndNight.Date + Environment.NewLine);

                                                string DayCaption = "دمای هوا: " + Environment.NewLine +
                                                                    "کمینه دما: " + dayAndNight.Temperature.Maximum +
                                                                    "\t" +
                                                                    "بیشنه دما: " + dayAndNight.Temperature.Maximum +
                                                                    Environment.NewLine +
                                                                    "کمینه دمایی که احساس می‌شود: " +
                                                                    dayAndNight.RealFeelTemperature.Minimum + "\t" +
                                                                    "بیشنه دمایی که احساس می‌شود: " +
                                                                    dayAndNight.RealFeelTemperature.Maximum +
                                                                    Environment.NewLine;
                                                                    

                                                await bot.SendPhotoAsync(msgChatId,
                                                    new FileToSend(new Uri(
                                                        "https://developer.accuweather.com/sites/default/files/" + dayAndNight.Day.Ice.Value.ToString("00") + "-s.png")), DayCaption);
                                                await bot.SendTextMessageAsync(msgChatId, "SunRise: " + dayAndNight.Sun.Rise + "\t");
                                                await bot.SendTextMessageAsync(msgChatId, "SunSet: " + dayAndNight.Sun.Set + "\t");

                                                await bot.SendTextMessageAsync(msgChatId, "MoonRise: " + dayAndNight.Moon.Rise);
                                                await bot.SendTextMessageAsync(msgChatId, "MoonSet: " + dayAndNight.Moon.Set + Environment.NewLine);
                                                await bot.SendTextMessageAsync(msgChatId, "MoonAge: " + dayAndNight.Moon.Age + Environment.NewLine);

                                                await bot.SendTextMessageAsync(msgChatId, "Temperature.Minimum: " + dayAndNight.Temperature.Minimum + "\t");
                                                await bot.SendTextMessageAsync(msgChatId, "Temperature.Minimum: " + dayAndNight.Temperature.Minimum + Environment.NewLine);

                                                await bot.SendTextMessageAsync(msgChatId, "RealFeelTemperature.Minimum: " + dayAndNight.RealFeelTemperature.Minimum + "\t");
                                                await bot.SendTextMessageAsync(msgChatId, "RealFeelTemperature.Minimum: " + dayAndNight.RealFeelTemperature.Minimum + Environment.NewLine);

                                                await bot.SendTextMessageAsync(msgChatId, "DayAndNight.HoursOfSun: " + dayAndNight.HoursOfSun + Environment.NewLine);

                                                #region Day
                                                await bot.SendTextMessageAsync(msgChatId, "Day: " + Environment.NewLine);

                                                await bot.SendTextMessageAsync(msgChatId, "Day.IconPhrase: " + dayAndNight.Day.IconPhrase + Environment.NewLine);
                                                await bot.SendTextMessageAsync(msgChatId, "Day.ShortPhrase): " + dayAndNight.Day.ShortPhrase + Environment.NewLine);
                                                await bot.SendTextMessageAsync(msgChatId, "Day.Wind.Direction.Speed: " + dayAndNight.Day.Wind.Speed.Value + " " + dayAndNight.Day.Wind.Speed.Unit + "\t");
                                                await bot.SendTextMessageAsync(msgChatId, "Day.Wind.Direction.Localized: " + dayAndNight.Day.Wind.Direction.Localized + Environment.NewLine);

                                                if (dayAndNight.Day.Rain.Value != 0)
                                                {
                                                    await bot.SendTextMessageAsync(msgChatId, "Rain: " + dayAndNight.Day.Rain.Value.ToString() + " " + dayAndNight.Day.Rain.Unit + "\t");
                                                }

                                                if (dayAndNight.Day.Snow.Value != 0)
                                                {
                                                    await bot.SendTextMessageAsync(msgChatId, "Snow: " + dayAndNight.Day.Snow.Value.ToString() + " " + dayAndNight.Day.Snow.Unit + "\t");
                                                }

                                                if (dayAndNight.Day.Ice.Value != 0)
                                                {
                                                    await bot.SendTextMessageAsync(msgChatId, "Ice: " + dayAndNight.Day.Ice.Value.ToString() + " " + dayAndNight.Day.Ice.Unit + "\t");
                                                }


                                                #endregion



                                                #region MyRegion
                                                await bot.SendTextMessageAsync(msgChatId, "Night: " + Environment.NewLine);

                                                await bot.SendTextMessageAsync(msgChatId, "Night.IconPhrase: " + dayAndNight.Night.IconPhrase + Environment.NewLine);
                                                await bot.SendTextMessageAsync(msgChatId, "Night.ShortPhrase): " + dayAndNight.Night.ShortPhrase + Environment.NewLine);
                                                await bot.SendTextMessageAsync(msgChatId, "Night.Wind.Direction.Speed: " + dayAndNight.Night.Wind.Speed.Value + " " + dayAndNight.Night.Wind.Speed.Unit + "\t");
                                                await bot.SendTextMessageAsync(msgChatId, "Night.Wind.Direction.Localized: " + dayAndNight.Night.Wind.Direction.Localized + Environment.NewLine);

                                                if (dayAndNight.Day.Rain.Value != 0)
                                                {
                                                    await bot.SendTextMessageAsync(msgChatId, "Rain: " + dayAndNight.Day.Rain.Value.ToString() + " " + dayAndNight.Day.Rain.Unit + "\t");
                                                }

                                                if (dayAndNight.Day.Snow.Value != 0)
                                                {
                                                    await bot.SendTextMessageAsync(msgChatId, "Snow: " + dayAndNight.Day.Snow.Value.ToString() + " " + dayAndNight.Day.Snow.Unit + "\t");
                                                }

                                                if (dayAndNight.Day.Ice.Value != 0)
                                                {
                                                    await bot.SendTextMessageAsync(msgChatId, "Ice: " + dayAndNight.Day.Ice.Value.ToString() + " " + dayAndNight.Day.Ice.Unit + "\t");
                                                }



                                                await bot.SendTextMessageAsync(msgChatId, Environment.NewLine);


                                                #endregion


                                            }

                                        }
                                        break;
                                }
                            }
                            break;
                        case MessageType.ContactMessage:
                            break;
                    }
                }
            }
        }
        private void Form_Main_Load(object sender, EventArgs e)
        {
            Task.Run(() => RunBot());

        }

        private void btn_BotDetails_Click(object sender, EventArgs e)
        {
            richTextBox1.AppendText("Robot.Username: " + Robot.Username + Environment.NewLine);
            richTextBox1.AppendText("Robot.FirstName: " + Robot.FirstName + Environment.NewLine);
            richTextBox1.AppendText("Robot.Id: " + Robot.Id + Environment.NewLine);

        }
    }
}
