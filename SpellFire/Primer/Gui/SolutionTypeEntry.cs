﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SpellFire.Primer.Solutions;

namespace SpellFire.Primer.Gui
{
	public class SolutionTypeEntry
	{
		private Type type;

		private SolutionTypeEntry(Type type)
		{
			this.type = type;
		}
		public Type GetSolutionType()
		{
			return type;
		}

		public static IEnumerable<SolutionTypeEntry> GetSolutionTypes()
		{
			Type solutionBaseType = typeof(Solution);

			return Assembly
				.GetExecutingAssembly()
				.GetTypes()
				.Where(type =>
					type.IsPublic
					&& type.IsSubclassOf(solutionBaseType)
					&& type.IsClass
					&& !type.IsAbstract
					&& !type.IsSubclassOf(typeof(MultiboxSolution))
					)
				.Select(solutionType => new SolutionTypeEntry(solutionType));
		}

		public override string ToString()
		{
			return type.Name;
		}
	}
}
