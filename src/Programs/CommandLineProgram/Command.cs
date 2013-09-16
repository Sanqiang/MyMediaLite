// Copyright (C) 2013 Zeno Gantner
//
// This file is part of MyMediaLite.
//
// MyMediaLite is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// MyMediaLite is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with MyMediaLite.  If not, see <http://www.gnu.org/licenses/>.
//
using System;
using System.Reflection;

namespace MyMediaLite.Program
{
	public abstract class Command
	{
		public abstract string Description { get; }

		public abstract string Usage { get; }

		public abstract void Run();

		public abstract void Configure(string[] args);

		public override string ToString()
		{
			return this.GetType().Name;
		}

		public static Command Create(string typename)
		{
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				Type type = assembly.GetType("MyMediaLite.Program." + typename, false, true);
				if (type != null)
					return type.Create();
			}
			return null;
		}
	}
}