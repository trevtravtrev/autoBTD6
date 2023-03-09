using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
<<<<<<< Updated upstream
using System.Threading.Tasks;
=======
using System.Linq;
using System.Runtime.InteropServices;
using AutoIt;

>>>>>>> Stashed changes

namespace autoBTD6
{
    public class EventHandler
    {
        // import user32.dll library for getting foreground window and finding window
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private readonly Form1 _form;

        public readonly List<CheckBox> _abilityCheckBoxes = new List<CheckBox>();
        public readonly List<ComboBox> _abilityComboBoxes = new List<ComboBox>();

        private readonly ComboBox _abilityCycleFrom;
        private readonly ComboBox _abilityCycleTo;
        private readonly ComboBox _abilityPressFrom;
        private readonly ComboBox _abilityPressTo;

        private readonly CheckBox _BTD6ActiveWindow;

<<<<<<< Updated upstream

        private bool startToggleButtonFlag;
        private bool firstLoop;
=======
>>>>>>> Stashed changes

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
            _abilityComboBoxes.Add(form.ability1ComboBox);
            _abilityComboBoxes.Add(form.ability2ComboBox);
            _abilityComboBoxes.Add(form.ability3ComboBox);
            _abilityComboBoxes.Add(form.ability4ComboBox);
            _abilityComboBoxes.Add(form.ability5ComboBox);
            _abilityComboBoxes.Add(form.ability6ComboBox);
            _abilityComboBoxes.Add(form.ability7ComboBox);
            _abilityComboBoxes.Add(form.ability8ComboBox);
            _abilityComboBoxes.Add(form.ability9ComboBox);

            // Delays
            _abilityCycleFrom = form.abilityCycleComboBoxFrom;
            _abilityCycleTo = form.abilityCycleComboBoxTo;
            _abilityPressFrom = form.abilityPressComboBoxFrom;
            _abilityPressTo = form.abilityPressComboBoxTo;

<<<<<<< Updated upstream
            _startToggleButton = form.startToggleButton;

            startToggleButtonFlag = false;
        }

        public async Task PressAbilities()
        {
            firstLoop = true;
            while (startToggleButtonFlag == true)
            {
                ValidateAbilityCycleRange();
                ValidateAbilityPressRange();
                Random random = new Random();
                if (firstLoop == true)
                {
                    ValidateAbilityCycleRange();
                    await Task.Delay(random.Next(int.Parse(_abilityCycleFrom.Text) * 1000, int.Parse(_abilityCycleTo.Text) * 1000));
                    firstLoop = false;
                }
                for (int i = 0; i < _abilityCheckBoxes.Count; i++)
=======
            // Settings
            _BTD6ActiveWindow = form.BTD6ActiveWindow;
        }

        public void PressAbilities(object parameters)
        {
            PressAbilitiesParams pressAbilitiesParams = (PressAbilitiesParams)parameters;

            Random random = new Random();

            while (true)
            {
                Thread.Sleep(random.Next(pressAbilitiesParams.abilityCycleComboBoxFrom, pressAbilitiesParams.abilityCycleComboBoxTo));

                for(int i = 0; i < pressAbilitiesParams.abilityCheckDict.Count; i++)
>>>>>>> Stashed changes
                {
                    // if ability checkbox is checked
                    if (pressAbilitiesParams.abilityCheckDict.ElementAt(i).Value)
                    {
                        // get amount from corresponding combo box
                        int amount = pressAbilitiesParams.abilityComboDict.ElementAt(i).Value;

                        // trigger 'ability' keypress for corresponding number key
                        for (int j = 0; j < amount; j++)
                        {
<<<<<<< Updated upstream
                            SendKeys.SendWait((i + 1).ToString());
                            ValidateAbilityPressRange();
                            decimal abilityPressFrom = decimal.Parse(_abilityPressFrom.Text) * 1000;
                            decimal abilityPressTo = decimal.Parse(_abilityPressTo.Text) * 1000;
                            await Task.Delay(random.Next((int)abilityPressFrom, (int)abilityPressTo));
                        }
                    }
                }
                ValidateAbilityCycleRange();
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
=======
                            if (pressAbilitiesParams.BTD6ActiveWindow)
                            {
                                // find the btd6 window
                                string className = "UnityWndClass";
                                string windowTitle = "BloonsTD6";
                                IntPtr BTD6 = FindWindow(className, windowTitle);

                                // if btd6 window is in focus
                                if (BTD6 != IntPtr.Zero && GetForegroundWindow() == BTD6)
                                {
                                    // trigger ability key
                                    AutoItX.Send((i + 1).ToString());
                                }
                            }
                            else
                            {
                                // if any window is in focus EXCEPT the autoBTD6 app window
                                if (GetForegroundWindow() != pressAbilitiesParams.handle)
                                {
                                    // trigger ability key
                                    AutoItX.Send((i + 1).ToString());
                                }
                            }
                            Thread.Sleep(random.Next(pressAbilitiesParams.abilityPressComboBoxFrom, pressAbilitiesParams.abilityPressComboBoxTo));
                        }
                    }
                }
>>>>>>> Stashed changes
            }
        }

        public void ValidateAbilityCycleRange()
        {
            if (int.Parse(_abilityCycleFrom.Text) > int.Parse(_abilityCycleTo.Text))
            {
                string from = _abilityCycleFrom.Text;
                string to = _abilityCycleTo.Text;
                _abilityCycleFrom.SelectedItem = to;
                _abilityCycleTo.SelectedItem = from;
            }
        }

        public void ValidateAbilityPressRange()
        {
            if (decimal.Parse(_abilityPressFrom.Text) > decimal.Parse(_abilityPressTo.Text))
            {
                string from = _abilityPressFrom.Text;
                string to = _abilityPressTo.Text;
                _abilityPressFrom.SelectedItem = to;
                _abilityPressTo.SelectedItem = from;
            }
        }

        public void DisableAll()
        {
            for (int i = 0; i < _abilityCheckBoxes.Count; i++)
            {
                _abilityCheckBoxes[i].Enabled = false;
            }
            for (int i = 0; i < _abilityComboBoxes.Count; i++)
            {
                _abilityComboBoxes[i].Enabled = false;
            }
            _abilityCycleFrom.Enabled = false;
            _abilityCycleTo.Enabled = false;
            _abilityPressFrom.Enabled = false;
            _abilityPressTo.Enabled = false;
            _BTD6ActiveWindow.Enabled = false;
        }

        public void EnableAll()
        {
            for (int i = 0; i < _abilityCheckBoxes.Count; i++)
            {
                _abilityCheckBoxes[i].Enabled = true;
            }
            for (int i = 0; i < _abilityComboBoxes.Count; i++)
            {
                _abilityComboBoxes[i].Enabled = true;
            }
            _abilityCycleFrom.Enabled = true;
            _abilityCycleTo.Enabled = true;
            _abilityPressFrom.Enabled = true;
            _abilityPressTo.Enabled = true;
            _BTD6ActiveWindow.Enabled = true;
        }

        public PressAbilitiesParams PackageData()
        {
            Dictionary<CheckBox, bool> _abilityCheckDict = new Dictionary<CheckBox, bool>();
            foreach (CheckBox abilityCheckBox in _abilityCheckBoxes)
            {
                _abilityCheckDict.Add(abilityCheckBox, abilityCheckBox.Checked);
            }

            Dictionary<ComboBox, int> _abilityComboDict = new Dictionary<ComboBox, int>();
            foreach (ComboBox abilityComboBox in _abilityComboBoxes)
            {
                _abilityComboDict.Add(abilityComboBox, int.Parse(abilityComboBox.SelectedItem.ToString()));
            }

            PressAbilitiesParams pressAbilitiesParams = new PressAbilitiesParams {
                handle = _form.Handle,
                abilityCheckDict = _abilityCheckDict,
                abilityComboDict = _abilityComboDict,
                abilityCycleComboBoxFrom = int.Parse(_abilityCycleFrom.Text) * 1000,
                abilityCycleComboBoxTo = int.Parse(_abilityCycleTo.Text) * 1000,
                abilityPressComboBoxFrom = (int)(decimal.Parse(_abilityPressFrom.Text) * 1000),
                abilityPressComboBoxTo = (int)(decimal.Parse(_abilityPressTo.Text) * 1000),
                BTD6ActiveWindow = _form.BTD6ActiveWindow.Checked
            };
            return pressAbilitiesParams;
        }
    }
}