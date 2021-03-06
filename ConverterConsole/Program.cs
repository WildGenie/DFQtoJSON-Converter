﻿using System.IO;
using DFQtoJSONConverter;

namespace ConverterConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			var converter = new DfqConverter();
			
			var location = System.Reflection.Assembly.GetEntryAssembly().Location;
			var directory = Path.GetDirectoryName(location);

			var files = Directory.EnumerateFiles(directory, "*.dfq");

			foreach (var file in files)
			{
				converter.Convert(file);
				File.WriteAllText(file.Replace(".dfq", ".json"), converter.GetJson());
			}
		}
	}
}