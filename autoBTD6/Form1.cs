using System;
using System.Windows.Forms;


namespace autoBTD6
{
    public partial class Form1 : Form
    {
        private EventHandler _eventHandler;
        public Form1()
        {
            InitializeComponent();
            _eventHandler = new EventHandler(this);

            abilityCycleComboBoxFrom.SelectedItem = "5";
            abilityCycleComboBoxTo.SelectedItem = "7";
            abilityPressComboBoxFrom.SelectedItem = "0.1";
            abilityPressComboBoxTo.SelectedItem = "0.3";

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
    }
}
