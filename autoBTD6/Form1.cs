using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ComboBox = System.Windows.Forms.ComboBox;
using ToolTip = System.Windows.Forms.ToolTip;

namespace autoBTD6
{
    public partial class Form1 : Form
    {
        private EventHandler _eventHandler;
        private ToolTip abilityCycleInfoToolTip = new ToolTip();
        private ToolTip abilityPressInfoToolTip = new ToolTip();

        public Form1()
        {
            InitializeComponent();
            _eventHandler = new EventHandler(this);

            // hover info for ability cycle
            abilityCycleInfoToolTip.AutoPopDelay = 5000;
            abilityCycleInfoToolTip.InitialDelay = 100;
            abilityCycleInfoToolTip.ReshowDelay = 100;
            abilityCycleInfoToolTip.ShowAlways = true;
            abilityCycleInfoToolTip.SetToolTip(this.label8, "Random delay range between each cycle of all abilities being triggered.");

            // hover info for ability press
            abilityPressInfoToolTip.AutoPopDelay = 5000;
            abilityPressInfoToolTip.InitialDelay = 100;
            abilityPressInfoToolTip.ReshowDelay = 100;
            abilityPressInfoToolTip.ShowAlways = true;
            abilityPressInfoToolTip.SetToolTip(this.label9, "Random delay range between each ability being triggered.");

            // initialize ability cycle and ability press values
            abilityCycleComboBoxFrom.SelectedItem = "5";
            abilityCycleComboBoxTo.SelectedItem = "7";
            abilityPressComboBoxFrom.SelectedItem = "0.1";
            abilityPressComboBoxTo.SelectedItem = "0.3";

            // initialize ability amount combo boxes
            for (int i = 1; i <= 9; i++)
            {
                string comboBoxName = "ability" + i + "ComboBox";
                ComboBox comboBox = (ComboBox)this.Controls.Find(comboBoxName, true)[0];
                comboBox.SelectedItem = "1";

            }
        }

        private async void startToggleButton_Click(object sender, EventArgs e)
        {
            _eventHandler.ToggleStartButton();
            await _eventHandler.PressAbilities();
        }

        // info for ability cycle
        private void label8_Click(object sender, EventArgs e)
        {
            abilityCycleInfoToolTip.Show("Random delay range between each cycle of all abilities being triggered.", label8);
        }

        // info for ability press
        private void label9_Click(object sender, EventArgs e)
        {
            abilityPressInfoToolTip.Show("Random delay range between each ability being triggered.", label9);
        }
    }
}
