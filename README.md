<br />
<div align="center">
  <a href="https://github.com/trevtravtrev/autoBTD6">
    <img src="logo.png" alt="autoBTD6" width="500" height="100">
  </a>

  <p align="center">
autoBTD6 is a Windows Desktop Application written in C# with .NET Framework that automates triggering and usage of abilities in Bloons Tower Defense 6 (BTD6). The user can dynamically select which abilities they want triggered, the amount of each, set randomized human-like triggering delays, and only trigger ability keys in the BTD6 window.    <br />
    <a href="https://github.com/trevtravtrev/autoBTD6/issues">Report Bug</a>
     | 
    <a href="https://github.com/trevtravtrev/autoBTD6/issues">Request Feature</a>
  </p>
</div>

<p align="center">
  <img src="demo.gif" alt="demo" width="600" />
</p>

##Features

- Automate ability usage in Bloons Tower Defense 6 (BTD6).  
- Dynamically select abilities to use.  
- Set the amount of each ability to use.  
- Set human-like delays between each ability usage cycle and individual ability usages.  
- Choose whether to trigger abilities only in the active BTD6 window or in any active window.  
- Simple and easy-to-use interface.  
- Open-source and customizable.  

##Dependencies

autoBTD6 has following dependencies:  
- Windows operating system  
- .NET Framework 4.7.2 or higher  
- `user32.dll` for finding windows  
- AutoIt v3 for ability triggering  

##Interface
<p align="center">
  <img src="interface.jpg" alt="interface" width="600" />
</p>

##How to use

1. Download the latest release from the [releases page](https://github.com/trevtravtrev/autoBTD6/releases).
2. Extract the contents of the zip file to a location of your choice.
3. Run `autoBTD6.exe`.

##Settings

The following settings are available:

| Settings                         | Description                                                                                     |
|----------------------------------|-------------------------------------------------------------------------------------------------|
| Ability Checkboxes 1-9           | Checkboxes that allow you to select which abilities you want to trigger.                       |
| Ability Amount Dropdowns 1-9     | Dropdowns that allow you to select the amount of each ability you have available (1-10).       |
| Ability Cycle (Seconds) Range    | A random delay in seconds after each cycle of all abilities being triggered.                   |
| Ability Press (Seconds) Range    | A random delay in seconds after each ability has been triggered.                               |
| BTD6 Active Window Only Checkbox | When on, ONLY activates ability keypresses in the active BTD6 game window. Keep ON unless abilities are not being triggered in game. When off, it will trigger ability keypresses in any active window. |
| Start Button                     | Start or stop the program.                                                                       |
