﻿using System;

using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;





namespace FestivalManager.Entities.Factories
{
	using Contracts;
	using Entities.Contracts;
	using Sets;

	public class SetFactory : ISetFactory
	{
		public ISet CreateSet(string name, string type)
		{
            var types = Assembly.GetCallingAssembly().GetTypes();
            var typeOfSet = types.FirstOrDefault(t => t.Name == type);
            var ctor = typeOfSet.GetConstructors();
            ISet set = (ISet)ctor[0].Invoke(new object[] { name});
            return set;
        }
	}
}
