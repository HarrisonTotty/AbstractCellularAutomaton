using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomaton
{
    /// <summary>
    /// Represents a particular cell in a cellular automaton grid.
    /// </summary>
    [Serializable, TypeConverter(typeof(CellTypeConverter))]
    public class Cell
    {
        /// <summary>
        /// Creates a new cell initialized to a particular state and random ID.
        /// </summary>
        /// <param name="State">The state to initialize this cell under</param>
        public Cell(int State)
        {
            this.State = State;
            this.ID = Random.AlphaNumeric(20);
        }

        /// <summary>
        /// Indicates the state of this cell as a numerical value (classically 0 or 1).
        /// </summary>
        [Description("Indicates the state of this cell as a numerical value (classically 0 or 1)")]
        public int State
        {
            get;
            set;
        }

        /// <summary>
        /// The unique ID of this cell.
        /// </summary>
        [Description("The unique ID associated with this cell")]
        public string ID
        {
            get;
            set;
        }

        public static bool operator ==(Cell C1, Cell C2)
        {
            return C1.ID == C2.ID;
        }

        public static bool operator !=(Cell C1, Cell C2)
        {
            return C1.ID != C2.ID;
        }
    }

    public class CellTypeConverter : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string) || sourceType == typeof(int))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }


        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            //if (value is string)
            //{
            //    return new Cell(;
            //}
            return base.ConvertFrom(context, culture, value);
        }


        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                return "Cell: { State = " + (value as Cell).State + "}";
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
