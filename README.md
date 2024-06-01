# Oscilloscope GUI Project
# Overview
During my internship at ASELSAN, I developed a remote-control interface for the Rohde&Schwarz RTA4004 Oscilloscope. This project involved designing and implementing a graphical user interface (GUI) to control the oscilloscope via a computer connection.

# Features
The Oscilloscope GUI Project includes the following features:

Run/Stop: Start or stop the oscilloscope display.
Trigger: Set the level at which the oscilloscope begins measuring the signal.
Source: Select the input source for the oscilloscope.
Single: Perform a single scan of the input signal.
Auto/Norm: Choose between automatic or normal trigger settings.
Force Trigger: Trigger the oscilloscope to read the input immediately.
Screenshot: Capture an instant screenshot of the oscilloscope display.
Autoset: Automatically configure trigger settings.
Clear Screen: Reset the oscilloscope display to its original state.
Preset: Reset all settings to their default values.
Zoom: Zoom in or out on the oscilloscope display.
Horizontal: Move the displayed waveform horizontally.
Acquisition: Set how the oscilloscope digitizes the signal before display.
Channel Controls (CH1/CH2/CH3/CH4): Manage multiple analysis channels.
Cursor: Configure graphical cursor options.
Measure: Calculate signal parameters.
Quick Measure: Quickly measure current signals.
FFT: Display the frequency spectrum of the signal.
Protocol: Define how values are encoded into waveforms.
Generator: Configure the signal generator settings of the oscilloscope.
Brightness: Adjust the display brightness of the oscilloscope.
# Technical Details
The project involved:

Device Connection: Connecting the oscilloscope to the computer using a USB cable.
Driver Installation: Installing necessary drivers for the computer to recognize the oscilloscope.
GUI Design: Creating the Form 1 interface in Visual Studio 2022 to control the oscilloscope.
Code Implementation: Writing C# code to handle oscilloscope commands and interface interactions.
# Key Classes and Functions
RTA4004 Class: Contains the main logic for interfacing with the oscilloscope.
Commands: Includes methods for "RUN", "STOP", "TRIGGER", "FORCE TRIGGER", etc.
Form 1 Controls: Manages the user interface elements and their actions.

# Conclusion
This project provided valuable experience in GUI design, remote device control, and software development in a professional engineering environment. The completed interface enables efficient and user-friendly control of the Rohde&Schwarz RTA4004 Oscilloscope, demonstrating the practical application of software engineering skills in a real-world scenario.
