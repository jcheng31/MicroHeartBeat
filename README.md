MicroHeartBeat
==============

If your (.NET Micro Framework) application needs a regular, heartbeat-like event to function, **MicroHeartBeat** is for you. Set a period for the timer to trigger, add an event handler, and you're good to go.

This helper class was originally created for the [AgentIntervals](https://github.com/jcheng31/AgentIntervals) app. It's essentially just a wrapper around the stock `Timer` class, but with several methods to add useful functionality.

## Quick Start
Include the contents of the bin/Release folder in your project, and add a reference to `MicroHeartBeat.dll`.

## Example Usage
    public class ExampleClass
    {
    	private static HeartBeat _heartBeat;
    	
    	public static void Main()
    	{
    		// Events will trigger every 500 ms.
    		_heartBeat = new HeartBeat(500);
    		_heartBeat.OnHeartBeat += HeartBeatEventHandler;
    		_heartBeat.Start();
    		
    		Thread.Sleep(Timeout.Infinite);
    	}
    	
    	private static void HeartBeatEventHandler(object sender, EventArgs e)
    	{
    		// Include your logic here!
    	}
    }

## Methods
`HeartBeat(int period)`: construct a new `HeartBeat` that fires events every _period_ milliseconds apart.

`void Start()`: begins the heartbeat immediately.

`void Start(int delay)`: waits _delay_ milliseconds, then begins  the heartbeat.

`void Stop()`: stops the heartbeat.

`bool Toggle()`: if the heartbeat is running, stops it and returns `false`; if it is stopped, starts it immediately and returns `true`.

`bool Toggle(int delay)`: same as `Toggle()`, but will wait _delay_ milliseconds before starting the heartbeat.

`void Reset()`: stops and restarts the heartbeat.

`void Reset(int delay)`: stops the heartbeat, waits _delay_ milliseconds, then starts it again.

`void ChangePeriod(int period)`: changes the heartbeat to trigger every _period_ milliseconds instead. If the heartbeat is running, stops and starts it again.

##License
**MicroHeartBeat** is available under the MIT License.