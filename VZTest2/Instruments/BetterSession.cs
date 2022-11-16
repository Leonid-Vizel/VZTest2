using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using System.Collections;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace VZTest2.Instruments
{
    public static class BetterSession
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonSerializer.Deserialize<T>(value);
        }

        public static void SetBoolean(this ISession session, string key, bool value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }

        public static bool? GetBoolean(this ISession session, string key)
        {
            var data = session.Get(key);
            if (data == null)
            {
                return null;
            }
            return BitConverter.ToBoolean(data, 0);
        }

        public static void SetDateTime(this ISession session, string key, DateTime value)
        {
            session.Set(key, BitConverter.GetBytes(value.ToBinary()));
        }

        public static DateTime? GetDateTime(this ISession session, string key)
        {
            var data = session.Get(key);
            if (data == null)
            {
                return null;
            }
            long binaryValue = BitConverter.ToInt64(data, 0);
            return DateTime.FromBinary(binaryValue);
        }

        public static void SetDouble(this ISession session, string key, double value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }

        public static double? GetDouble(this ISession session, string key)
        {
            var data = session.Get(key);
            if (data == null)
            {
                return null;
            }
            return BitConverter.ToDouble(data, 0);
        }

        public static string ToRussian(this TimeSpan span, bool backThen = true)
        {
            int hours = span.Hours;
            int minutes = span.Minutes;
            int seconds = span.Seconds;
            StringBuilder builder = new StringBuilder();
            if (hours > 0)
            {
                builder.Append($"{hours} {WordHelp.Inflect(hours, "часов", "час", "часа")} ");
            }
            if (minutes > 0)
            {
                builder.Append($"{minutes} {WordHelp.Inflect(minutes, "минут", "минуту", "минуты")} ");
            }
            builder.Append($"{seconds} {WordHelp.Inflect(seconds, "секунд", "секунду", "секунды")}");
            return backThen ? builder.Append(" назад").ToString() : builder.ToString();
        }

        public static List<(string, string)> GetActiveLogins(ISession userSession)
        {
            DateTime now = DateTime.Now;
            var trueFunction = () => true;
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
            MemoryDistributedCache cache = userSession.GetType().GetField("_cache", flags).GetValue(userSession) as MemoryDistributedCache;
            MemoryCache _memCache = cache.GetType().GetField("_memCache", flags).GetValue(cache) as MemoryCache;
            var _coherentState = _memCache.GetType().GetField("_coherentState", flags).GetValue(_memCache);
            var collection = _coherentState.GetType().GetProperty("EntriesCollection", flags).GetValue(_coherentState);
            IDictionary keyCollection = collection as IDictionary;
            List<(string, string)> loginsActive = new List<(string, string)>();
            foreach (var key in keyCollection.Keys)
            {
                DistributedSessionStore store = new DistributedSessionStore(cache, new LoggerFactory());
                ISession session = store.Create(key.ToString(), TimeSpan.FromHours(6), TimeSpan.Zero, trueFunction, false);
                string? login = session.GetString("login");
                DateTime? last = session.GetDateTime("Last");
                if (login != null && last != null)
                {
                    loginsActive.Add((login, now.Subtract(last.Value).ToRussian()));
                }
            }
            return loginsActive;
        }

        public static async Task EndSessionsByLogin(ISession userSession, string userLogin)
        {
            var trueFunction = () => true;
            BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
            MemoryDistributedCache cache = userSession.GetType().GetField("_cache", flags).GetValue(userSession) as MemoryDistributedCache;
            MemoryCache _memCache = cache.GetType().GetField("_memCache", flags).GetValue(cache) as MemoryCache;
            var _coherentState = _memCache.GetType().GetField("_coherentState", flags).GetValue(_memCache);
            var collection = _coherentState.GetType().GetProperty("EntriesCollection", flags).GetValue(_coherentState);
            IDictionary keyCollection = collection as IDictionary;
            List<(string, string)> loginsActive = new List<(string, string)>();
            foreach (var key in keyCollection.Keys)
            {
                DistributedSessionStore store = new DistributedSessionStore(cache, new LoggerFactory());
                ISession session = store.Create(key.ToString(), TimeSpan.FromHours(6), TimeSpan.FromSeconds(5), trueFunction, false);
                string? login = session.GetString("login");
                if (login != null && login.Equals(userLogin))
                {
                    session.Remove("login");
                    await session.CommitAsync();
                }
            }
        }

        //public static async Task UpdateSessionsByLogin(ISession userSession, UserEditModel user)
        //{
        //    var trueFunction = () => true;
        //    BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
        //    MemoryDistributedCache cache = userSession.GetType().GetField("_cache", flags).GetValue(userSession) as MemoryDistributedCache;
        //    MemoryCache _memCache = cache.GetType().GetField("_memCache", flags).GetValue(cache) as MemoryCache;
        //    var _coherentState = _memCache.GetType().GetField("_coherentState", flags).GetValue(_memCache);
        //    var collection = _coherentState.GetType().GetProperty("EntriesCollection", flags).GetValue(_coherentState);
        //    IDictionary keyCollection = collection as IDictionary;
        //    List<(string, string)> loginsActive = new List<(string, string)>();
        //    foreach (var key in keyCollection.Keys)
        //    {
        //        DistributedSessionStore store = new DistributedSessionStore(cache, new LoggerFactory());
        //        ISession session = store.Create(key.ToString(), TimeSpan.FromHours(6), TimeSpan.FromSeconds(5), trueFunction, false);
        //        string? login = session.GetString("login");
        //        if (login != null && login.Equals(user.Login.ToLower()))
        //        {
        //            session.SetBoolean("main", user.MainDepartment);
        //            session.SetBoolean("education", user.EducationDepartment);
        //            session.SetBoolean("source", user.SourceTrackingDepartment);
        //            session.SetBoolean("report", user.PeriodicReportingDepartment);
        //            session.SetBoolean("international", user.InternationalDepartment);
        //            session.SetBoolean("document", user.DocumentationDepartment);
        //            session.SetBoolean("nr", user.NrDepartment);
        //            session.SetBoolean("db", user.DbDepartment);
        //            session.SetBoolean("MonSpec", user.MonitoringSpecialist);
        //            session.SetInt32("MonSpecResp", user.MonitroingResponsible);
        //            session.SetString("name", $"{user.Name} {user.Surname}");
        //            session.SetString("role", user.MonitoringSpecialist ? AuthChecker.MonSpecName : user.Admin ? AuthChecker.AdminName : AuthChecker.ManagerName);
        //            await session.CommitAsync();
        //        }
        //    }
        //}
    }
}
