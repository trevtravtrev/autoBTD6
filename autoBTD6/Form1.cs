using System;
using System.Threading;
using System.Windows.Forms;


namespace autoBTD6
{
    public partial class Form1 : Form
    {
        private EventHandler _eventHandler;
        private ToolTip abilityCycleInfoToolTip = new ToolTip();
        private ToolTip abilityPressInfoToolTip = new ToolTip();

        private ToolTip BTD6ActiveWindowInfoToolTip = new ToolTip();

        private bool _isRunning = false;
        private Thread _mainThread;

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

            // hover info for BTD6ActiveWindow
            BTD6ActiveWindowInfoToolTip.AutoPopDelay = 5000;
            BTD6ActiveWindowInfoToolTip.InitialDelay = 100;
            BTD6ActiveWindowInfoToolTip.ReshowDelay = 100;
            BTD6ActiveWindowInfoToolTip.ShowAlways = true;
            BTD6ActiveWindowInfoToolTip.SetToolTip(this.label12, "Only trigger ability keys if BTD6 is the active window. Stops it from triggering ability keys if you click out of BTD6 or another window. *Keep ON unless abilities are not being triggered in-game.*");

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
            if (_isRunning)
            {
                _isRunning = false;
                if (_mainThread !=null && _mainThread.IsAlive)
                {
                    _mainThread.Abort();
                }
                startToggleButton.Text = "Start";
                _eventHandler.EnableAll();
            }
            else
            {
                _isRunning = true;
                startToggleButton.Text = "Stop";
                _eventHandler.DisableAll();

                _eventHandler.ValidateAbilityCycleRange();
                _eventHandler.ValidateAbilityPressRange();

                PressAbilitiesParams pressAbilitiesParams = _eventHandler.PackageData();

                _mainThread = new Thread(new ParameterizedThreadStart(_eventHandler.PressAbilities));
                _mainThread.Start(pressAbilitiesParams);
            }    
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

        private void label12_Click(object sender, EventArgs e)
        {
            BTD6ActiveWindowInfoToolTip.Show("Only trigger ability keys if BTD6 is the active window. Stops it from triggering ability keys if you click out of BTD6 or another window. *Keep ON unless abilities are not being triggered in-game.*", label12);
        }
    }
}
