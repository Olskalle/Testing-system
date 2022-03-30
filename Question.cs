using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO: Организовать хранение файлов/ хранение данных
// TODO: Реализовать методы связки внешних данных с программой

public class Codes
{
	public enum Type : byte
	{
		UNDEFINED,	//==0
		SOLO,		//==1
		MULTI,		//==2
		OPENED		//==3
	}
}	

namespace ReadXML
{
	class Question
	{
		private uint code;
		private Codes.Type type;
		private string image;
		private Dictionary<string, bool> answer;

		public uint Code { get { return code; } }
		public string Image { get { return image; } }
		public Codes.Type Type { get { return type; } }

		public Question(uint c, string i, Dictionary<string, bool> a, Codes.Type t)
		{
			code = c;
			image = i;
			answer = a;
			type = t;
		}

		public override string ToString()
		{
			string output = "\n";
			foreach (string a in answer.Keys)
			{
				output += $"{a}: {answer[a]}\n";
			}
			return $"{Type}: {Code}" + output;
		}
	}
}
