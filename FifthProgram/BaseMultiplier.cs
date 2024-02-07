using System;
using System.Diagnostics;
using System.Text;

public class BaseMultiplier
{
	public string Multiplicand { get; set; }
	public StringBuilder TableString { get; private set; }

	private int _base;

	public BaseMultiplier(int baseValue)
	{
		this.TableString = new StringBuilder();
		this._base = baseValue;
	}

	public void getMultiplicationTable(string minMultiplier, string maxMultiplier)
	{
		this.TableString.Clear();

		BaseConverter converter = new BaseConverter(this._base);

		int denMultiplicand = 0;
		int denMinMultiplier = 0;
		int denMaxMultiplier = 0;

		try
		{
			denMultiplicand = converter.ConvertToDecimal(this.Multiplicand);
			denMinMultiplier = converter.ConvertToDecimal(minMultiplier);
			denMaxMultiplier = converter.ConvertToDecimal(maxMultiplier);
		} catch (FormatException e)
		{
			throw new FormatException($"Could not convert number: {e.Message}");
		} catch (ArgumentException e)
		{
			throw new ArgumentException($"Could not convert number: {e.Message}");
		}

		for (int i = denMinMultiplier; i <= denMaxMultiplier; i++)
		{
			try
			{
                this.TableString.AppendFormat("{0} * {1} = {2}\n", this.Multiplicand, converter.convertToBase(i), converter.convertToBase(denMultiplicand * i));
            } catch (ArgumentException e) {
				throw new ArgumentException($"Could not convert to base: {e.Message}");
			}
		}
	}
}
