using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace autoBTD6
{
    public class PressAbilitiesParams
    {
        public IntPtr handle { get; set; }

        public Dictionary<CheckBox, bool> abilityCheckDict { get; set; }
        public Dictionary<ComboBox, int> abilityComboDict { get; set; }

        public int abilityCycleComboBoxFrom { get; set; }
        public int abilityCycleComboBoxTo { get; set; }
        public int abilityPressComboBoxFrom { get; set; }
        public int abilityPressComboBoxTo { get; set; }

        public bool BTD6ActiveWindow { get; set; } 
    }
}
