using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using MoonSharp.Interpreter;
using LuaFramework;
using System;

namespace LuaLibrary
{
	public static class LuaCode
	{
		public static DynValue GetLuaGlobal(string variableKeyLua)
		{
			Script lua = new Script();
			ImportBaseFiles(lua);

			return lua.Globals.Get(variableKeyLua);
		}

		/// <summary>
		/// Get a List of Entities.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="entity"></param>
		/// <returns></returns>
		public static List<T> GetTable<T>(string table, bool applyParentChildConversion)
		{
			Script lua = new Script();
			ImportBaseFiles(lua);

			DynValue luaTable = lua.Globals.Get(table);

			List<T> result_table = (applyParentChildConversion) ?
				LuaReader.Read<List<T>>(luaTable.Table.Get(table)) :
				LuaReader.Read<List<T>>(luaTable.Table);

			return result_table;
		}

		public static List<string> GetKeys(string table, bool applyParentChildConversion)
		{
			Script lua = new Script();
			ImportBaseFiles(lua);

			DynValue luaTable = lua.Globals.Get(table);
			List<string> keys = new List<string>();

			List<DynValue> _keys = (applyParentChildConversion) ?
				luaTable.Table.Get(table).Table.Keys.ToList() :
				luaTable.Table.Keys.ToList();

			foreach (var key in _keys)
				keys.Add(key.String);

			return keys;
		}

		/// <summary>
		/// Get Only one entity filtered.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="entity"></param>
		/// <param name="filter"></param>
		/// <returns></returns>
		public static T GetTable<T>(string table, string key, bool applyParentChildConversion)
		{
			Script lua = new Script();
			ImportBaseFiles(lua);

			DynValue luaTable = lua.Globals.Get(table);

			T single = (applyParentChildConversion) ?
				LuaReader.Read<T>(luaTable.Table.Get(table).Table.Get(key)) :
				LuaReader.Read<T>(luaTable.Table.Get(key));

			//T single = LuaReader.Read<T>(luaTable.Table.Get(key) );

			return single;
		}

		public static T ExecuteLuaFunction<T>(string functionName, params string[] parametersList)
		{
			Script lua = new Script();
			ImportBaseFiles(lua);

			DynValue luaTable = new DynValue();
			ExecuteLuaFunction(functionName, out luaTable, parametersList);
			T entity = LuaReader.Read<T>(luaTable);
			lua.DoString("return " + functionName + "()");

			return entity;
		}

		//public static void ExecuteLuaFunction(string functionName)
		//{
		//    Script lua = new Script();
		//    ImportBaseFiles(lua);

		//    lua.DoString("return " + functionName + "()");
		//}

		public static DynValue ExecuteLuaFunction(string functionName)
		{
			Script lua = new Script();
			ImportBaseFiles(lua);

			return lua.DoString("return " + functionName + "()");
		}

		public static void ExecuteLuaFunction(string functionName, out DynValue dynValue, params string[] parametersList)
		{
			Script lua = new Script();

			//string dir = Script.RunString("function HolaMundo() return 'Hola Mundo'end HolaMundo()").String;
			//string dir = Script.RunString(@"return 'Hola Mundo'").String;
			//Script.RunString(@"print('Hola Mundo')").String;
			//string result = lua.DoString(@"return 'Hola Mundo'").String;
			ImportBaseFiles(lua);

			dynValue = lua.DoString("return " + functionName + "(" + JoinParameters(parametersList) + ")");
		}

		public static DynValue ExecuteLuaFunction(string functionName, params string[] parametersList)
		{
			Script lua = new Script();

			//string dir = Script.RunString("function HolaMundo() return 'Hola Mundo'end HolaMundo()").String;
			//string dir = Script.RunString(@"return 'Hola Mundo'").String;
			//Script.RunString(@"print('Hola Mundo')").String;
			//string result = lua.DoString(@"return 'Hola Mundo'").String;
			ImportBaseFiles(lua);

			return lua.DoString("return " + functionName + "(" + JoinParameters(parametersList) + ")");
		}

		private static void ImportBaseFiles(Script lua)
		{
			lua.DoFile("tablelib.lua");
			lua.DoFile("luafunctions.lua");
		}

		private static string JoinParameters(params string[] parameters)
		{
			System.Text.StringBuilder builder = new System.Text.StringBuilder();
			for (int i = 0; i < parameters.Length; i++)
			{
				builder.Append("'");
				builder.Append(parameters[i]);
				builder.Append("'");
				builder.Append(",");
			}

			//Remove the last comma.
			builder.Remove(builder.Length - 1, 1);

			return builder.ToString();
		}

		private static string JoinParameters(params int[] parameters)
		{
			System.Text.StringBuilder builder = new System.Text.StringBuilder();
			for (int i = 0; i < parameters.Length; i++)
			{
				builder.Append(parameters[i]);
				builder.Append(",");
			}

			//Remove the last comma.
			builder.Remove(builder.Length - 1, 1);

			return builder.ToString();
		}

		private static string JoinParameters(params float[] parameters)
		{
			System.Text.StringBuilder builder = new System.Text.StringBuilder();
			for (int i = 0; i < parameters.Length; i++)
			{
				builder.Append(parameters[i]);
				builder.Append(",");
			}

			//Remove the last comma.
			builder.Remove(builder.Length - 1, 1);

			return builder.ToString();
		}

		//In Lua file sometimes Tables refer to AMMO.AMMO or BIRDS.BIRDS with this conversion
		//In Lua is Call correctly after apply this fix.
		//private static string ApplyParentChildConversion(string tableName)
		//{
		//	return tableName + "." + tableName;
		//}
	}
}
