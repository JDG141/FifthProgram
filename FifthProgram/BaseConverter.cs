using System;
using System.Text;

public class BaseConverter
{
	private int _base;

	public BaseConverter(int baseValue)
	{
		this._base = baseValue;
	}

	public int ConvertToDecimal(string number)
	{
		try
		{
			int decimalValue = Convert.ToInt32(number, this._base);
			return decimalValue;
		} catch (FormatException)
		{
			throw new FormatException("Invalid number format.");
		} catch (ArgumentException)
		{
			throw new ArgumentException("Invalid base value.");
		}
	}

	public string convertToBase(int number)
	{
		if (number < 0 || this._base < 2 || this._base > 36)
		{
			throw new ArgumentException("Invalid input.");
		}

		StringBuilder result = new StringBuilder();

		while (number > 0)
		{
			int remainder = number % this._base;
			char digit = (remainder < 10) ? (char)(remainder + '0') : (char)(remainder - 10 + 'A');
			result.Insert(0, digit);
			number /= this._base;
		}

		return result.ToString();
	}
}
