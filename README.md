# crackingthecodinginterview
C# Solutions of some problems in Cracking the Coding Interview Book

How To Debug in VS Code?

use
$env:VSTEST_HOST_DEBUG=1 

to debug test project

Now if you run the test again you’ll see a prompt to attach a debugger to the test process. Navigate to the debug tab and select the “.NET Core Attach” configuration from the dropdown. Press the green play button and select the process that is indicated by the prompt.

Once the degbugger attaches you’ll have to press the play button again on the debug bar that appears. You should now see that the breakpoint has been caught by the debugger and you can now step through code, watch variables, etc.
