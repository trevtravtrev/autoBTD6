using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;

namespace autoBTD6
{
    public class EventHandler
    {
        private readonly Form1 _form;

        public readonly List<CheckBox> _abilityCheckBoxes = new List<CheckBox>();
        public readonly List<ComboBox> _amountComboBoxes = new List<ComboBox>();

        private readonly ComboBox _abilityCycleFrom;
        private readonly ComboBox _abilityCycleTo;
        private readonly ComboBox _abilityPressFrom;
        private readonly ComboBox _abilityPressTo;

        private Button _startToggleButton;


        private bool startToggleButtonFlag;
        private bool firstLoop;

        public EventHandler(Form1 form)
        {
            _form = form;
            // Add ability checkboxes to list
            _abilityCheckBoxes.Add(form.ability1CheckBox);
            _abilityCheckBoxes.Add(form.ability2CheckBox);
            _abilityCheckBoxes.Add(form.ability3CheckBox);
            _abilityCheckBoxes.Add(form.ability4CheckBox);
            _abilityCheckBoxes.Add(form.ability5CheckBox);
            _abilityCheckBoxes.Add(form.ability6CheckBox);
            _abilityCheckBoxes.Add(form.ability7CheckBox);
            _abilityCheckBoxes.Add(form.ability8CheckBox);
            _abilityCheckBoxes.Add(form.ability9CheckBox);

            // Add amount combo boxes to list
            _amountComboBoxes.Add(form.ability1ComboBox);
            _amountComboBoxes.Add(form.ability2ComboBox);
            _amountComboBoxes.Add(form.ability3ComboBox);
            _amountComboBoxes.Add(form.ability4ComboBox);
            _amountComboBoxes.Add(form.ability5ComboBox);
            _amountComboBoxes.Add(form.ability6ComboBox);
            _amountComboBoxes.Add(form.ability7ComboBox);
            _amountComboBoxes.Add(form.ability8ComboBox);
            _amountComboBoxes.Add(form.ability9ComboBox);

            _abilityCycleFrom = form.abilityCycleComboBoxFrom;
            _abilityCycleTo = form.abilityCycleComboBoxTo;
            _abilityPressFrom = form.abilityPressComboBoxFrom;
            _abilityPressTo = form.abilityPressComboBoxTo;

            _startToggleButton = form.startToggleButton;

            startToggleButtonFlag = false;
        }

        public async Task PressAbilities()
        {
            firstLoop = true;
            while (startToggleButtonFlag == true)
            {
                Random random = new Random();
                if (firstLoop == true)
                {
                    await Task.Delay(random.Next(int.Parse(_abilityCycleFrom.Text) * 1000, int.Parse(_abilityCycleTo.Text) * 1000));
                    firstLoop = false;
                }
                for (int i = 0; i < _abilityCheckBoxes.Count; i++)
                {
                    if (_abilityCheckBoxes[i].Checked)
                    {
                        for (int j = 0; j < int.Parse(_amountComboBoxes[i].Text); j++)
                        {
                            SendKeys.SendWait((i + 1).ToString());
                            decimal abilityPressFrom = decimal.Parse(_abilityPressFrom.Text) * 1000;
                            decimal abilityPressTo = decimal.Parse(_abilityPressTo.Text) * 1000;
                            await Task.Delay(random.Next((int)abilityPressFrom, (int)abilityPressTo));
                        }
                    }
                }
                await Task.Delay(random.Next(int.Parse(_abilityCycleFrom.Text) * 1000, int.Parse(_abilityCycleTo.Text) * 1000));
            }
            return;
        }

        public void ToggleStartButton()
        {
            if (startToggleButtonFlag == false)
            {
                startToggleButtonFlag = true;
                _startToggleButton.Text = "Stop";

            }
            else
            {
                startToggleButtonFlag = false;
                _startToggleButton.Text = "Start";
            }
        }
    }
}