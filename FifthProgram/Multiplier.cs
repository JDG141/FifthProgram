using System;
using System.Text;

public class Multiplier
{
	// Properties
	public int Multiplicand { get; set; } // The number to be multiplied
    public StringBuilder TableString { get; private set; } // The multiplication table. Can only be set within class

	// Constructor
	public Multiplier()
	{
        this.TableString = new StringBuilder(); // Initialise the string builder
	}

    // Get multiplication table method
    public void getMultiplicationTable(int minMultiplier = 0, int maxMultiplier = 12)
    {
        this.TableString.Clear(); // Clear string builder (old multiplicaion tables may still be here)

        for (int i = minMultiplier; i <= maxMultiplier; i++)
        {
            this.TableString.AppendFormat("{0} * {1} = {2}\n", this.Multiplicand, i, this.Multiplicand * i); // Append each row to the string (w/ a new line)
        }
    }
}
