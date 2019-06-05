using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VS2019LaunchDemoFinale.Bussiness.Interfaces;
using VS2019LaunchDemoFinale.Models;

namespace VS2019LaunchDemoFinale.Bussiness
{
	public class LigaNegocio : ILigaNegocio
	{
		private Liga _ligaFutbol = new Liga();

		private static string relativePath = "AppData/es.1.clubs.json";

		public LigaNegocio()
		{
			// extract liga data from JSON file and store it
			Liga liga;
			using (StreamReader r = new StreamReader(relativePath))
			{
				string json = r.ReadToEnd();
				liga = JsonConvert.DeserializeObject<Liga>(json);
			}

			_ligaFutbol = liga;
		}

		public Liga GetLiga()
		{
			if (_ligaFutbol == null) return null;
			return _ligaFutbol;
		}

		public Club GetClub(string key)
		{
			Club club = _ligaFutbol.Clubs.FirstOrDefault(m => m.Key == key);

			if (club == null) return null;
			return club;
		}

		public void EliminarClub(Club club)
		{
			if (club != null)
			{
				_ligaFutbol.Clubs.Remove(club);
			}
		}

		public void CrearClub(Club club)
		{
			if (club != null)
			{
				_ligaFutbol.Clubs.Add(club);
			}
		}

		public void ActualizarClub(Club club)
		{
			if (club != null)
			{
				int clubIndex = _ligaFutbol.Clubs.FindIndex(x => x.Key == club.Key);

				_ligaFutbol.Clubs[clubIndex] = club;


			}
		}
		public void ActualizarNombreLiga(string nombre)
		{
			if (nombre != null)
			{
				_ligaFutbol.Name = nombre;				
			}
		}

	}
}
