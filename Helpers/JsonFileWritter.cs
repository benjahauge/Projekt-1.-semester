using Projekt.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Projekt.Helpers
{	
    public class JsonFileWritter
    {
		//WriteToJson til Kursus
		public static void WriteToJson(List<Kursus> @kursuses, string JsonFileName)
		{
			string output = Newtonsoft.Json.JsonConvert.SerializeObject(@kursuses, Newtonsoft.Json.Formatting.Indented);
			File.WriteAllText(JsonFileName, output);
		}

		//WriteToJson til User
		public static void WriteToJsonUser(List<User> @users, string JsonFileName)
		{
			string output = Newtonsoft.Json.JsonConvert.SerializeObject(@users, Newtonsoft.Json.Formatting.Indented);
			File.WriteAllText(JsonFileName, output);
		}

		//Virker ikke

		//public static void WriteToJson(List<Kursus> @kursuses, string JsonFileName)
		//{
		//	using (FileStream outputStream = File.OpenWrite(JsonFileName))
		//	{
		//		var writter = new Utf8JsonWriter(outputStream, new JsonWriterOptions
		//		{
		//			SkipValidation = false,
		//			Indented = true
		//		});
		//		JsonSerializer.Serialize<Kursus[]>(writter, @kursuses.ToArray());
		//	}

		//}
	}
}
