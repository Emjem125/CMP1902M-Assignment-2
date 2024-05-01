using System;
namespace CMP1903M
{
	public class Die
	{
		//encapsulation
		private int _rolls;


		///Property
		public int Rolls
		{
			get { return _rolls; }
			set { _rolls = value; }
		}


		/// <summary>
		/// Method that randomises a number between 1 and 6 to represent a 6 sided dice.
		/// </summary>
		/// <returns>Returns the roll value</returns>
		public int Roll()
		{
			var roll = new Random(Guid.NewGuid().GetHashCode());
			Rolls = roll.Next(1, 7);
			return Rolls;
		}
	}
}

