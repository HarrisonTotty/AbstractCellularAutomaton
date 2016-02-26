# AbstractCellularAutomaton
An abstract cellular automaton program I wrote recently with a heavy emphasis on lambda programming and recursive algorithms to provide an easily extendable simulation. Uses a custom inheritance of a System.Windows.Forms.DataVisualization chart for visualization of the cellular automaton. Capable of simulating Conway's Game of Life as well as many other pre-defined or random algorithms.

## Compiling
You need Microsoft Visual Studio 2015 (I assume an ealier version would work, but I could be wrong) to compile the source code. If you don't wish to compile the source code yourself, I will upload a compressed pre-compiled executable in the root directory of the project.

## Running/Controls
When the program is started you will see a blank grid. Simply click "Simulation" > "Start (S)" to run a 10x10 automaton of Conway's Game of Life. The program will automatically seed your simulation with the selected seed algorithm when the start button is pressed if the automaton has not been yet been seeded. The following controls are at your disposal:
* S - Start the simulation or stop a simulation that is already running
* R - Restart the simulation or start a simulation that is not already running
* [SPACE] - Pause/Resume a running simulation
* +/- OR [Mouse Wheel] - Zoom in or out from the simulation
* [Arrow Keys] - Move the relative orgin of the grid window
* P - Toggle point mode (renders all cells at the same size regardless of zoom level for faster rendering)
* A - Toggle grid axes
* G - Toggle gridlines (when the axes are enabled)
