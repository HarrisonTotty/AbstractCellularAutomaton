# Harrison's Abstract Cellular Automaton Program
An abstract cellular automaton program I wrote recently with a heavy emphasis on lambda programming and recursive algorithms to provide an easily extendable simulation. Uses a custom inheritance of a System.Windows.Forms.DataVisualization chart for visualization of the cellular automaton. Capable of simulating Conway's Game of Life as well as many other pre-defined or random algorithms.

## Compiling
You need Microsoft Visual Studio 2015 (I assume an ealier version would work, but I could be wrong) to compile the source code. If you don't wish to compile the source code yourself, I will upload a compressed pre-compiled executable in the root directory of the project.

## Current Features
* Integer-based cell states.
* Lambda-based rule, rule selection, neighbor, seed, and boundary condition algorithms which are loaded at runtime.
* Algorithmic support for 1D elementary cellular automata, specified via Wolfram numerical codes.
* Ability to update cell states based on more than one automaton rule (the true result is then selected).
* Parallel thread computation for faster iterations.
* Ability to "buffer" an automaton for a particular number of generations and then play back the result.
* Object serialization for loading/saving live simulations or pre-buffered simulations.
* Ability to randomize most features of an automaton at runtime for discovery of new combinations and patterns.
* Ability to restart a simulation upon the "flatlining" of the current automaton (when up to four successive generations produce no change in cell states).
* Runtime algorithm documentation based on C# attribute metadata.

## Planned Features
* Import C# files containing Func<> expressions at runtime for importing custom algorithms.
* Implementation of a "wavefunction"-based cell state for quantum cellular automata.

## Broken Features
* At very rare instances, some algorithms will produce an integer overflow within a parallel loop. The culpret has not be caught yet >_> (UPDATE: The culpret still isn't caught, but a totally-not-lazily-and-well-implemented try-catch clause has been added to prevent crashing)
* Sometimes input focus can be shifted away from the grid, causing some keyboard shortcuts to not work properly.

## Running
When the program is started you will see a blank grid. Simply click "Simulation" > "Start (S)" to run a 10x10 automaton of Conway's Game of Life. The program will automatically seed your simulation with the selected seed algorithm when the start button is pressed if the automaton has not been yet been seeded. The rest of the options are pretty self-explanitory.

## Controls
The following controls are at your disposal:
* S - Start the simulation or stop a simulation that is already running
* R - Restart the simulation or start a simulation that is not already running
* [SPACE] - Pause/Resume a running simulation
* +/- OR [Mouse Wheel] - Zoom in or out from the simulation
* [Arrow Keys] - Move the relative orgin of the grid window
* P - Toggle point mode (renders all cells at the same size regardless of zoom level for faster rendering)
* A - Toggle grid axes
* G - Toggle gridlines (when the axes are enabled)

## Screenshots
![Screenshot](http://i.imgur.com/FbEIM8d.png "Screenshot 1")
![Screenshot](http://i.imgur.com/7Y2KhBq.png "Screenshot 2")
![Screenshot](http://i.imgur.com/5jUiqhw.png "Screenshot 3")
![Screenshot](http://i.imgur.com/OeQi0zv.png "Screenshot 4")
![Screenshot](http://i.imgur.com/eoARyQa.png "Screenshot 5")
![Screenshot](http://i.imgur.com/BS3MSGO.png "Screenshot 6")
