using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VS2019LaunchDemoFinale.Models;

namespace VS2019LaunchDemoFinale.Bussiness.Interfaces
{
	public interface ILigaNegocio
	{
		Liga GetLiga();
		Club GetClub(string key);
		void EliminarClub(Club club);
		void CrearClub(Club club);
		void ActualizarClub(Club club);
		void ActualizarNombreLiga(string nombre);
	}
}
