using Projekt.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Projekt.Helpers
{
    public class JsonFileReader
    {
		//public static List<Kursus> ReadJson(string JsonFileName)
		//{
		//	string jsonString = File.ReadAllText(JsonFileName);
		//	return System.Text.Json.JsonSerializer.Deserialize<List<Kursus>>(jsonString);
		//}

		//ReadJson til Kursus
		public static List<Kursus> ReadJson(string JsonFileName)
		{
			using (var jsonFileReader = File.OpenText(JsonFileName))
			{
				return JsonSerializer.Deserialize<List<Kursus>>(jsonFileReader.ReadToEnd());
			}
		}

		//ReadJson til User
		public static List<User> ReadJsonUser(string JsonFileName)
		{
			using (var jsonFileReader = File.OpenText(JsonFileName))
			{
				return JsonSerializer.Deserialize<List<User>>(jsonFileReader.ReadToEnd());
			}
		}
	}
}
